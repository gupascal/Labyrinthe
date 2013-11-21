using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	
	public float walkSpeed = 4F;
	public float speed = 0f;
	public float rotationFactor = 5.0F;
    public float gravity = 20.0F;
	
	private Vector3 moveDirection = Vector3.zero;
	private Vector3 rotation = Vector3.zero;
	
	private CharacterController controller;
	
	// Use this for initialization
	void Start () {
		controller = GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void Update () {
		moveDirection = Vector3.zero;
		if (controller.isGrounded) {
			// Moves forward, left, right, backward
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
			moveDirection = transform.TransformDirection(moveDirection);
            
		}
		if (moveDirection != Vector3.zero) {
			speed = Mathf.Lerp(speed, walkSpeed, Time.deltaTime * 5);
		}
		else {
			speed = Mathf.Lerp(speed, 0, Time.deltaTime * 4);
		}
		moveDirection *= speed;

		// Applies move
	    moveDirection.y -= gravity * Time.deltaTime;
	    controller.Move(moveDirection * Time.deltaTime);
		
		// Rotation
		rotation = new Vector3(0, Input.GetAxis("Mouse X"), 0);
		rotation *= rotationFactor * Time.timeScale;
		transform.Rotate(rotation);
	}

	void OnTriggerEnter(Collider other)
	{
		OnTriggerEnterOrStay(other);
	}

	void OnTriggerStay (Collider other)
	{
		OnTriggerEnterOrStay(other);
	}


	void OnTriggerEnterOrStay(Collider other)
	{
		if (other.gameObject.tag == "item")
		{
			Destroy(other.gameObject);
		}
		else if (other.gameObject.tag == "box")
		{
			Vector3 move = other.gameObject.transform.position - transform.position;
			float dotForward = Vector3.Dot (Vector3.forward, move);
			float dotRight = Vector3.Dot (Vector3.right, move);
			if (Mathf.Abs(dotForward) > Mathf.Abs(dotRight)) {
				if (dotForward > 0)
					move = Vector3.forward;
				else
					move = Vector3.back;
			}
			else {
				if (dotRight > 0) 
					move = Vector3.right;
				else
					move = Vector3.left;
			}
			
			BoxController boxC = other.GetComponent<BoxController>();
			boxC.move(move);
			speed = 0;
		}
	}
}
