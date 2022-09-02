using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gragh : MonoBehaviour
{
    [SerializeField]//�bUnity�����|���i��w�s�����a��
    Transform pointPrefab;//�bunity�|���i�H�ձ����a��
    [SerializeField,Range(10,100)]
    int resolution = 50;
    /*[SerializeField, Range(0, 2)]//���F�U��if����i��
    int function;*/
    [SerializeField]
    FunctionLibrary.FunctionName function;

    Transform[] points;

    private void Awake()
    {
        float step = 2f / resolution;
        var scale = Vector3.one * step;
        //var position = Vector3.zero;
        points = new Transform[resolution * resolution];
        for(int i=0; i< points.Length; i++) { 
            /*if (x== resolution)
            {
                x = 0;
                z += 1;
            }*/
            Transform point=points[i] = Instantiate(pointPrefab);
            
           // position.x = (x + 0.5f)  *step - 1f;
           // position.z = (z + 0.5f) * step - 1f;
            //position.y = position.x * position.x * position.x; �QUpdate���N
            //point.localPosition = position;
            point.localScale = scale;
            point.SetParent(transform,false);
        }
        
    }
    void Update()
    {
        FunctionLibrary.Function f = FunctionLibrary.GetFunction(function);
        float time = Time.time;//Time.time ���ȹ��`�����C�����N���O�ۦP��
        float step = 2f / resolution;
        float v =  0.5f * step - 1f;
        for (int i = 0,x=0,z=0; i < points.Length; i++,x++)
        {
            if(x == resolution)
            {
                x = 0;
                z +=1;
                v = (z + 0.5f) * step - 1f;
            }
            /* Transform point = points[i];
             Vector3 position = point.localPosition;
             position.y = f( position.x , position.z , time);
             point.localPosition = position;*/
            float u = (x + 0.5f) * step - 1f;            
            points[i].localPosition = f(u, v, time);
        }
    }
}
