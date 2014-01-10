using UnityEngine;
using System.Collections;

public class PlayerHashIDs : MonoBehaviour {

	public int isWalking;

	// Use this for initialization
	void Start () {
		isWalking = Animator.StringToHash("iswalking");
	}
}
