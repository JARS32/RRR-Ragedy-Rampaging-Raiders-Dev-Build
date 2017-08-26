using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TpController : MonoBehaviour
{

    public static CharacterController CharacterController;
    public static TpController Instance;

	void Awake ()
    {
        CharacterController = GetComponent("CharacterController") as CharacterController;
        Instance = this;
    }
	

	void Update ()
    {
        if (Camera.main == null)
            return;

        GetlocomotionInput();
        HandleActionInput();
        TpMotor.Instance.UpdateMotor();

        if (CharacterController.transform.position.y < -10)
        {
            CharacterController.transform.position = new Vector3(0, 4, 0);
        }
    }

    void GetlocomotionInput()
    {
        var deadZone = 0.1f;

        TpMotor.Instance.verticalVelocity = TpMotor.Instance.moveVector.y;
        TpMotor.Instance.moveVector = Vector3.zero;

        if (Input.GetAxis("Vertical") > deadZone || Input.GetAxis("Vertical") < -deadZone)
        {
            TpMotor.Instance.moveVector += new Vector3(0,0,Input.GetAxis("Vertical"));
        }
        if (Input.GetAxis("Horizontal") > deadZone || Input.GetAxis("Horizontal") < -deadZone)
        {
            TpMotor.Instance.moveVector += new Vector3(Input.GetAxis("Horizontal"), 0, 0);
        }
        TpAnimator.Instance.DetermineCurrentMoveDirection();
    }

    void HandleActionInput()
    {
        if (Input.GetButton("Jump"))
        {
            Jump();
        }
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            TpMotor.Instance.Dash();
        }
    }

    void Jump()
    {
        TpMotor.Instance.Jump();
    }
}
