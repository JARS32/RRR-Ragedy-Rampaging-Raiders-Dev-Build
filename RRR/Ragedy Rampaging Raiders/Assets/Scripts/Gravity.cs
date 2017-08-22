using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravity : MonoBehaviour {

    private Rigidbody rb;
    public float gravity;
    private float accel;
    private float accelStorage;

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody>();
        accel = 1;
        accelStorage = 1;
    }
	
	// Update is called once per frame
	void Update () {
        rb.AddForce(transform.up * gravity * accelStorage * -1, ForceMode.Acceleration);
        accel += accelStorage;
    }
    void OnCollisionEnter(Collision collision)
    {
        accel = accelStorage;
    }
}
