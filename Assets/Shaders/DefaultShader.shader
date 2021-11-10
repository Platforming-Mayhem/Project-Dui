// Upgrade NOTE: replaced '_Object2World' with 'unity_ObjectToWorld'

// Upgrade NOTE: replaced '_Object2World' with 'unity_ObjectToWorld'

// Upgrade NOTE: commented out 'float4 unity_LightmapST', a built-in variable
// Upgrade NOTE: commented out 'sampler2D unity_Lightmap', a built-in variable

// Upgrade NOTE: replaced tex2D unity_Lightmap with UNITY_SAMPLE_TEX2D

// Upgrade NOTE: commented out 'float4 unity_LightmapST', a built-in variable
// Upgrade NOTE: commented out 'sampler2D unity_Lightmap', a built-in variable

// Upgrade NOTE: replaced tex2D unity_Lightmap with UNITY_SAMPLE_TEX2D

// Upgrade NOTE: replaced tex2D unity_Lightmap with UNITY_SAMPLE_TEX2D

// Upgrade NOTE: commented out 'sampler2D unity_Lightmap', a built-in variable
// Upgrade NOTE: replaced tex2D unity_Lightmap with UNITY_SAMPLE_TEX2D

Shader "Custom Shaders/DefaultShader"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
		_Colour("Colour", Color) = (1,1,1,1)
		_NormalMap ("Normal Map", 2D) = "white"{}
		_NormalStrength ("Normal Strength", Int) = 1
		_Brightest("Brightest", Int) = 1
		_Darkest("Darkest", Int) = 0.5
		_ColourRamp("Colour Ramp", 2D) = "white" {}
		_ReflectivityTex("Reflectivity", 2D) = "black"{}
		_Reflectivity("Reflectivity Value", Int) = 1
		_SmoothnessTex("Smoothness", 2D) = "white" {}
		_Smoothness("Smoothness Value", Int) = 1
		_Emission("Emission", Color) = (0,0,0,1)
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 100

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"
			#include "UnityLightingCommon.cginc"
			#include "AutoLight.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
				float2 tex1 : TEXCOORD1;
				float3 normal : NORMAL;
            };

            struct v2f
            {
                float4 vertex : SV_POSITION;
				float2 uv : TEXCOORD0;
				float2 uv2 : TEXCOORD1;
				float3 worldNormal : TEXCOORD2;
				half3 worldRefl : TEXCOORD3;
            };

            sampler2D _MainTex;
			sampler2D _ReflectivityTex;
			sampler2D _SmoothnessTex;
			sampler2D _NormalMap;
			sampler2D _ColourRamp;

			float1 _Brightest;
			float1 _Darkest;
			float1 _Reflectivity;
			float1 _Smoothness;
			float1 _NormalStrength;
            float4 _MainTex_ST;
			float4 _Colour;
			float4 _Emission;

            v2f vert (appdata v)
            {
                v2f o;
				UNITY_INITIALIZE_OUTPUT(v2f, o);
				o.vertex = UnityObjectToClipPos(v.vertex);
				o.uv = TRANSFORM_TEX(v.uv, _MainTex);
				o.uv2 = v.tex1 * unity_LightmapST.xy + unity_LightmapST.zw;
				o.worldNormal = UnityObjectToWorldNormal(v.normal);
				o.worldRefl = normalize(UnityWorldSpaceViewDir(mul(unity_ObjectToWorld, o.vertex).xyz));
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
				#pragma multi_compile __ LIGHTMAP_ON
                // sample the texture
				float3 finalNormal = i.worldNormal + (abs(UnpackNormal(tex2D(_NormalMap, i.uv) * _NormalStrength)) * 0.5f + 0.5f);
				fixed4 shading = tex2D(_ColourRamp, dot(finalNormal * _Brightest + _Darkest, _WorldSpaceLightPos0.xyz));
				fixed4 col = shading * _LightColor0 * tex2D(_MainTex, i.uv) * _Colour;
				half3 reflection = DecodeHDR(UNITY_SAMPLE_TEXCUBE_LOD(unity_SpecCube0, reflect(-i.worldRefl, finalNormal), (tex2D(_SmoothnessTex, i.uv) * _Smoothness)), unity_SpecCube0_HDR);
				#if LIGHTMAP_ON
					col.rgb *= clamp(DecodeLightmap(UNITY_SAMPLE_TEX2D(unity_Lightmap, i.uv2)) + .7, 0, 1.2);
				#endif
				col.rgb += _Emission + (reflection * (tex2D(_ReflectivityTex, i.uv) + _Reflectivity) * tex2D(_MainTex, i.uv) * _Colour);
                return col;
            }
            ENDCG
        }
    }
}
