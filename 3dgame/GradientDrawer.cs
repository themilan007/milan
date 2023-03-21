using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GradientDrawer : MonoBehaviour
{
    [SerializeField] Vector3 point1, point2;
    [SerializeField] Color color1, color2;
    [SerializeField, Min(2)] int segmentCount = 10;

    void OnDrawGizmos()
    {
        float step = 1f / segmentCount;
        for (int i = 0; i < segmentCount; i++)
        {
            float colorRate = (float)i / (segmentCount - 1);
            Color color = Color.Lerp(color1, color2, colorRate);
            Vector3 start = Vector3.Lerp(point1, point2, i * step);
            Vector3 end = Vector3.Lerp(point1, point2, (i + 1) * step);
            Gizmos.color = color;
            Gizmos.DrawLine(start, end);
        }

    }
}
