Shader "Custom/ToonMamalon" {
	Properties {
		
		
		_MainTex("Texture", 2D) = "white" {}

		_HiRange("High Range",Range(0,1)) = 1
		_HiColor("High Color", Color) = (1,1,1)
		

		_MedRange("Medium Range",Range(0,1)) = 0.5
		_MedColor("Medium Color", Color) = (.5,.5,.5)

		_ShadowColor("Shadow Color", Color) = (0,0,0)
		
		//_NormalMap("Normal Map", 2D) ="bump"{}
		
		_OutlineColor("Outline Color", Color) = (0,0,0,1)
		_Outline("Outline Width", Range(.002, .1)) = .003

	
		
			
	}
	SubShader {
		Tags { "RenderType"="Opaque" }
		LOD 200

		CGPROGRAM
		
		#pragma surface surf ToonRamp

		fixed4 _Color;
		
		sampler2D _MainTex;
		fixed4 _HiColor;
		fixed4 _MedColor;
		fixed4 _ShadowColor;
		float _HiRange;
		float _MedRange;

		

		


		struct Input {
			float2 uv_MainTex;
			float2 uv_NormalMap;
			
			float3 viewDir;
			
		};

		
		
		float4 LightingToonRamp(SurfaceOutput s, fixed3 lightDir, fixed3 viewDir, fixed atten)
		{
			
			float diff = dot(s.Normal, lightDir);
			float h = diff * 0.5 + 0.5;
			float2 rh = h;
			
			float3 ramp =  h > _HiRange ? _HiColor : h > _MedRange ? _MedColor :  _ShadowColor;  

			float4 c;
			c.rgb = s.Albedo * _LightColor0.rgb * ramp;
			c.a = s.Alpha;
			return c;	
			
		}


		void surf (Input IN, inout SurfaceOutput o) {
			

			o.Albedo = tex2D(_MainTex, IN.uv_MainTex).rgb;
			
			
		}
		ENDCG

			Pass{
			Cull Front

			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag

			#include "UnityCG.cginc"

			struct appdata {
			float4 vertex : POSITION;
			float3 normal : NORMAL;
		};

		struct v2f {
			float4 pos : SV_POSITION;
			fixed4 color : COLOR;
		};

		float _Outline;
		float4 _OutlineColor;

		v2f vert(appdata v) {
			v2f o;
			o.pos = UnityObjectToClipPos(v.vertex);

			float3 norm = normalize(mul((float3x3)UNITY_MATRIX_IT_MV, v.normal));
			float2 offset = TransformViewToProjection(norm.xy);

			o.pos.xy += offset * o.pos.z * _Outline;
			o.color = _OutlineColor;
			return o;
		}


		fixed4 frag(v2f i) : SV_Target
		{
			return i.color;
		}
			ENDCG
		}
	}
	FallBack "Diffuse"
}
