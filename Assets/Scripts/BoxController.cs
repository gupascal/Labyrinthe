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

	public bool move(Vector3 move)
	{
		if (movable) {
			BoxController[] boxes = FindObjectsOfType(System.Type.GetType("BoxController")) as BoxController[];
			for (int i = 0; i < boxes.Length; i++)
			{
				Vector3 vect = boxes[i].transform.position - transform.position;
				if (boxes[i] == this) continue;
				if (Vector3.Angle(vect, move) < 0.001 && vect.magnitude-1 < move.magnitude) {
					return false;
				}
			}
			position = transform.position + move;
			movable = false;
			return true;
		}
		return false;
	}
}
