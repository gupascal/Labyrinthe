using UnityEngine;
using System.Collections;

public class HUD : MonoBehaviour {

	public GUIText timeText;
	public GUIText tntText;

	private PlayerController player;

	private float time;

	// Use this for initialization
	void Start () {
		player = FindObjectOfType(System.Type.GetType("PlayerController")) as PlayerController;
		time = 0;
	}
	
	// Update is called once per frame
	void Update () {
		updateTime();
		tntText.text = player.getNbTNT().ToString() + " TNT";
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
	}
}
