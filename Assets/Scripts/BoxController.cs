using UnityEngine;
using System.Collections;

public class BoxController : MonoBehaviour {

	private Vector3 position;
	private bool movable;

	// Use this for initialization
	void Start () {
		position = transform.position;
		movable = true;
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = Vector3.Lerp(transform.position, position, Time.deltaTime * 10);
		if ( (position - transform.position).magnitude < 0.01 ) {
			movable = true;
			transform.position = position;
		}
	}

	public void move(Vector3 move)
	{
		if (movable) {
			position = transform.position + move;
			movable = false;
		}
	}
}
