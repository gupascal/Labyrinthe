using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	
	public float walkSpeed = 4F;
	public float speed = 0f;
	public float rotationFactor = 5.0F;
    public float gravity = 20.0F;

	public BombController bombPrefab;
	
	private Vector3 moveDirection = Vector3.zero;
	private Vector3 rotation = Vector3.zero;
	
	private CharacterController controller;

	private int tnt = 0;
	
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

		if (Input.GetButtonDown("Fire1"))
		{
			if (tnt > 0)
			{
				BombController bomb = Instantiate(bombPrefab, transform.position + transform.forward, Quaternion.identity) as BombController;
				bomb.rigidbody.AddForce(transform.forward*18f + transform.up*15f, ForceMode.Impulse);
				tnt--;
			}
		}
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
			tnt++;
			Destroy(other.gameObject);
		}
		else if (other.gameObject.tag == "box")
		{
			Vector3 move = (other.gameObject.transform.position - transform.position).normalized;
			float dotForward = Vector3.Dot (Vector3.forward, move);
			float dotRight = Vector3.Dot (Vector3.right, move);

			// Disable ambiguous movements (diagonals where we can't determine the direction, avoid small bugs)
			if (Mathf.Abs(Mathf.Abs(dotForward) - Mathf.Abs(dotRight)) < 0.1)
				return;

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
			if (boxC.move(move)) {
				speed = 0;
			}
		}
	}

	public int getNbTNT()
	{
		return tnt;
	}
}
