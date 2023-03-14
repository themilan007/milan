using UnityEngine;

class GradientDrawer : MonoBehaviour
{
    [SerializeField] Vector3 p1 = Vector3.left, p2 = Vector3.right;
    [SerializeField] Color c1 = Color.red, c2 = Color.blue;

    [SerializeField, Min(2)] int segmentCount = 10;

    void OnDrawGizmos()
    {
        float segment = 1f / segmentCount;

        for (int i = 0; i < segmentCount; i++)
        {

            float tA = segment * i;
            float tB = segment * (i + 1);

            Vector3 a = Vector3.Lerp(p1, p2, tA);
            Vector3 b = Vector3.Lerp(p1, p2, tB);

            float tC = (float)i / (segmentCount - 1);
            Color c = Color.Lerp(c1, c2, tC);

            Gizmos.color = c;
            Gizmos.DrawLine(a, b);
        }
    }

}
