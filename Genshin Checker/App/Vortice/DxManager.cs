using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Vortice;
using Vortice.DXGI;
using Vortice.Direct3D11;
using Vortice.Direct3D;
using System.Windows.Forms;
using System.Drawing;
using Vortice.Mathematics;
using OpenTK.Graphics;
using System.IO;

namespace Genshin_Checker.DirectX
{


    /// <summary>
    /// DirectX管理
    /// </summary>
    internal class DxManager : IDisposable
    {
        private DxManager()
        {
        }
        #region シングルトン実装
        /// <summary>
        /// 実体
        /// </summary>
        public static DxManager Instance = null;

        /// <summary>
        /// 実体の取得
        /// </summary>
        public static DxManager Mana
        {
            get
            {
                return Instance;
            }
        }
        #endregion


        #region メンバ変数

        /// <summary>
        /// 描画コントロール
        /// </summary>
        protected Control MCont = null;


        /// <summary>
        /// 画面サイズ
        /// </summary>
        public Size WindowSize
        {
            get
            {
                return this.MCont.ClientSize;
            }
        }



        #region DX関連

        /// <summary>
        /// Direct3D11デバイス
        /// </summary>
        private ID3D11Device _DxDevice = null;
        /// <summary>
        /// Direct3D11デバイス
        /// </summary>
        public ID3D11Device DxDevice
        {
            get
            {
                return this._DxDevice;
            }

        }

        /// <summary>
        /// Direct3D11 Device Context
        /// </summary>
        private ID3D11DeviceContext _DxContext = null;
        /// <summary>
        /// Direct3D11 Device Context
        /// </summary>
        public ID3D11DeviceContext DxContext
        {
            get
            {
                return this._DxContext;
            }
        }



        /// <summary>
        /// DXGI関係のものを作成するもの
        /// </summary>
        protected IDXGIFactory2 DxFactory;

        /// <summary>
        /// スワップチェイン設定
        /// </summary>
        protected IDXGISwapChain SwapChain = null;

        /// <summary>
        /// Direct3D RenderTarget
        /// </summary>
        public ID3D11RenderTargetView RenderTarget3D = null;

        /// <summary>
        /// 深さView
        /// </summary>
        protected ID3D11DepthStencilView DepthView = null;

        /// <summary>
        /// Rasterize方式
        /// </summary>
        protected ID3D11RasterizerState RastState = null;

        /// <summary>
        /// DepthStencil設定
        /// </summary>
        private ID3D11DepthStencilState DepthStencilEnabledState = null;


        /// <summary>
        /// AlphaBlend有効設定
        /// </summary>
        private ID3D11BlendState AlphaNormal = null;

        /// <summary>
        /// AlphaBlend無効設定
        /// </summary>
        private ID3D11BlendState AlphaDisabled = null;
        #endregion

        #endregion


        /// <summary>
        /// 初期化
        /// </summary>
        /// <param name="mc">管理画面</param>        
        public static void Init(Control mc)
        {
            try
            {
                //作成済みだった
                if (DxManager.Instance != null)
                {
                    throw new Exception("already exists");
                }

                //作成
                DxManager.Instance = new DxManager();

                //初期化
                DxManager.Instance.InitDX(mc);

                //デフォルト設定

                //Zバッファ有効
                DxManager.Mana.DxContext.OMSetDepthStencilState(Mana.DepthStencilEnabledState);

                DxManager.Mana.DxContext.RSSetState(Mana.RastState);

            }
            catch (Exception e)
            {
                throw new Exception("DXManager Initialize Exception", e);

            }
        }

        /// <summary>
        /// 描画場所のクリア
        /// </summary>
        /// <param name="col">クリア色</param>
        /// <returns>成功可否</returns>
        public void ClearRenderTarget(Vortice.Mathematics.Color4 col)
        {
            ID3D11DeviceContext cont = this.DxContext;

            //ターゲットクリア
            cont.ClearDepthStencilView(this.DepthView, DepthStencilClearFlags.Depth | DepthStencilClearFlags.Stencil, 1.0f, 0);
            cont.ClearRenderTargetView(this.RenderTarget3D, col);

        }

        /// <summary>
        /// SwapChain更新
        /// </summary>
        public void SwapChainPresent()
        {
            this.SwapChain.Present(0, PresentFlags.None);
        }

        /// <summary>
        /// 破棄処理
        /// </summary>
        public void Dispose()
        {
            //使用物の解放
            //RenderTarget
            this.RenderTarget3D?.Dispose();

            //alpha blend
            this.AlphaNormal?.Dispose();
            this.AlphaDisabled?.Dispose();

            //DepthView開放
            this.DepthView?.Dispose();

            //ステート
            this.RastState?.Dispose();

            //SwapChain
            this.SwapChain?.Dispose();

            //Context
            this.DxContext?.Dispose();

            //Device
            this.DxDevice?.Dispose();

            //Factory
            this.DxFactory?.Dispose();

            DxManager.Instance = null;
        }


        /// <summary>
        /// αブレンド有効化
        /// </summary>
        public void EnabledAlphaBlend()
        {
            DxManager.Mana.DxContext.OMSetBlendState(DxManager.Mana.AlphaNormal);
        }
        /// <summary>
        /// αブレンド無効化
        /// </summary>
        public void DisabledAlphaBlend()
        {
            DxManager.Mana.DxContext.OMSetBlendState(DxManager.Mana.AlphaDisabled);
        }
        //--//--//--//--//--//--//--//--//--//--//--//--//--//--//--//--//--//--//--//--//--//--//--//--//--//--//--//--//--//--//--//
        /// <summary>
        /// デバイスとswapchainの作成
        /// </summary>
        private void CreateDeviceSwapChain()
        {
            ID3D11Device tdev = null;
            FeatureLevel slev;
            ID3D11DeviceContext idx;

            //デバイスの作成
            SharpGen.Runtime.Result mret = D3D11.D3D11CreateDevice(null, DriverType.Hardware, DeviceCreationFlags.BgraSupport, null, out tdev, out slev, out idx);
            if (mret != SharpGen.Runtime.Result.Ok)
            {
                throw new Exception($"D3D11CreateDevice FAILED ret={mret}");
            }
            this._DxDevice = tdev;
            this._DxContext = idx;

            SwapChainDescription1 swc = new SwapChainDescription1();
            {
                //スワップチェインのバッファ数。
                swc.BufferCount = 1;

                swc.Width = this.WindowSize.Width;
                swc.Height = this.WindowSize.Height;
                //表示フォーマット
                swc.Format = Format.R8G8B8A8_UNorm;

                //スワップチェインのマルチサンプルパラメータ
                swc.SampleDescription = new SampleDescription()
                {
                    Count = 1,      //ピクセル単位のマルチサンプル数
                    Quality = 0,    //イメージの品質 0～ID3D10Device::CheckMultiSampleQualityLevels -1の値まで。高いほどクオリティが高いが遅くなる。
                };

                //サーフェイス処理後の動作
                swc.SwapEffect = SwapEffect.Discard;

                swc.Scaling = Scaling.Stretch;

                //サーフェイス使用法
                swc.BufferUsage = Usage.RenderTargetOutput;
            }

            SwapChainFullscreenDescription fscdec = new SwapChainFullscreenDescription
            {
                Windowed = true
            };

            //swapchainの作成
            this.SwapChain = this.DxFactory.CreateSwapChainForHwnd(this.DxDevice, this.MCont.Handle, swc, fscdec);

        }

        /// <summary>
        /// DirectXの初期化
        /// </summary>
        /// <param name="mc">管理コントロール</param>
        private void InitDX(Control mc)
        {
            try
            {
                this.MCont = mc;

                this.DxFactory = DXGI.CreateDXGIFactory1<IDXGIFactory2>();

                //Swapchainとdeviceの作成
                this.CreateDeviceSwapChain();

                //イベントを無効にする
                //DirectXはAlt + Enterで自動でフルスクリーンにする機能がある。これで無効化できる。
                //詳しくはMakeWindowAssociationでサーチ                
                this.DxFactory.MakeWindowAssociation(this.MCont.Handle, WindowAssociationFlags.IgnoreAltEnter);

                //描画領域の初期化
                this.InitRenderTarget();

                //ラスタライズ方式初期化                
                //試験なので裏ポリも描画したい
                Vortice.Direct3D11.RasterizerDescription rastdec = new RasterizerDescription(CullMode.None, FillMode.Solid);
                rastdec.DepthClipEnable = true;
                rastdec.FrontCounterClockwise = true;   //ポリゴン正面の方向基底、時計回り正面＝true
                rastdec.ScissorEnable = false;          //シーザー矩形有効可否(描画領域設定)
                rastdec.MultisampleEnable = false;      //アンチエイリアスの方法指定らしい true=the quadrilateral line anti-aliasing algorithm、FALSE= the alpha line anti-aliasing algorithm.                
                this.RastState = this.DxDevice.CreateRasterizerState(rastdec);

                //三角ポリンゴンの描画                
                this.DxContext.IASetPrimitiveTopology(PrimitiveTopology.TriangleList);


                //Zバッファの初期化
                this.InitDepthStencilState();

                //αブレンド初期化
                this.InitAlphaBlend();


            }
            catch (Exception ex)
            {
                throw new Exception("InitDX", ex);
            }
        }



        /// <summary>
        /// 描画領域の初期化
        /// </summary>
        /// <returns></returns>
        private void InitRenderTarget()
        {
            //描画バッファの初期化                        
            using (ID3D11Texture2D backbuf = this.SwapChain.GetBuffer<ID3D11Texture2D>(0))
            {
                this.RenderTarget3D = this.DxDevice.CreateRenderTargetView(backbuf);
            }

            //////////////////////////////////////////////////////////////////////////////////////////
            //Ｚバッファ初期化
            //元はD3D11_TEXTURE2D_DESC
            Texture2DDescription depdec = new Texture2DDescription();
            #region Zバッファ領域テクスチャの初期化
            depdec.Format = Format.D32_Float_S8X24_UInt;    //バッファフォーマット
            depdec.ArraySize = 1;       //テクスチャの数
            depdec.MipLevels = 1;       //ミップレベル 基本1

            depdec.Width = this.WindowSize.Width;     //テクスチャサイズＷ
            depdec.Height = this.WindowSize.Height;   //テクスチャサイズH
            depdec.SampleDescription = new SampleDescription(1, 0); //マルチサンプリングの値、count=1pixelあたりのサンプル数、quality=クオリティ0～  CheckMultiSampleQualityLevels  - 1まで
            depdec.Usage = ResourceUsage.Default;   //使い方：基本default
            depdec.BindFlags = BindFlags.DepthStencil;      //深度ステンシルとして使用。
            depdec.CpuAccessFlags = CpuAccessFlags.None;    //許可するCPUアクセス、基本none
            depdec.OptionFlags = ResourceOptionFlags.None;  //基本none
            #endregion



            //Zバッファ領域作成
            using (ID3D11Texture2D depbuf = this.DxDevice.CreateTexture2D(depdec))
            {
                DepthStencilViewDescription dsdes = new DepthStencilViewDescription();
                dsdes.Format = depdec.Format;
                dsdes.ViewDimension = DepthStencilViewDimension.Texture2D;
                dsdes.Texture2D.MipSlice = 0;

                this.DepthView = this.DxDevice.CreateDepthStencilView(depbuf, dsdes);
            }

            //初期View設定
            this.DxContext.OMSetRenderTargets(this.RenderTarget3D, this.DepthView);

        }


        /// <summary>
        /// DepthStencil状態の初期化
        /// </summary>
        private void InitDepthStencilState()
        {
            DepthStencilDescription desc = new DepthStencilDescription(true, DepthWriteMask.All, ComparisonFunction.LessEqual);
            desc.StencilEnable = false;

            this.DepthStencilEnabledState = this.DxDevice.CreateDepthStencilState(desc);

        }

        /// <summary>
        /// アルファブレンドの初期化
        /// </summary>
        private void InitAlphaBlend()
        {
            //通常
            BlendDescription bds = new BlendDescription(Blend.SourceAlpha, Blend.InverseSourceAlpha, Blend.One, Blend.Zero);
            bds.RenderTarget[0].IsBlendEnabled = true;
            bds.RenderTarget[0].SourceBlend = Blend.SourceAlpha;
            bds.RenderTarget[0].DestinationBlend = Blend.InverseSourceAlpha;
            bds.RenderTarget[0].BlendOperation = BlendOperation.Add;
            bds.RenderTarget[0].RenderTargetWriteMask = ColorWriteEnable.All;

            this.AlphaNormal = this.DxDevice.CreateBlendState(bds);

            //無効設定
            bds = new BlendDescription(Blend.SourceAlpha, Blend.InverseSourceAlpha, Blend.One, Blend.Zero);
            bds.RenderTarget[0].IsBlendEnabled = false;
            this.AlphaDisabled = this.DxDevice.CreateBlendState(bds);
        }
    }


}