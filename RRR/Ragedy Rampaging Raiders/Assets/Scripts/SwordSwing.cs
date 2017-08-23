using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordSwing : MonoBehaviour {

    private float swingState = 1f;
    private float count = 0f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            if (swingState == 1f)
            {
                transform.Rotate(90, 0, -45);
                swingState = 2f;
            }        
        }
        if (swingState == 2f)
        {
            transform.Rotate(0f, 0f, 1.5f);
            count = count + 1f;
        }
        if (count == 60f)
        {
            transform.Rotate(0, 0, -45f);
            transform.Rotate(-90f, 0, 0);
            swingState = 1f;
            count = 0f;
        }
    }
}
