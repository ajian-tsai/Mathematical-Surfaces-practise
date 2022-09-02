Shader "Gragh/Point Surface"{
	Properties{
		_Smoothness ("Smoothness",Range(0,1)) = 0.5
	}
	SubShader{
		CGPROGRAM
		#pragma surface ConfigureSurface Standard fullforwardshadows
		//�Ĥ@�ӻݭn���y�y�O�sĶ�����O�A�٬� pragma�C ���Q�g��#pragma�A���@�ӫ��O�C
		//�����ܵۦ⾹�sĶ���ͦ��㦳�зǷө��M����������v�����ۦ⾹
		#pragma target 3.0
		struct Input{
			float3 worldPos;
		};

		float _Smoothness;

		void ConfigureSurface (Input input, inout SurfaceOutputStandard surface) {
			surface.Albedo.rg = saturate(input.worldPos.xy * 0.5 + 0.5);//�ϷӲv�A���O�Ŷq���h�֥��Q�����Ϯg���q�סC
			surface.Smoothness =_Smoothness; //���ƫ�
		}
		ENDCG //���ۦ⾹���l�ۦ⾹�ݭn�ϥ� CG �M HLSL �o��صۦ⾹�y���V�X�s�g���N�X�����C
	}//SubShader ����r�w�q
	FallBack "Diffuse" //�зǺ��Ϯg�ۦ�
}