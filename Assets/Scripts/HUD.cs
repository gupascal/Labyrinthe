using UnityEngine;
using System.Collections;

public class HUD : MonoBehaviour {

	public GUIText timeText;
	public GUIText tntText;

	public GUIText timeModifier;
	private float timeModifierTimer = 0;

	public GUIText gameWonText;

	private PlayerController player;

	private float time;

	private bool gameWon = false;

	// Use this for initialization
	void Start () {
		player = FindObjectOfType(System.Type.GetType("PlayerController")) as PlayerController;
		time = 0;
		timeModifier.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		updateTime();
		tntText.text = player.getNbTNT().ToString() + " TNT";

		if (timeModifier.enabled)
		{
			timeModifierTimer += Time.deltaTime;
			if (timeModifierTimer > 2.5f) {
				timeModifierTimer = 0;
				timeModifier.enabled = false;
			}
		}

		if (gameWon)
		{
			gameWonText.enabled = true;
			gameWonText.text = "Gagné !";
		}
	}

	void OnGUI()
	{
		if (gameWon)
		{
			float buttonWidth = 128f;
			float buttonHeight = 32f;
			
			int idButton = 0;

			if (GUI.Button( new Rect((Screen.width - buttonWidth)/2f,
			                              0.42f*Screen.height + buttonHeight * 1.33f * idButton++,
			                              buttonWidth,
			                              buttonHeight),
			                    "Recommencer"))
			{
				Time.timeScale = 1;
				Application.LoadLevel("MainScene");
			}
			if (GUI.Button( new Rect((Screen.width - buttonWidth)/2f,
			                              0.42f*Screen.height + buttonHeight * 1.33f * idButton++,
			                              buttonWidth,
			                              buttonHeight),
			                    "Retourner au menu"))
			{
				Application.LoadLevel("MenuScene");
			}
		}
	}

	void updateTime()
	{
		time += Time.deltaTime;
		float sec = Mathf.Floor (time);
		float min = Mathf.Floor(sec/60);
		sec %= 60;
		
		string sSec = sec.ToString();
		if (sSec.Length == 1)
			sSec = "0" + sSec;
		string sMin = min.ToString();
		if (sMin.Length == 1)
			sMin = "0" + sMin;
		
		timeText.text = "Time: " + sMin + "'" + sSec;
	}

	public float getTime()
	{
		return time;
	}

	public void addTime(float t)
	{
		time += t;

		if (t < 0) {
			timeModifier.enabled = true;
			timeModifier.text = (((int)(t*10))/10f).ToString() + "s";
			timeModifier.color = new Color(0f, 1f, 0f);
		}
		else if (t > 0) {
			timeModifier.enabled = true;
			timeModifier.text = "+" + (((int)(t*10))/10f).ToString() + "s";
			timeModifier.color = new Color(1f, 0f, 0f);
		}

	}

	public void gameIsWon()
	{
		gameWon = true;
		Time.timeScale = 0;
	}
}
