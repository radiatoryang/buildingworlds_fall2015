Shader "RobertShaders/WavyWater" // name of our shader
{
	Properties // "properties" are like public variables for the shader
	{
		_MainTex ("Texture", 2D) = "white" {}
		_WaveHeight ("Wave Height", Float) = 1.0
	}
	SubShader // where all the shader code goes
	{
		Tags { "RenderType"="Opaque" } // Unity-specific stuff
		LOD 100

		Pass // a pass is basically a draw call
		{
			CGPROGRAM // marks the beginning of "CG/HLSL" shader code
			// "pragma" = pre-compiler directive
			#pragma vertex vert
			#pragma fragment frag
			// make fog work
			#pragma multi_compile_fog
			
			// including or importing Unity's shader library code
			#include "UnityCG.cginc"

			// this is the data that your model passes to the vertex shader
			struct appdata
			{
				float4 vertex : POSITION;
				float2 uv : TEXCOORD0;
			};

			// this is the data from vertex shader to fragment shader
			struct v2f
			{
				float2 uv : TEXCOORD0;
				UNITY_FOG_COORDS(1)
				float4 vertex : SV_POSITION;
			};

			sampler2D _MainTex; // this is a twin of the Property above
			float4 _MainTex_ST; // scale / translate
			
			float _WaveHeight;
			
			// VERTEX SHADER
			v2f vert (appdata v)
			{
				v2f o;
				// MVP = "model view projection"
				o.vertex = mul(UNITY_MATRIX_MVP, v.vertex);
				o.vertex += float4(0, sin(_Time.y + o.vertex.x + o.vertex.z) * _WaveHeight, 0, 0);
				o.uv = TRANSFORM_TEX(v.uv, _MainTex);
				UNITY_TRANSFER_FOG(o,o.vertex);
				return o;
			}
			
			// FRAGMENT SHADER
			fixed4 frag (v2f i) : SV_Target
			{
				// sample the texture
				fixed4 col = tex2D(_MainTex, i.uv + fixed2(_Time.x, _Time.x) );
				// apply fog
				UNITY_APPLY_FOG(i.fogCoord, col);				
				return col;
			}
			ENDCG
		}
	}
}
