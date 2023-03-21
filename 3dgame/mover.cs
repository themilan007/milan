using System.Collections;
using System.Collections.Generic;
using UnityEngine;

  

public class mover : MonoBehaviour
{
    [SerializeField] Transform cameraTransfrom;
    [SerializeField] float speed = 5;
    [SerializeField] bool moveInCameraSpace = true;
    [SerializeField] float angelValocity = 100;
    [SerializeField] healt healt;

         void OnValidate()
    {
        if (healt == null)
            healt = GetComponent<healt>();
        

        

    }
    void Update()
    {
        if (healt != null)
        {
            if (!healt.IsAlive()) return;
        }
        bool up = Input.GetKey(KeyCode.UpArrow);
        bool down = Input.GetKey(KeyCode.DownArrow);
        bool right = Input.GetKey(KeyCode.RightArrow);
        bool left = Input.GetKey(KeyCode.LeftArrow);

        //Vector3 localup = transform.up;

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

        //Vector3 rightdir = Vector3.right;
        //Vector3 forvarddir = Vector3.forward;

        Vector3 rightdir = moveInCameraSpace ? cameraTransfrom.right : Vector3.right;
        Vector3 forvarddir = moveInCameraSpace ? cameraTransfrom.forward : Vector3.forward;



        // Vector3 valocity = new Vector3(x, 0, z);
         Vector3 valocity = rightdir * x + forvarddir * z;




        valocity.Normalize();

        valocity *= speed;



        //bool up = Input.GetKeydown(KeyCode.UpArrow) || input.getkey(keycode.w); ha le van e nyomva a gomb

        Vector3 p = transform.position;
        Vector3 newpoz = p + (valocity * Time.deltaTime);
        transform.position = newpoz;


        if ( valocity != Vector3.zero)
        {
            Quaternion targetpos = Quaternion.LookRotation(valocity);
            Quaternion currentrot = transform.rotation;
            transform.rotation = Quaternion.RotateTowards(currentrot, targetpos, angelValocity * Time.deltaTime);
        }
    }
}



