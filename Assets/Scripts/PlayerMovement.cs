using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
[RequireComponent(typeof(Rigidbody))]

public class PlayerMovement : MonoBehaviour
{
    float speed = 15f;
    private Rigidbody rb;
    private float horizontalInput;
    private float verticalInput;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

    }



    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

    }


    void FixedUpdate()
    {

        Vector3 movement = new Vector3(horizontalInput, 0f, verticalInput);

        //MovePosition()
        //Vector3 newPosition = transform.position + movement * speed * Time.fixedDeltaTime;
        //rb.MovePosition(newPosition);

        //AddForce()
        //Vector3 force = movement * (speed * 100);
        //rb.AddForce(force);

        //Velocity directly
        Vector3 velocity = movement * speed;
        rb.velocity = velocity;


        //Rigidbody rb = GetComponent<Rigidbody>();
        //rb.MovePosition(transform.position + movement * speed * Time.fixedDeltaTime);
    }
}
