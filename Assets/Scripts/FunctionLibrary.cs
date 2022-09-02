using UnityEngine;
using static UnityEngine.Mathf; //想問status的用法跟意思!!
public static class FunctionLibrary  //static是靜態的寫法
{
    public delegate float Function(float x,float z, float t);//自己建立一個function

    public enum FunctionName { Wave, MultiWave, Ripple }//此方法不用加分號，在Unity會顯示下拉選單並有Wave...的選項，
                                                        //第13行要加(int)，因為語法原本不是
   

    static Function[] functions = { Wave , MultiWave , Ripple};//設定為只能內部使用不能公開

    public static Function GetFunction (FunctionName name)
    {//這樣在Gragh就不用在那邊if else (先前步驟)
        return functions[(int)name];//(後一個步驟:讓if else 都消失，回傳給第7行)
    }

    public static float Wave(float x,float z, float t)  //可以讓gragh呼叫這裡
    {
        return Sin(PI * (x + z + t));
    }
    public static float MultiWave (float x ,float z,float t)//可以讓gragh呼叫這裡
    {
        float y = Sin(PI * (x + 0.5f*t));
        y += Sin(2f * PI * (z + t)) *0.5f;
        y += Sin(PI * (x + z + 0.25f * t));
        return y * (2f/3f);
    }
    public static float Ripple(float x,float z, float t)//紋波函數
    {
        float d = Sqrt(x*x+z*z);
        float y = Sin(PI * (4f * d -t));
        return y / (1f + 10f * d);
    }
}
