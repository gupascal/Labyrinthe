using UnityEngine;
using System.Collections;

public class HUD : MonoBehaviour {

	public GUIText timeText;
	public GUIText tntText;

	public GUIText timeModifier;
	private float timeModifierTimer = 0;

	private PlayerController player;

	private float time;

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

		if (timeModifier.enabled) {
			timeModifierTimer += Time.deltaTime;
			if (timeModifierTimer > 2.5f) {
				timeModifierTimer = 0;
				timeModifier.enabled = false;
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
}
