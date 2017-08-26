using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour
{
    private float cameraMode = 0f;
    public float cameraChange = 0f;
    public float cameraChange2 = 0f;

    void Start()
    {
        cameraChange2 = cameraChange * -1;
    }

    void Update()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        if (Input.GetKey(KeyCode.E) && cameraMode == 1f)
        {
            if (Camera.current != null)
            {
                Camera.current.transform.localPosition = new Vector3(0f, 2f, -3);
                cameraMode = 0f;
            }
        }
        if (Input.GetKey(KeyCode.Q) && cameraMode == 0f)
        {
            if (Camera.current != null)
            {
                Camera.current.transform.localPosition = new Vector3 (0f, 0f, 0f);
                cameraMode = 1f;
            }
        }
        if (Input.GetKey(KeyCode.R) && cameraMode == 1f || Input.GetKey(KeyCode.R) && cameraMode == 0f)
        {
            if (Camera.current != null)
            {
                Camera.current.transform.localPosition = new Vector3(0f, 2f, -3f);
                cameraMode = 3f;
            }
        }
        if (Input.GetKey(KeyCode.R) && cameraMode == 3f)
        {
            if (Camera.current != null)
            {
                Camera.current.transform.localPosition = new Vector3(2, 2, -4);
                cameraMode = 0f;
            }
        }
    }
}