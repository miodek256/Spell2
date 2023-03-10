using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    public float speed = 10f;
    //public float jumpForce = 5f;
    //public int maxJumps = 2;
    public float maxSpeed = 20f;

    private Rigidbody rb;
    //private int jumps = 0;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Odczytujemy wektor kierunku od gracza
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
        movement = Camera.main.transform.TransformDirection(movement);
        movement.y = 0f;

        // Poruszanie siê kuli na podstawie wektora kierunku
        rb.AddForce(movement * speed);

        // Ograniczenie maksymalnej prêdkoœci
        if (rb.velocity.magnitude > maxSpeed)
        {
            rb.velocity = rb.velocity.normalized * maxSpeed;
        }

        // Double jump
        /* if (Input.GetKeyDown(KeyCode.Space) && jumps < maxJumps)
         {
             rb.AddForce(new Vector3(0f, jumpForce, 0f), ForceMode.Impulse);
             jumps++;
         }
     }

     private void OnCollisionStay(Collision collision)
     {
         jumps = 0; // Resetujemy liczbê skoków po dotkniêciu czegokolwiek
     }
        */
    }
}