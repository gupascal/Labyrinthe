using UnityEngine;
using System.Collections;

public class TopCameraController : MonoBehaviour {

	private TerrainLoader level;

	// Use this for initialization
	void Start () {
		level = FindObjectOfType(System.Type.GetType("TerrainLoader")) as TerrainLoader;
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.F1))
		{
			GetComponent<Camera>().enabled = true;
		}
		if(Input.GetKeyUp(KeyCode.F1))
		{
			GetComponent<Camera>().enabled = false;
		}

		// Set the right position for the top camera
		float max = (level.getMiddleWidth() > level.getMiddleHeight()) ? level.getMiddleWidth()*2 : level.getMiddleHeight()*2;
		Vector3 posCam = transform.position;
		posCam.x = level.getMiddleWidth();
		posCam.y = max;
		posCam.z = level.getMiddleHeight();
		transform.position = posCam;
	}
}
