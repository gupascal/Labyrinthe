using UnityEngine;
using System.Collections;

public class PlayerHashIDs : MonoBehaviour {

	public int isWalking;
	public int bomb;

	// Use this for initialization
	void Start () {
		isWalking = Animator.StringToHash("iswalking");
		bomb = Animator.StringToHash("bomb");
	}
}
