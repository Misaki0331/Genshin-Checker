using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Numerics;
using Vortice.Mathematics;
using Vortice.Direct3D11;
using Vortice;
using Vortice.DXGI;
using Vortice.Direct3D;
using Genshin_Checker.DirectX;

namespace Genshin_Checker.DirectX
{
    /// <summary>
    /// 頂点情報
    /// </summary>
    internal struct VertexInfo
    {
        /// <summary>
        /// 頂点位置
        /// </summary>
        public Vector4 Pos;

        /// <summary>
        /// 頂点色
        /// </summary>
        public Color4 Col;

        /// <summary>
        /// テクスチャUV
        /// </summary>
        public Vector2 Tex;
    }

    /// <summary>
    /// Shader更新情報
    /// </summary>
    internal struct ShaderDataDefault
    {
        /// <summary>
        /// 
        /// </summary>
        public Matrix4x4 WorldViewProjMat;
    }


    /// <summary>
    /// Voritce.Windows試験メインクラス
    /// </summary>
    internal class Core : IDisposable
    {
        public Core()
        {
        }

        #region メンバ変数
        /// <summary>
        /// 管理画面
        /// </summary>
        private Form? Form = null;

        //----------------------------------------------------------------------------
        //ポリゴン描画関連
        /// <summary>
        /// 頂点バッファ
        /// </summary>
        private ID3D11Buffer VertexBuffer = null;
        /// <summary>
        /// IndexBuffer
        /// </summary>
        private ID3D11Buffer IndexBuffer = null;
        /// <summary>
        /// 描画頂点数
        /// </summary>
        private int IndexCount = 0;
        //----------------------------------------------------------------------------
        //テクスチャ関連
        /// <summary>
        /// テクスチャサンプラー
        /// </summary>
        public ID3D11SamplerState TexSampler = null;
        /// <summary>
        /// テクスチャのリソース
        /// </summary>
        private ID3D11ShaderResourceView TextureResouce = null;
        //----------------------------------------------------------------------------
        //Shader関連
        /// <summary>
        /// VertexShaer
        /// </summary>
        private ID3D11VertexShader Vs = null;
        /// <summary>
        /// PixelShader
        /// </summary>
        private ID3D11PixelShader Ps = null;
        /// <summary>
        /// 入力レイアウト設定
        /// </summary>
        private ID3D11InputLayout InputLayout = null;
        /// <summary>
        /// シェーダーで使用するContantBuffer(Shaderに送るデータ領域)
        /// </summary>
        private ID3D11Buffer ConstantBuffer = null;
        //----------------------------------------------------------------------------
        #endregion

        //--//--//--//--//--//--//--//--//--//--//--//--//--//--//--//--//--//--//--//--//--//--//
        /// <summary>
        /// 全体の初期化
        /// </summary>
        public void Init(Form form)
        {
            if (form.IsDisposed) throw new ObjectDisposedException(nameof(form));
            //画面の作成
            this.Form = form;
            this.Form.Size = new(1280, 720);
            this.Form.SizeChanged += (s, e) => { DxManager.Init(this.Form); };
            //DirectXの初期化            
            DxManager.Init(this.Form);

            //VertexBufferの作成
            this.CreateVertexBuffer();

            //テクスチャサンプラの作成
            this.CreateTextureSampler();

            //Textureの読み込み
            this.TextureResouce = this.ReadTexture(resource.PaimonsPaint.Furina_2);

            //Shaderの初期化
            this.InitShader(System.Text.Encoding.ASCII.GetString(resource.Render.main));
        }

        /// <summary>
        /// メインループ
        /// </summary>
        public void Loop()
        {
            //画面クリア色
            Color4 clearcol = new Color4(0.3f, 0.3f, 0.3f, 1.0f);

            int gwidth = this.Form.ClientSize.Width;
            int gheight = this.Form.ClientSize.Height;


            //ViewPort
            Viewport vp = new Viewport(0, 0, gwidth, gheight, 0.0f, 1.0f);

            //カメラ設定
            Matrix4x4 cammat = Matrix4x4.CreateLookAt(new Vector3(0.0f, 0.0f, 1000.0f), new Vector3(0.0f, 0.0f, 0.0f), Vector3.UnitY); ;

            //射影設定            
            //透視投影
            float aspect = (float)gwidth / (float)gheight;
            Matrix4x4 projmat = Matrix4x4.CreatePerspectiveFieldOfView(1.0f, aspect, 1.0f, 10000.0f);
            //正射影するならこっち
            //Matrix4x4 projmat = Matrix4x4.CreateOrthographic(gwidth, gheight, 1.0f, 10000.0f);            

            //透明処理
            DxManager.Mana.EnabledAlphaBlend();     //有効化
            //DxManager.Mana.DisabledAlphaBlend();  //無効化


            float rot = 0.0f;

            //メッセージループ
            ClarityLoop.Run(this.Form, () =>
            {
                var cont = DxManager.Mana.DxContext;

                //位置更新
                Matrix4x4 tm = Matrix4x4.CreateTranslation(new Vector3(0.0f, 200.0f, 0.0f));
                Matrix4x4 rm = Matrix4x4.CreateRotationZ(rot);
                Matrix4x4 sm = Matrix4x4.CreateScale(300.0f);
                Matrix4x4 worldviewproj = sm * rm * tm * cammat * projmat;

                //回転！！
                rot += 0.002f;

                //描画開始！
                DxManager.Mana.ClearRenderTarget(clearcol);
                {
                    //ViewPort設定
                    cont.RSSetViewport(vp);
                    cont.IASetPrimitiveTopology(PrimitiveTopology.TriangleList);

                    //テクスチャサンプラ設定            
                    cont.PSSetSampler(0, this.TexSampler);
                    //テクスチャ設定            
                    cont.PSSetShaderResource(0, this.TextureResouce);

                    //Shader設定
                    ShaderDataDefault sdata = new ShaderDataDefault();
                    sdata.WorldViewProjMat = Matrix4x4.Transpose(worldviewproj);    //シェーダに送る時はtranspose、どうやら行列転送の都合上らしい

                    cont.IASetInputLayout(this.InputLayout);
                    cont.VSSetConstantBuffer(0, this.ConstantBuffer);
                    cont.VSSetShader(this.Vs);

                    cont.PSSetShader(this.Ps);

                    //Shaderへの転送
                    cont.UpdateSubresource<ShaderDataDefault>(ref sdata, this.ConstantBuffer);

                    //描画頂点情報設定
                    cont.IASetVertexBuffer(0, this.VertexBuffer, System.Runtime.CompilerServices.Unsafe.SizeOf<VertexInfo>(), 0);
                    cont.IASetIndexBuffer(this.IndexBuffer, Vortice.DXGI.Format.R32_UInt, 0);

                    //描画！
                    cont.DrawIndexed(this.IndexCount, 0, 0);
                }

                //画面更新
                DxManager.Mana.SwapChainPresent();


            });


        }


        /// <summary>
        /// 解放処理
        /// </summary>
        public void Dispose()
        {
            //使用したものを解放する
            this.Vs?.Dispose();
            this.Ps?.Dispose();
            this.InputLayout?.Dispose();
            this.ConstantBuffer?.Dispose();

            this.TexSampler?.Dispose();
            this.TextureResouce?.Dispose();

            this.VertexBuffer?.Dispose();
            this.IndexBuffer?.Dispose();

            DxManager.Mana.Dispose();


        }

        //--//--//--//--//--//--//--//--//--//--//--//--//--//--//--//--//--//--//--//--//--//--//--//--//--//--//--//--//--//--//--//
        //--//--//--//--//--//--//--//--//--//--//--//--//--//--//--//--//--//--//--//--//--//--//--//--//--//--//--//--//--//--//--//
        //--//--//--//--//--//--//--//--//--//--//--//--//--//--//--//--//--//--//--//--//--//--//--//--//--//--//--//--//--//--//--//
        /// <summary>
        /// 頂点情報の作成
        /// </summary>
        private void CreateVertexBuffer()
        {
            //頂点情報
            VertexInfo[] vdata = {
                new VertexInfo(){ Pos = new Vector4(-0.5f, 0.5f, 0.0f, 1.0f), Col = new Color4(1.0f,1.0f,1.0f,1.0f), Tex = new Vector2(0.0f, 0.0f) },
                new VertexInfo(){ Pos = new Vector4(0.5f, 0.5f, 0.0f, 1.0f), Col = new Color4(1.0f,1.0f,1.0f,1.0f), Tex = new Vector2(1.0f, 0.0f) },
                new VertexInfo(){ Pos = new Vector4(0.5f, -0.5f, 0.0f, 1.0f), Col = new Color4(1.0f,1.0f,1.0f,1.0f), Tex = new Vector2(1.0f, 1.0f) },
                new VertexInfo(){ Pos = new Vector4(-0.5f, -0.5f, 0.0f, 1.0f), Col = new Color4(1.0f,1.0f,1.0f,1.0f), Tex = new Vector2(0.0f, 1.0f) },
            };

            //Index情報
            int[] idata = {
                0,1,2,
                0,2,3
            };

            //VertexBufferの作成
            this.VertexBuffer = DxManager.Mana.DxDevice.CreateBuffer(Vortice.Direct3D11.BindFlags.VertexBuffer, vdata);

            //IndexBufferの作成
            this.IndexBuffer = DxManager.Mana.DxDevice.CreateBuffer(Vortice.Direct3D11.BindFlags.IndexBuffer, idata);

            //頂点数の記憶
            this.IndexCount = idata.Length;
        }


        /// <summary>
        /// テクスチャの読み込み
        /// </summary>
        /// <param name="filepath">読み込み画像パス</param>
        /// <returns>読み込みresource</returns>
        private ID3D11ShaderResourceView ReadTexture(Bitmap file)
        {
            ID3D11ShaderResourceView ans = null;
            try
            {
                using (Bitmap srcbit = file)
                {
                    System.Drawing.Rectangle rect = new System.Drawing.Rectangle(0, 0, srcbit.Width, srcbit.Height);

                    //指定フォーマットに変換
                    using (Bitmap bit = srcbit.Clone(rect, System.Drawing.Imaging.PixelFormat.Format32bppArgb))
                    {
                        BitmapData bdata = bit.LockBits(rect, System.Drawing.Imaging.ImageLockMode.ReadWrite, bit.PixelFormat);
                        try
                        {
                            //画像DataBox作製
                            DataBox[] databox = new DataBox[] { new DataBox(bdata.Scan0, bit.Width * 4, bit.Height) };
                            SubresourceData[] drbox = new SubresourceData[] { new SubresourceData(bdata.Scan0, bit.Width * 4, bit.Height) };

                            Texture2DDescription depdec = new Texture2DDescription();
                            #region TextureDescriptionの作製
                            depdec.Format = Format.B8G8R8A8_UNorm;    //バッファフォーマット　8bitRGBA
                            depdec.ArraySize = 1;       //テクスチャの数
                            depdec.MipLevels = 1;       //ミップレベル 基本1

                            depdec.Width = bit.Width;     //テクスチャサイズＷ
                            depdec.Height = bit.Height;   //テクスチャサイズH
                            depdec.SampleDescription = new SampleDescription(1, 0); //マルチサンプリングの値、count=1pixelあたりのサンプル数、quality=クオリティ0～  CheckMultiSampleQualityLevels  - 1まで
                            depdec.Usage = ResourceUsage.Default;   //使い方：基本default
                            depdec.BindFlags = BindFlags.ShaderResource;      //ShaderResourceとしての使用
                            depdec.CpuAccessFlags = CpuAccessFlags.None;    //許可するCPUアクセス、基本none
                            depdec.OptionFlags = ResourceOptionFlags.None;  //基本none
                            #endregion

                            //Texture作製
                            using (ID3D11Texture2D tex = DxManager.Mana.DxDevice.CreateTexture2D(depdec, drbox))
                            {
                                ans = DxManager.Mana.DxDevice.CreateShaderResourceView(tex);
                            }

                        }
                        finally
                        {
                            bit.UnlockBits(bdata);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("ReadTexture", ex);
            }

            return ans;
        }

        /// <summary>
        /// テクスチャサンプラーの作製
        /// </summary>
        /// <returns></returns>
        private void CreateTextureSampler()
        {
            //テクスチャサンプラーの作成
            SamplerDescription ssd = new SamplerDescription();

            //テクスチャのサンプル時に使用するフィルタリングメソッド D3D11_FILTERの値を指定
            ssd.Filter = Filter.ComparisonMinMagMipLinear;

            //テクスチャの座標解決方法 Wrapで繰り返し。D3D11_TEXTURE_ADDRESS_MODEの値を指定
            ssd.AddressU = TextureAddressMode.Wrap;
            ssd.AddressV = TextureAddressMode.Wrap;
            ssd.AddressW = TextureAddressMode.Wrap;

            //TextureAddressMode.Borderの時に有効な色
            ssd.BorderColor = Color4.Black;

            //サンプリングデータを比較する方法
            ssd.ComparisonFunction = ComparisonFunction.Never;

            //計算されたmipmapレベルからのオフセット
            ssd.MipLODBias = 0;

            //ミップマップ範囲下限、上限
            ssd.MinLOD = 0;
            ssd.MaxLOD = 0;

            //作成
            this.TexSampler = DxManager.Mana.DxDevice.CreateSamplerState(ssd);

        }



        /// <summary>
        /// シェーダーの初期化
        /// </summary>
        /// <param name="shaderfilepath">ShaderFilePath</param>
        private void InitShader(string shadercode)
        {

            //VertexShaderの作成
            this.CreateVertexShader(shadercode);

            //PixelShader作成
            this.CreatePixelShader(shadercode);

            //コンスタントバッファの作成
            BufferDescription desc = new BufferDescription();
            {
                desc.BindFlags = BindFlags.ConstantBuffer;
                desc.CpuAccessFlags = CpuAccessFlags.None;
                desc.OptionFlags = ResourceOptionFlags.None;
                desc.SizeInBytes = System.Runtime.CompilerServices.Unsafe.SizeOf<ShaderDataDefault>();
                desc.StructureByteStride = 0;
            }
            this.ConstantBuffer = DxManager.Mana.DxDevice.CreateBuffer(desc);
        }

        /// <summary>
        /// VertexSahderの作成
        /// </summary>
        /// <param name="filepath">shaderファイルパス</param>
        private void CreateVertexShader(string shadercode)
        {
            try
            {
                //Shaderファイルの読み込み
                string srccode = shadercode;

                //頂点シェーダーコンパイル
                Vortice.Direct3D.Blob blob, erblob;
                var cpret = Vortice.D3DCompiler.Compiler.Compile(srccode, "VsDefault", "unknown", "vs_4_0", out blob, out erblob);
                if (cpret != SharpGen.Runtime.Result.Ok)
                {
                    throw new Exception($"Vs Compile FAILED {cpret}\nret= 0x{((int)cpret).ToString("X").PadLeft(8,'0')}");
                }

                //頂点入力レイアウトの定義
                //VertexBufferで作成した頂点と同じ配置にする
                InputElementDescription[] ipevec = {
                    new InputElementDescription("POSITION", 0, Format.R32G32B32A32_Float, 0, 0),
                    new InputElementDescription("COLOR", 0, Format.R32G32B32A32_Float, 16, 0),
                    new InputElementDescription("TEXCOORD", 0, Format.R32G32_Float, 32, 0),
                };
                this.InputLayout = DxManager.Mana.DxDevice.CreateInputLayout(ipevec, blob);

                //頂点Shaderの作成
                this.Vs = DxManager.Mana.DxDevice.CreateVertexShader(blob);
            }
            catch (Exception ex)
            {
                throw new Exception("CreateVertexShader", ex);
            }


        }


        /// <summary>
        /// PixelShaderの作成
        /// </summary>
        /// <param name="filepath">shaderファイルパス</param>
        protected void CreatePixelShader(string shadercode)
        {
            try
            {
                //Shaderファイルの読み込み
                string srccode = shadercode;

                Vortice.Direct3D.Blob blob, erblob;
                var cpret = Vortice.D3DCompiler.Compiler.Compile(srccode, "PsDefault", "unknown", "ps_4_0", out blob, out erblob);
                if (cpret != SharpGen.Runtime.Result.Ok)
                {
                    throw new Exception($"Ps Compile FAILED ret={cpret}");
                }

                //作製                
                this.Ps = DxManager.Mana.DxDevice.CreatePixelShader(blob);

            }
            catch (Exception ex)
            {
                throw new Exception("CreatePixelShader", ex);
            }
        }
    }
}
