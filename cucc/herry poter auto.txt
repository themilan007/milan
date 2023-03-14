using UnityEngine;

class Rocket : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float speed = 1;
    [SerializeField] float angularVelocity = 360;


    void Update()
    {
        if (target == null)
            return;

        Vector3 direction = target.position - transform.position;
        Quaternion targetRotation = Quaternion.LookRotation(direction);    
        float angle = angularVelocity * Time.deltaTime;
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, angle);

        transform.position += transform.forward * speed * Time.deltaTime;
        
    }
}
