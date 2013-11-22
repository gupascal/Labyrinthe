using UnityEngine;
using System.Collections;

public class BombController : MonoBehaviour {

	public Transform boxExplosionPrefab;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "box")
		{
			Instantiate(boxExplosionPrefab, other.gameObject.transform.position, Quaternion.identity);
			Destroy (other.gameObject);
		}

		Destroy (gameObject);
	}
}
