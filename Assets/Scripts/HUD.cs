using UnityEngine;
using System.Collections;

public class HUD : MonoBehaviour {

	public GUIText timeText;
	public GUIText tntText;

	private PlayerController player;

	// Use this for initialization
	void Start () {
		player = FindObjectOfType(System.Type.GetType("PlayerController")) as PlayerController;
	}
	
	// Update is called once per frame
	void Update () {
		updateTime();
		tntText.text = player.getNbTNT().ToString() + " TNT";
	}

	void updateTime()
	{
		float sec = Mathf.Floor (Time.time);
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
}
