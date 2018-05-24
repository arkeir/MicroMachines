using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    public Vector3 thisPosition;

    public float moveSpeed = 5f;
    public float maxSpeed;
    public float rotationSpeed = 10f;

    private float acceleration = .5f;
    private float brake = 1;
    private float fly = .5f;
    private float normalSpeed;

    private Vector3 lastCheckpoint;

    void Start()
    {
        normalSpeed = moveSpeed;
    }


    void Update()
    {
        
        if (Physics.Raycast(transform.position, Vector3.down, 1f))
        {
            Debug.Log("hitting this");
        }

        Movement();
    }

    
    void OnTriggerEnter(Collider hit)
    {
        if (hit.gameObject.tag == "Checkpoint")
        {
            lastCheckpoint = this.transform.position;
            Debug.Log("Checkpoint is "+ lastCheckpoint);
        }
        
    }


    void OnCollisionEnter(Collision hit)
    {
        if (hit.gameObject.tag == "floor")
        {
            Debug.Log("Shame");
            this.transform.position = lastCheckpoint;
        }

        if (hit.gameObject.tag == "LevelObject")
        {
            Vector3 dir = this.transform.position - this.transform.position * 1.5f;
            //Vector3 dir = other.transform.position - this.transform.position;
            Rigidbody rigidForForce = this.gameObject.GetComponent<Rigidbody>();
            rigidForForce.velocity = dir.normalized;
        }
    }


    void Movement()
    {
        float Rotation = Input.GetAxis("Horizontal") * rotationSpeed * Time.deltaTime;
        float Vertical = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;


        if (Vertical > 0 && moveSpeed <= maxSpeed)
            moveSpeed = moveSpeed + acceleration;

        //else if (Vertical > 0 && moveSpeed >= 50)
        //{
        //    moveSpeed = moveSpeed;
        //}

        else if (Vertical <= 0 && moveSpeed >= 5)
            moveSpeed = moveSpeed - brake;



        transform.Translate(0, 0, Vertical);
        transform.Rotate(0, Rotation, 0);
    }


    public float AccSpeed()
    {
        moveSpeed = moveSpeed + 5;
        return moveSpeed;
    }
}
