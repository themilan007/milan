using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Pimover : MonoBehaviour
{
    [SerializeField] Transform posA, posB;
    [SerializeField] float speed;
    [SerializeField, Range(0, 1)] float startpos = 0.5f;
    Transform nextTarget;
    void Start()
    {
        nextTarget = posA;
    }

    void Update()
    {
        Vector3 targetpos = nextTarget.position;

        Vector3 nextpos = Vector3.MoveTowards(transform.position, targetpos, speed * Time.deltaTime);
        transform.position = nextpos;
        if (nextpos == targetpos)
        {
            if (nextTarget == posB)
                nextTarget = posA;
            else
                nextTarget = posB;
        }

        /*
        Vector3 directon = posA.position - posB.position;
        directon.Normalize();
        Vector3 velocity = directon * speed;
        transform.position += Time.deltaTime * velocity;
        */
    }

    void OnValidate()
    {
        transform.position = Vector3.Lerp(posA.position, posB.position, startpos);
    }

    void OnDrawGizmos()
    {
        if (posA == null) return;
        if (posB == null) return;


        Color c1 = Color.red;
        Color c2 = new Color(0, 0, 1);


        Gizmos.color = Color.Lerp(c1, c2, startpos);

        Gizmos.DrawSphere(posA.position, 0.1f);
        Gizmos.DrawSphere(posB.position, 0.1f);
        Gizmos.DrawLine(posA.position, posB.position);
    }



}
