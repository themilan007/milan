using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rocket2 : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float speed = 5;
    [SerializeField] float angularSpeed = 180;

     void Update()
    {
        if (target == null) 
            return;

        Vector3 direction = target.position- transform.position;
        Quaternion targetdirection = Quaternion.LookRotation(direction);
        float ang = angularSpeed * Time.deltaTime;
        Quaternion r= Quaternion.RotateTowards(transform.rotation, targetdirection, ang);


        transform.position = transform.forward* speed * Time.deltaTime;
    }

}
