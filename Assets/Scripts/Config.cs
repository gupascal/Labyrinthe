using UnityEngine;
using System.Collections;

public class Config : MonoBehaviour {

	public string level = "map01";
	public bool isTutorial = false;

	void Awake()
	{
		DontDestroyOnLoad(gameObject);
	}
}
