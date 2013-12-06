﻿using UnityEngine;
using System.Collections;

public class TerrainLoader : MonoBehaviour {

	public GameObject boxPrefab;
	public GameObject wallPrefab;

	// Use this for initialization
	void Start () {
		load();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void load() {
		string content = Resources.Load<TextAsset>("map01").text;
		Debug.Log (content);
		string[] lines = content.Split ('\n');
		for (int i = 0; i < lines.Length; i++)
		{
			Debug.Log (lines[i]);
			string[] elems = lines[i].Split (';');
			for (int j = 0; j < elems.Length; j++)
			{
				Debug.Log (elems[j]);
				if (elems[j] == "B")
				{
					Instantiate(boxPrefab, new Vector3(i + 0.5f, 0.5f, j + 0.5f), Quaternion.identity);
				}
				else if (elems[j] == "W")
				{
					Instantiate(wallPrefab, new Vector3(i + 0.5f, 0.5f, j + 0.5f), Quaternion.identity);
				}
			}

		}
	}

}