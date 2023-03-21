
using Unity.VisualScripting;
using UnityEngine;


public class folower : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float speed;
     void Update()
    {
        Vector3 selfpozition = transform.position;
        Vector3 targetposition = target.position;
        
        Vector3 direction = targetposition- selfpozition;

        /*
        direction.Normalize();
        Vector3 velocity = direction * speed;
        transform.position = transform.position + velocity * Time.deltaTime;
        */
        transform.position = Vector3.MoveTowards(selfpozition, targetposition, speed * Time.deltaTime);
        if(direction != Vector3.zero )
        transform.rotation = Quaternion.LookRotation(direction);
    }

}
