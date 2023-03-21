using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spaceShip : MonoBehaviour
{
    [SerializeField] float acceleration = 1;
    [SerializeField] float angularSpeed = 360;
    [SerializeField] float drag = 1;
    [SerializeField] float MaxSpeed = 5;
    [SerializeField] float boostSpeed = 5;

    Vector2 velocity;

    void FixedUpdate()
    {

        if (Input.GetKey(KeyCode.UpArrow))
        {
            velocity += (Vector2)transform.up * (acceleration * Time.fixedDeltaTime);

            if(velocity.magnitude > MaxSpeed)
            {
                velocity.Normalize();
                velocity *= MaxSpeed;
            }
        }




        velocity -= velocity * (drag * Time.fixedDeltaTime);
       
       
    }
     void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            velocity += (Vector2)transform.up * boostSpeed;
        }

        transform.position += (Vector3)(velocity * Time.deltaTime);

        float rotate = Input.GetAxis("Horizontal");

        transform.Rotate(new Vector3(0, 0, -rotate * angularSpeed * Time.deltaTime));
    }

}

