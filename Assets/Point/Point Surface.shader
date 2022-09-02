Shader "Gragh/Point Surface"{
	Properties{
		_Smoothness ("Smoothness",Range(0,1)) = 0.5
	}
	SubShader{
		CGPROGRAM
		#pragma surface ConfigureSurface Standard fullforwardshadows
		//第一個需要的語句是編譯器指令，稱為 pragma。 它被寫成#pragma，後跟一個指令。
		//它指示著色器編譯器生成具有標準照明和完全支持陰影的表面著色器
		#pragma target 3.0
		struct Input{
			float3 worldPos;
		};

		float _Smoothness;

		void ConfigureSurface (Input input, inout SurfaceOutputStandard surface) {
			surface.Albedo.rg = saturate(input.worldPos.xy * 0.5 + 0.5);//反照率，它是衡量有多少光被表面漫反射的量度。
			surface.Smoothness =_Smoothness; //平滑度
		}
		ENDCG //表面著色器的子著色器需要使用 CG 和 HLSL 這兩種著色器語言混合編寫的代碼部分。
	}//SubShader 關鍵字定義
	FallBack "Diffuse" //標準漫反射著色
}