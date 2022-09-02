using UnityEngine;
using static UnityEngine.Mathf; //想問status的用法跟意思!!
public static class FunctionLibrary  //static是靜態的寫法
{
   public delegate Vector3 Function(float u, float v, float t);//自己建立一個function

    public enum FunctionName { Wave, MultiWave, Ripple,Sphere, Torus }//此方法不用加分號，在Unity會顯示下拉選單並有Wave...的選項，
                                                        //第13行要加(int)，因為語法原本不是
    
    static Function[] functions = { Wave , MultiWave , Ripple,Sphere, Torus };//設定為只能內部使用不能公開

    public static Function GetFunction (FunctionName name)
    {//這樣在Gragh就不用在那邊if else (先前步驟)
        return functions[(int)name];//(後一個步驟:讓if else 都消失，回傳給第7行)
    }

    public static Vector3 Wave(float u,float v, float t)  //可以讓gragh呼叫這裡
    {
        Vector3 p;
        p.x = u;
        p.y = Sin(PI * (u + v + t));
        p.z = v;
        return p;
    }
    public static Vector3 MultiWave (float u ,float v,float t)//可以讓gragh呼叫這裡
    {
        Vector3 p;
        p.x = u;
        p.y = Sin(PI * (u + 0.5f*t));
        p.y += Sin(2f * PI * (v + t)) *0.5f;
        p.y += Sin(PI * (u + v + 0.25f * t));
        p.y *= 1f / 2.5f;
        p.z = v;
        return p;
    }
    public static Vector3 Ripple(float u,float v, float t)//紋波函數
    {
        float d = Sqrt(u*u+v*v);
        Vector3 p;
        p.x = u;
        p.y = Sin(PI * (4f * d -t));
        p.y /= 1f + 10f * d;
        p.z = v;
        return p;
    }
    public static Vector3 Sphere (float u , float v,float t)
    {
        float r = 0.9f +0.1f * Sin(PI * (6f * u + 4f * v + t));
        float s = r * Cos(0.5f * PI * v);
        Vector3 p;
        p.x = s * Sin( PI * u );
        p.y = r * Sin(PI *0.5f *v);
        p.z = s * Cos( PI * u );
        return p;
    }
    public static Vector3 Torus(float u, float v, float t)
    {
        //float r = 1f;
        float r1 = 0.7f + 0.1f * Sin(PI * (6f * u + 0.5f * t));
        float r2 = 0.15f + 0.05f * Sin(PI * (8f * u + 4f * v + 2f * t)); ;
        float s = r1 + r2 * Cos( PI * v);
        Vector3 p;
        p.x = s * Sin(PI * u);
        p.y = r2 * Sin(PI * v);
        p.z = s * Cos(PI * u);
        return p;
    }
}
