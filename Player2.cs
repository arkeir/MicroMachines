using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2 : MonoBehaviour
{
    public float moveSpeed;
    public float maxSpeed;
    public float brake;
    public float rotationSpeed = 10f;
    public float acceleration;
    public float reverseSpeed;

    private float fly = .5f;
    private float normalSpeed;

    private Vector3 lastCheckpoint;
    private Rigidbody rb;
    private Quaternion something;

    void Start()
    {
        normalSpeed = moveSpeed;
        rb = GetComponent<Rigidbody>();
    }


    void Update()
    {

        if (Physics.Raycast(transform.position, Vector3.down, 1f))
        {
            Debug.Log("hitting this");
        }

        if (rb.IsSleeping())
        {
            Debug.Log("snooze");
        }

        if (!rb.IsSleeping())
        {
            Debug.Log("vroom");
        }

        Movement();
    }


    void OnTriggerEnter(Collider hit)
    {
        if (hit.gameObject.tag == "Checkpoint")
        {
            lastCheckpoint = hit.transform.position;
            something = hit.transform.localRotation;
            Debug.Log("Checkpoint is " + lastCheckpoint);
        }
    }


    void OnCollisionEnter(Collision hit)
    {
        if (hit.gameObject.tag == "floor")
        {
            Debug.Log("Shame");
            this.transform.position = lastCheckpoint;
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
            this.transform.rotation = something;
        }
    }


    void Movement()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            Debug.Log("UpArrow is pressed");
            rb.AddForce(transform.forward * moveSpeed);
        }

        if (Input.GetKey(KeyCode.DownArrow) && !rb.IsSleeping())
        {
            Debug.Log("DownArrow is pressed");
            rb.AddForce(-transform.forward * reverseSpeed);
        }



        float Rotation = Input.GetAxis("Horizontal") * rotationSpeed * Time.deltaTime;

        transform.Rotate(0, Rotation, 0);
    }

}
