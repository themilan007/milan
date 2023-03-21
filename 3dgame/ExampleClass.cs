using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExampleClass : MonoBehaviour
{
    public Transform target;

    void Update()
    {
        
        transform.LookAt(target);

       
        transform.LookAt(target, Vector3.left);
    }
}
