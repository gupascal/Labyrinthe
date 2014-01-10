using UnityEngine;
using System.Collections;

public class BombController : MonoBehaviour {

	public Transform boxExplosionPrefab;
	public AudioClip explosion;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other)
	{
		if (GetComponentInChildren<MeshRenderer>().enabled == false)
			return;

		if (other.gameObject.tag == "box")
		{
			Instantiate(boxExplosionPrefab, other.gameObject.transform.position, Quaternion.identity);
			Destroy (other.gameObject);
		}

		if (explosion != null) {
			gameObject.audio.PlayOneShot(explosion);
		}
		GetComponentInChildren<MeshRenderer>().enabled = false;
		Destroy (gameObject, 2f);
	}
}
