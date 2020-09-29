using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class Fire_Radius : MonoBehaviour
{
    [Range(0, 180)] public int segments = 180;
    // segment amount of circle
    [Range(0, 20)] public float xRadius = 20;
    
    [Range(0, 20)] public float yRadius = 20;
    // x and y radius, should remain the same
    [Range(0, 5)] public float lineWidth = 1;
    // width of the circle's line
    LineRenderer line;

    void Start()
    {
        line = gameObject.GetComponent<LineRenderer>();
        line.SetWidth(lineWidth, lineWidth);
        line.SetVertexCount(segments + 1);
        line.useWorldSpace = false;
       
        
        CreateCircle();

    }

    void CreateCircle()
    {
        float x;
        float y;

        float angle = 20f;

        for (int i = 0; i < (segments + 1); i++)
        {
            x = Mathf.Sin(Mathf.Deg2Rad * angle) * xRadius;
            y = Mathf.Cos(Mathf.Deg2Rad * angle) * yRadius;

            line.SetPosition(i, new Vector3(x, y, 0));

            angle += (360f / segments);
            
        }

        
    }
}
