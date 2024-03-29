
using UnityEngine;

public class uuu : MonoBehaviour
{
    [SerializeField] float bigrange = 10;
    [SerializeField] float smallrange = 10;
    [SerializeField] float speed;
    

     void Update()
    {
        Vector3 self = transform.position;
        Vector3 traget = transform.position;

        float distance = Vector3.Distance(self, traget);
        if(distance <= bigrange)
        {
            float t = Mathf.InverseLerp(bigrange, smallrange, distance);
            float acsual = Mathf.Lerp(0,speed,t);
            transform.position = Vector3.MoveTowards(self,self,acsual* Time.deltaTime);
        }
    }
     void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, smallrange);
        Gizmos.DrawWireSphere(transform.position, bigrange);
    }
}
