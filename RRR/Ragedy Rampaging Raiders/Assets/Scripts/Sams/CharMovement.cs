﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharMovement2 : MonoBehaviour {

    private Rigidbody rb;

    // CHANGED
    public Vector3 velocity = new Vector3(5, 5, 0);
    public float Gravity = 9.8f;
    //CHANGED

    public float speed;
    public float jumpSpeed;

    public float speedH = 2.0f;
    public float speedV = 2.0f;

    private float yaw = 0.0f;
    private float pitch = 0.0f;

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody>();
    }
	
	// Update is called once per frame
	void Update () {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        Gravity = 9.8f;

        if (Input.GetKey(KeyCode.W))
        {
            transform.position += transform.forward *  speed;
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.position -= transform.forward *  speed;
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.position -= transform.right *  speed;
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += transform.right *  speed;
        }
        if (Input.GetKey(KeyCode.Space))
        {
			rb.AddForce(new Vector3(0.0f, transform.up.y , 0.0f) * jumpSpeed);
        }
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        yaw += speedH * Input.GetAxis("Mouse X");

        transform.eulerAngles = new Vector3(0.0f, yaw, 0.0f);

        rb.velocity = (movement * speed);

        //CHANGED
        // Apply Gravity
        velocity.y -= Gravity * Time.deltaTime;

        // Calculate new position
        transform.position += velocity * Time.deltaTime;
        //CHANGED
    }
    //CHANGED
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Floor"))
        {
            Gravity = 0.0f;
            velocity.y = 0;
        }

    }
    //CHANGED
}
