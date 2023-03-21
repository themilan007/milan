using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kameraKovato : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float range;


    Vector3 offset;

    void Start()
    {
        offset = target.position - transform.position;
    }


    void Update()
    {
        Vector3 offsetedPos = transform.position + offset;

        Vector3 difference = target.position - offsetedPos;
        float distance = difference.magnitude;
        if (distance > range)
        {
            Vector3 dir = difference.normalized;
            float length = distance - range;

            transform.position += dir * length;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Vector3 offsetedPos = transform.position + offset;
        Gizmos.DrawWireSphere(offsetedPos, range);
    }
}

