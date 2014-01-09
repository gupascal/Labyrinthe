using UnityEngine;
using System.Collections;

public class MenuController : MonoBehaviour {

	private Config config;

	// Use this for initialization
	void Start () {
		config = FindObjectOfType(System.Type.GetType("Config")) as Config;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI()
	{
		float buttonWidth = 128f;
		float buttonHeight = 32f;

		int idButton = 0;

		if (GUI.Button(	new Rect((Screen.width - buttonWidth)/2f,
		                         0.3f*Screen.height + buttonHeight * 1.33f * idButton++,
		                         buttonWidth,
		                         buttonHeight),
		               "Tutorial"))
		{
			config.level = "map00";
			config.isTutorial = true;
			Application.LoadLevel("MainScene");
		}
		if (GUI.Button(	new Rect((Screen.width - buttonWidth)/2f,
		                         0.3f*Screen.height + buttonHeight * 1.33f * idButton++,
		                         buttonWidth,
		                         buttonHeight),
		               "Level 1"))
		{
			config.level = "map01";
			config.isTutorial = false;
			Application.LoadLevel("MainScene");
		}
		if (GUI.Button(	new Rect((Screen.width - buttonWidth)/2f,
		                         0.3f*Screen.height + buttonHeight * 1.33f * idButton++,
		                         buttonWidth,
		                         buttonHeight),
		               "Level 2"))
		{
			config.level = "map02";
			config.isTutorial = false;
			Application.LoadLevel("MainScene");
		}
		if (GUI.Button(	new Rect((Screen.width - buttonWidth)/2f,
		                         0.3f*Screen.height + buttonHeight * 1.33f * idButton++,
		                         buttonWidth,
		                         buttonHeight),
		               "Quit"))
		{
			Application.Quit();
		}
	}
}
