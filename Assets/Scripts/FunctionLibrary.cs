using UnityEngine;
using static UnityEngine.Mathf; //�Q��status���Ϊk��N��!!
public static class FunctionLibrary  //static�O�R�A���g�k
{
    public delegate float Function(float x,float z, float t);//�ۤv�إߤ@��function

    public enum FunctionName { Wave, MultiWave, Ripple }//����k���Υ[�����A�bUnity�|��ܤU�Կ��æ�Wave...���ﶵ�A
                                                        //��13��n�[(int)�A�]���y�k�쥻���O
   

    static Function[] functions = { Wave , MultiWave , Ripple};//�]�w���u�ऺ���ϥΤ��ऽ�}

    public static Function GetFunction (FunctionName name)
    {//�o�˦bGragh�N���Φb����if else (���e�B�J)
        return functions[(int)name];//(��@�ӨB�J:��if else �������A�^�ǵ���7��)
    }

    public static float Wave(float x,float z, float t)  //�i�H��gragh�I�s�o��
    {
        return Sin(PI * (x + z + t));
    }
    public static float MultiWave (float x ,float z,float t)//�i�H��gragh�I�s�o��
    {
        float y = Sin(PI * (x + 0.5f*t));
        y += Sin(2f * PI * (z + t)) *0.5f;
        y += Sin(PI * (x + z + 0.25f * t));
        return y * (2f/3f);
    }
    public static float Ripple(float x,float z, float t)//���i���
    {
        float d = Sqrt(x*x+z*z);
        float y = Sin(PI * (4f * d -t));
        return y / (1f + 10f * d);
    }
}
