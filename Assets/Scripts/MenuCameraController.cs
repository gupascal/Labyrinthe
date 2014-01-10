using UnityEngine;
using System.Collections;

public class MenuCameraController : MonoBehaviour {

	private TerrainLoader level;

	// Use this for initialization
	void Start () {
		level = FindObjectOfType(System.Type.GetType("TerrainLoader")) as TerrainLoader;
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 posCam = transform.position;
		posCam.x = level.getMiddleWidth();
		transform.position = posCam;
	}
}
