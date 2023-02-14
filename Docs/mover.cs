
using UnityEngine;

public class mover : MonoBehaviour
{
    [SerializeField] float speed = 5;
   void Update ()
    {
        bool up = Input.GetKey(KeyCode.UpArrow);
        bool down = Input.GetKey(KeyCode.DownArrow);
        bool  right = Input.GetKey(KeyCode.RightArrow);
        bool left = Input.GetKey(KeyCode.LeftArrow);

        float z = 0;
        if (up && down)
            z = 0;
        else if (up)
            z = 1;
        else if (down)
            z = -1;

        float x = 0;
        if (right && left)
            x = 0;
        else if (right)
            x = 1;
        else if (left)
            x = -1;

        Vector3 valocity = new Vector3(x,0,z);

        


        valocity.Normalize();

        valocity *= speed;



        //bool up = Input.GetKeydown(KeyCode.UpArrow) || input.getkey(keycode.w); ha le van e nyomva a gomb

        Vector3 p = transform.position;
        Vector3 newpoz = p + (valocity * Time.deltaTime);
        transform.position = newpoz;

        if(valocity != Vector3.zero);
        transform.rotation = Quaternion.LookRotation(valocity);
    }
}
