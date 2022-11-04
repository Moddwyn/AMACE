using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider),typeof(Rigidbody))]
public class FirstPersonController : MonoBehaviour
{
	[Header("PLEASE SET PLAYER TAG")]
	[Space(20)]
	public float walkSpeed = 5;
	public float runSpeed = 10;
	public KeyCode runKey = KeyCode.LeftShift;

	[Header("PLEASE SET GROUND TAGS")]
	[Space(20)]
	public float jumpStrength = 5;
	public float rayCheckDistance;
	public KeyCode jumpKey = KeyCode.Space;

	[Space(20)]
	public float crouchAmount = 0.25f;
	public KeyCode crouchKey = KeyCode.LeftControl;
	

	[Space(20)]
	public float camSensitivity = 1;
	public float camSmoothing = 2;

	[Space(20)]
	public bool allowMove = true;
	public bool allowJump = true;
	public bool allowCrouch = true;
	public bool allowLook = true;

	Rigidbody rb;
	float speed;
	bool isGrounded = true;
	float normalYLocalPosition = 1;

	Transform charCamera;
	Vector2 currentMouseLook;
	Vector2 appliedMouseDelta;


	void Start()
	{
		rb = GetComponent<Rigidbody>();
		rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
		normalYLocalPosition = rb.transform.localScale.y;

		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;
		charCamera = Camera.main.transform;

	}


	void Update()
	{
		if(allowMove)
			Move();
		if(allowJump)
			Jump();
		if(allowCrouch)
			Crouch();
		if(allowLook)
			Look();
	}

	void Move()
	{
		speed = Input.GetKey(runKey) ? runSpeed : walkSpeed;

		float horAxis = Input.GetAxis("Horizontal");
		float vertAxis = Input.GetAxis("Vertical");
		float inputX = horAxis * speed * Time.deltaTime;
		float inputZ = vertAxis * speed * Time.deltaTime;

		rb.transform.Translate(inputX, 0, inputZ);

	}
	void Jump()
	{
		RaycastHit hit;
		if(Physics.Raycast(transform.position, Vector3.down, out hit, rayCheckDistance))
		{
			isGrounded = hit.transform.tag.Equals("Ground");
		} else 
		{
			isGrounded = false;
		}

		if (Input.GetKeyDown(jumpKey) && isGrounded)
		{
			rb.AddForce(rb.transform.up * jumpStrength, ForceMode.Impulse);
		}
	}
	void Crouch()
	{
		float currentYVal = Input.GetKey(crouchKey)   ?    normalYLocalPosition - crouchAmount    :     normalYLocalPosition;

		rb.transform.localScale = new Vector3(rb.transform.localScale.x,
												  currentYVal,
												  rb.transform.localScale.z);
	}
	void Look()
	{
		Vector2 smoothMouseDelta =  Vector2.Scale(new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y")), Vector2.one * camSensitivity * camSmoothing);
		appliedMouseDelta = Vector2.Lerp(appliedMouseDelta, smoothMouseDelta, 1 / camSmoothing);
		currentMouseLook += appliedMouseDelta;
		currentMouseLook.y = Mathf.Clamp(currentMouseLook.y, -90, 90);

		charCamera.localRotation = Quaternion.AngleAxis(-currentMouseLook.y, Vector3.right);
		transform.localRotation = Quaternion.AngleAxis(currentMouseLook.x, Vector3.up);
	}
	

	// private void OnCollisionEnter(Collision collision)
	// {
	//     if (collision.gameObject.CompareTag("Ground"))
	//     {
	//         isGrounded = true;
	//     }
	// }
	// private void OnCollisionExit(Collision collision)
	// {
	//     if (collision.gameObject.CompareTag("Ground"))
	//     {
	//         isGrounded = false;
	//     }
	// }
}
