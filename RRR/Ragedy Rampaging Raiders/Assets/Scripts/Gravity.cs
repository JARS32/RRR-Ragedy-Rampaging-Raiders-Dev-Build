using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravity : MonoBehaviour {

	public float fallspeed;
	private float fallspeedstorage;

	private Rigidbody rb;
	// Use this for initialization
	void Start () {
		/*fallspeed = fallspeed / 10f;
		fallspeedstorage = fallspeed;
		fallspeed = fallspeed * -1f;*/
		Rigidbody rb = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
		/*fallspeed -= fallspeedstorage;
		transform.Translate (0, fallspeed, 0);*/
		Vector3 v3Velocity = rb.velocity;
		v3Velocity.y = v3Velocity.y + v3Velocity.y;
		rb.velocity = v3Velocity;
	}
	void OnCollisionEnter(Collision other)
	{
		if (other.gameObject.CompareTag("Floor"))
		{

		}

	}
	void OnCollisionExit(Collision other)
	{
		if (other.gameObject.CompareTag("Floor"))
		{	
			
		}

	}
}
