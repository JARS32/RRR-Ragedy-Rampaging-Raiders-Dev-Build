using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TpMotor : MonoBehaviour
{
    public static TpMotor Instance;

    public float ForwardSpeed = 10f;
    public float BackwardSpeed = 3f;
    public float StrafingSpeed = 6f;
    public float SlideSpeed = 6f;
    public float jumpSpeed = 60f;
    public float Gravity = 21f;
    public float terminalVelocity = 20f;
    public float SlideThreshhold = 0.6f;
    public float MaxControllableSlideMagnitude = 0.4f;
    public float DashSpeed;
    public float DashDuration;
    public float DashCd;
    public bool CanDash;
    private float IsDashing = 0f;
    public float CanJump = 2f;
    public AudioClip JumpSFX;
    public AudioClip DashSFX;

    AudioSource audioSource;

    private Vector3 SlideDirection;
    public Vector3 moveVector { get; set;  }
    public float verticalVelocity { get; set; }


    void Awake ()
    {
        Instance = this;
        audioSource = GetComponent<AudioSource>();
    }
	

	public void UpdateMotor ()
    {
        SnapAlignCharacterWithCamera();
        ProcessMotion();
    }

    void Update()
    {
        IsDashing = IsDashing - DashDuration;
        if (TpController.CharacterController.isGrounded)
        {
            CanDash = true;
        }
    }

    void ProcessMotion ()
    {
        moveVector = transform.TransformDirection(moveVector);

        if (moveVector.magnitude > 1)
        {
            moveVector = Vector3.Normalize(moveVector);
        }
        ApplySlide();
        moveVector *= MoveSpeed();
        moveVector = new Vector3(moveVector.x, verticalVelocity, moveVector.z);
        ApplyGravity();
        TpController.CharacterController.Move(moveVector * Time.deltaTime);
    }
    void ApplyGravity()
    {
        if (moveVector.y > -terminalVelocity)
        {
            moveVector = new Vector3(moveVector.x, moveVector.y - Gravity * Time.deltaTime, moveVector.z);
        }
        if (TpController.CharacterController.isGrounded && moveVector.y < -1)
        {
            moveVector = new Vector3(moveVector.x, -1, moveVector.z);
        }
    }

    void ApplySlide()
    {
        if (!TpController.CharacterController.isGrounded)
        {
            return;
        }
        SlideDirection = Vector3.zero;

        RaycastHit hitInfo;

        if (Physics.Raycast(transform.position + Vector3.up, Vector3.down, out hitInfo))
        {
            if (hitInfo.normal.y < SlideThreshhold)
            {
                SlideDirection = new Vector3(hitInfo.normal.x, -hitInfo.normal.y, hitInfo.normal.z);
            }
        }
        if ( SlideDirection.magnitude < MaxControllableSlideMagnitude)
        {
            moveVector += SlideDirection;
        }
        else
        {
            moveVector = SlideDirection;
        }
    }

    public void Jump()
    {
        if (CanJump > 0f)
        {
            verticalVelocity = jumpSpeed;
            CanJump = CanJump - 1f;
            audioSource.PlayOneShot(JumpSFX, 0.7F);
        }
    }
    public void Dash()
    {
        if (IsDashing < DashCd)
        {
            IsDashing = 1f;
        }
        
    }

    void SnapAlignCharacterWithCamera ()
    {
        if (moveVector.x != 0 || moveVector.z != 0)
        {
            transform.rotation = Quaternion.Euler(transform.eulerAngles.x, Camera.main.transform.eulerAngles.y, transform.eulerAngles.z);
        }
    }

    float MoveSpeed()
    {
        var moveSpeed = 0f;

        switch (TpAnimator.Instance.MoveDirection)
        {
            case TpAnimator.Direction.Stationary:
                moveSpeed = 0;
                break;
            case TpAnimator.Direction.Forward:
                moveSpeed = ForwardSpeed;
                break;
            case TpAnimator.Direction.Backward:
                moveSpeed = BackwardSpeed;
                break;
            case TpAnimator.Direction.Left:
                moveSpeed = StrafingSpeed;
                break;
            case TpAnimator.Direction.Right:
                moveSpeed = StrafingSpeed;
                break;
            case TpAnimator.Direction.LeftForward:
                moveSpeed = ForwardSpeed;
                break;
            case TpAnimator.Direction.LeftBackward:
                moveSpeed = BackwardSpeed;
                break;
            case TpAnimator.Direction.RightBackward:
                moveSpeed = BackwardSpeed;
                break;
            case TpAnimator.Direction.RightForward:
                moveSpeed = ForwardSpeed;
                break;
        }
        if (SlideDirection.magnitude > 0)
        {
            moveSpeed = SlideSpeed;
        }
        if (IsDashing > 0)
        {
            CanDash = false;
            moveSpeed = moveSpeed * DashSpeed;
            audioSource.PlayOneShot(DashSFX, 0.7F);
        }
        return moveSpeed;
    }
}
