using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2 : MonoBehaviour
{
    public bool checkpoint1 = false;
    public bool checkpoint2 = false;

    public float moveSpeed;
    public float rotationSpeed;

    public Vector3 movement;
    public Vector3 lastCheckpoint;


    private float fly = .5f;
    
    private Rigidbody rb;
    private Quaternion localRot;


    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
    }


    void FixedUpdate()
    {
        Movement();
    }


    void OnTriggerEnter(Collider hit)
    {
        if (hit.gameObject.tag == "Checkpoint")
        {
            lastCheckpoint = hit.transform.position;
            localRot = hit.transform.localRotation;
        }
    }


    void OnCollisionEnter(Collision hit)
    {
        if (hit.gameObject.tag == "floor")
        {
            this.transform.position = lastCheckpoint;
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
            this.transform.rotation = localRot;
        }
    }


    void Movement()
    {
        float moveHorizontal = Input.GetAxis("Horizontal_P2");
        float moveVertical = Input.GetAxis("Vertical_P2");

        movement = new Vector3(0, 0.0f, moveVertical);

        this.rb.AddForce(transform.rotation * movement * moveSpeed);
        transform.Rotate(0, moveHorizontal * rotationSpeed, 0);
    }
}
