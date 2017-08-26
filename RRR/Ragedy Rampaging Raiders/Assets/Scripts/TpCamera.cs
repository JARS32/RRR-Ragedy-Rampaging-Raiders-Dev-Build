using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TpCamera : MonoBehaviour
{
    public static TpCamera Instance;

    public Transform TargetLookAt;

    void Awake()
    {
        Instance = this;
    }

    void Start ()
    {
		
	}
	

	void Update ()
    {
		
	}

    public static void UseExistingOrCreateNewMainCamera()
    {
        GameObject tempCamera;
        GameObject targetLookat;
        TpCamera myCamera;

        if (Camera.main != null)
        {
            tempCamera = Camera.main.gameObject;
        }
        else
        {
            tempCamera = new GameObject("Main Camera");
        }
    }
}
