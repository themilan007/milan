using UnityEngine;

class MainDirectionDrawer : MonoBehaviour
{
    [SerializeField] float length = 1;
    [SerializeField] Vector3 direction = new Vector3(1, 1, 1);

    void OnDrawGizmos()
    {
        Vector3 p = transform.position;
        Vector3 right = transform.right * length;
        Vector3 up = transform.up * length;
        Vector3 forward = transform.forward * length;

        Vector3 globalV = transform.TransformDirection(direction);
        globalV.Normalize();
        globalV *= length;

        float r = 0.1f * length;

        Gizmos.color = Color.red;
        Gizmos.DrawLine(p + right, p - right);
        Gizmos.DrawSphere(p + right, r);

        Gizmos.color = Color.green;
        Gizmos.DrawLine(p + up, p - up);
        Gizmos.DrawSphere(p + up, r);

        Gizmos.color = Color.blue;
        Gizmos.DrawLine(p + forward, p - forward);
        Gizmos.DrawSphere(p + forward, r);

        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(p + globalV, p - globalV);
        Gizmos.DrawSphere(p + globalV, r);

    }

}
