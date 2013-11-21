using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	
	public float walkSpeed = 6.0F;
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
		if (controller.isGrounded) 
		{
			// Moves forward, left, right, backward
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= walkSpeed;
		}
		// Applies move
	    moveDirection.y -= gravity * Time.deltaTime;
	    controller.Move(moveDirection * Time.deltaTime);
		
		// Rotation
		rotation = new Vector3(0, Input.GetAxis("Mouse X"), 0);
		rotation *= rotationFactor * Time.timeScale;
		transform.Rotate(rotation);
	}
	
}
