using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platformerPlayer : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;
    [SerializeField] float jumpSpeed;
    [SerializeField,Min(0)] int airjumpcount = 1;

    bool grounded = false;
    int airjumpbudget;
    void OnValidate()
    {
        if (rb == null)
            rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Jump
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (grounded || airjumpbudget> 0)
            {
                Vector2 velocity = rb.velocity;
                velocity.y = jumpSpeed;
                rb.velocity = velocity;

                if (!grounded)
                    airjumpbudget--;
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        grounded = true;
        airjumpbudget= airjumpcount;

    }

    void OnCollisionExit2D(Collision2D collision)
    {
        grounded = false;
    }
}

