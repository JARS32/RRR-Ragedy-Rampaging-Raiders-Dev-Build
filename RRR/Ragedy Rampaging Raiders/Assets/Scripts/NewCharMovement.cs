using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewCharMovement : MonoBehaviour {

    private Rigidbody rb;

    // CHANGED
    public Vector3 velocity = new Vector3(0, 10, 0);
    public float Gravity = 9.8f;
    //CHANGED

    public float speed;
    public float jumpSpeed;

    public float speedH = 2.0f;
    public float speedV = 2.0f;

    private float yaw = 0.0f;
    private float pitch = 0.0f;

    private float jumpState = 1f;
	private float timer = 10f;

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody>();
    }
	
	// Update is called once per frame
	void Update () {
        float moveHorizontal = Input.GetAxis("Horizontal") * speed;
        float moveVertical = Input.GetAxis("Vertical") * speed;
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

		if (Input.GetKey (KeyCode.Space)) 
		{

			if (jumpState == 1.0f) 
			{
				rb.velocity = new Vector3 (0, jumpSpeed, 0);
				jumpState = 0;
			}
		}
			
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        yaw += speedH * Input.GetAxis("Mouse X");


        transform.eulerAngles = new Vector3(0.0f, yaw, 0.0f);
		moveVertical = moveVertical * Time.deltaTime;
		moveHorizontal = moveHorizontal * Time.deltaTime;
		transform.Translate (0, 0, moveVertical);
		transform.Translate	(moveHorizontal, 0, 0);

        //CHANGED
        // Apply Gravity


        // Calculate new position
        //CHANGED
    }
    //CHANGED
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Floor"))
        {
			jumpState = 1f;
			rb.velocity = new Vector3 (0, 0, 0);
        }

    }

    void OnCollisionExit(Collision other)
    {
        if (other.gameObject.CompareTag("Floor"))
        {

        }

        if (Input.GetKey(KeyCode.Space))
        {

        }
    }
    //CHANGED
}
