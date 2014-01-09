using UnityEngine;
using System.Collections;

public class MenuController : MonoBehaviour {

	private Config config;

	private Menu menu;

	enum Menu {
		MainMenu,
		CreditsMenu
	}

	// Use this for initialization
	void Start () {
		config = FindObjectOfType(System.Type.GetType("Config")) as Config;
		menu = Menu.MainMenu;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI()
	{
		if (menu == Menu.MainMenu)
		{
			drawMainMenu();
		}
		else if (menu == Menu.CreditsMenu)
		{
			drawCredits();
		}
	}

	void drawMainMenu()
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
		               "Credits"))
		{
			menu = Menu.CreditsMenu;
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

	void drawCredits()
	{
		float buttonWidth = 140f;
		float buttonHeight = 20f;
		
		int idButton = 0;

		GUILayout.BeginArea(new Rect((Screen.width - buttonWidth*1.3f)/2f,
				                    0.22f*Screen.height + buttonHeight * 1.33f * idButton++,
				                    buttonWidth*1.3f,
				                    buttonHeight*15));

		GUIStyle style = new GUIStyle();
		style.fontSize = 20;

		GUI.Label(new Rect(0,
		                   buttonHeight * 1.33f * idButton++,
		                   buttonWidth,
		                   buttonHeight*3),
		          "Réalisé par :\nGrandClément Thibaut\nPascal Guillaume\n", style);
		idButton += 2;
		GUI.Label(new Rect(0,
		                   buttonHeight * 1.33f * idButton++,
		                   buttonWidth,
		                   buttonHeight*6),
		          "Musiques et sons de :\nOpenGameArt.org\nxxxx\nyyyy\nzzzz\nkkkk\n", style);
		idButton += 5;

		if (GUI.Button(	new Rect(0,
		                         buttonHeight * 1.33f * idButton++,
		                         buttonWidth,
		                         32),
		               "Retour"))
		{
			menu = Menu.MainMenu;
		}

		GUILayout.EndArea();
	}

}
