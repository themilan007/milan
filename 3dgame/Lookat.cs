
using UnityEngine;

public class Lookat : MonoBehaviour
{
    [SerializeField] Transform target;

     void Update()
    {
        Vector3 targetpos = target.position;
        Vector3 selfpos = transform.position;

        Vector3 dir = targetpos - selfpos;
        
        if (dir !=Vector3.zero )
        transform.rotation = Quaternion.LookRotation(dir);
    }
}
