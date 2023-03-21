using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainSrawDirection : MonoBehaviour
{
    
	[SerializeField] float length;  // Egy tengely hossza

    void OnDrawGizmos()
    {
        Vector3 p = transform.position;

        DrawAxis(p, Vector3.right, Color.red);
        DrawAxis(p, Vector3.up, Color.green);
        DrawAxis(p, Vector3.forward, Color.blue);
    }

    void DrawAxis(Vector3 center, Vector3 axis, Color color)
    {
        Vector3 direction = length * transform.TransformDirection(axis);
        Gizmos.color = color;
        Gizmos.DrawLine(center - direction, center + direction);
        Gizmos.DrawSphere(center + direction, 0.1f * length);
    }
}


