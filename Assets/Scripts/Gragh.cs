using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gragh : MonoBehaviour
{
    [SerializeField]
    Transform pointPrefab;
    [SerializeField,Range(10,100)]
    int resolution = 50;

    Transform[] points;

    private void Awake()
    {
        float step = 2f / resolution;
        var scale = Vector3.one * step;
        var position = Vector3.zero;
        points = new Transform[resolution];
        for(int i=0; i< points.Length; i++) { 
            Transform point=points[i] = Instantiate(pointPrefab);
            
            position.x = (i + 0.5f)  *step - 1f;
            //position.y = position.x * position.x * position.x; 被Update取代
            point.localPosition = position;
            point.localScale = scale;
            point.SetParent(transform,false);
        }
        
    }
    void Update()
    {
        for (int i = 0; i < points.Length; i++)
        {
            float time = Time.time;//Time.time 的值對於循環的每次迭代都是相同的
            Transform point = points[i];
            Vector3 position = point.localPosition;
            position.y = Mathf.Sin(Mathf.PI * (position.x+time));
            point.localPosition = position;
        }
    }
}
