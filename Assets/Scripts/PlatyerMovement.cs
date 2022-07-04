using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatyerMovement : MonoBehaviour
{
	//public GameManager gManager;
	public bool isVisible = true;
	[Header("Movement")]
	internal float horizontal;
	internal float vertical;
	public float f_Speed = 5;
	internal float currentSpeed;
	[Header("Jumping")]
	internal bool jumping = false;
	public float jumpHeight = 15;
	public Vector3 jumpOffset;
	public float jumpSphereRadius;
	internal LayerMask myLayer;

	private const float RAYCAST_LENGTH = 0.1f;

	[Header("Camera")]
	public Camera tPCamera;
	public float mouseXSensitivity = 1;
	float Xrotation;
	float Yrotation;


	[Header("Other")]
	internal Rigidbody rgdbody;
	public bool pausedGame = false;

	[Header("Animator")]
	public Animator anim;
	internal bool isWalking;
	public enum PViews
	{
		FirstPerson,
		ThirdPerson
	}

	void Start()
	{
		rgdbody = GetComponent<Rigidbody>();
		currentSpeed = f_Speed;
		myLayer = LayerMask.GetMask("Ground");
	}

	void Update()
	{

		/*
		 * Movement Check, if is alive can move
		 * if its grounded jumping bool false
		 * */
		horizontal = Input.GetAxis("Horizontal");
		vertical = Input.GetAxis("Vertical");

		if (IsGrounded())
		{
			jumping = false;
		}

		Vector3 pMovement;
		pMovement = new Vector3(horizontal, 0, vertical).normalized * currentSpeed;

		// handles player jumping	
		if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
		{
			pMovement.y = jumpHeight;
			jumping = true;
			anim.SetBool("IsGrounded", jumping);
		}
		else
		{
			pMovement.y = rgdbody.velocity.y;

		}

		Xrotation = Input.GetAxis("Mouse X") * mouseXSensitivity;
		Yrotation -= Input.GetAxis("Mouse Y") * mouseXSensitivity;

		Yrotation = Mathf.Clamp(Yrotation, -90, 90);



		if (!pausedGame)
		{

			tPCamera.transform.localRotation = Quaternion.Euler(Yrotation, 0, 0);
			transform.Rotate(0, Xrotation, 0);

			rgdbody.velocity = transform.TransformDirection(pMovement);
		}



		if (Mathf.Abs(horizontal) > 0)
		{
			anim.SetFloat("HorizontalSpeed", horizontal);
		}
		else
		{
			anim.SetFloat("HorizontalSpeed", 0);
		}
		if (Mathf.Abs(vertical) > 0)
		{
			anim.SetFloat("VerticalSpeed", vertical);
		}
		else
		{
			anim.SetFloat("VerticalSpeed", 0);
		}



		//weapon handlign
		if (Input.GetKey(KeyCode.Mouse1) && IsGrounded())
		{
			
			anim.SetBool("isAimingGun", true);
		}
		if (Input.GetKeyUp(KeyCode.Mouse1))
		{
			anim.SetBool("isAimingGun", false);

		}

	}

	public bool IsGrounded()
	{
		bool value = false;

		Collider[] hitColliders = Physics.OverlapSphere(this.gameObject.transform.position + jumpOffset, jumpSphereRadius, myLayer);

		foreach (Collider col in hitColliders)
		{
			if (col != null)
			{
				value = true;
			}
		}
		anim.SetBool("IsGrounded", value);
		return value;
	}

	private void OnDrawGizmosSelected()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere(this.gameObject.transform.position + jumpOffset, jumpSphereRadius);
	}
}
