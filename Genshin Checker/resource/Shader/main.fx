
struct VS_IN
{
    float4 pos : POSITION;
    float4 col : COLOR;
    float2 tex : TEXCOORD;
};


struct PS_IN
{
    float4 pos : SV_POSITION;
    float4 col : COLOR;
    float2 tex : TEXCOORD;
};


struct RegistData
{
    float4x4 WorldViewProj;
};

RegistData RData : register(s0);

Texture2D pix : register(t0);
SamplerState picsamp : register(s1);


/////////////////////////////////////////////////////////////////////////////////////////////////////////
//VretexShader
PS_IN VsDefault(VS_IN vsin)
{
    PS_IN outdata = (PS_IN) 0;
		
    outdata.pos = mul(vsin.pos, RData.WorldViewProj);
    outdata.col = vsin.col;

    outdata.tex = vsin.tex;

    return outdata;
}


/////////////////////////////////////////////////////////////////////////////////////////////////////////
//PixelShader
float4 PsDefault(PS_IN psin) : SV_TARGET
{
    float4 col = pix.Sample(picsamp, psin.tex);
    col.w *= psin.col.w;
    return col;
}




