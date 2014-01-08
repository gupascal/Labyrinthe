using UnityEngine;
using System.Collections;

public class TerrainLoader : MonoBehaviour {

	public GameObject boxPrefab;
	public GameObject itemPrefab;
	public GameObject sceptrePrefab;
	public GameObject wallPrefab;

	public PlayerController player;
	public Camera topCamera;

	private Config config;

	private int width;
	private int height;

	// Use this for initialization
	void Start () {
		config = FindObjectOfType(System.Type.GetType("Config")) as Config;
		load();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void load() {
		string content = Resources.Load<TextAsset>(config.level).text;

		string[] lines = content.Split ('\n');
		width = lines.Length;
		string[] elems = lines[0].Split (';');
		height = elems.Length;

		for (int i = 0; i < lines.Length; i++)
		{
			elems = lines[i].Split (';');
			for (int j = 0; j < elems.Length; j++)
			{
				elems[j] = elems[j].Trim();
				Debug.Log (elems[j]);
				if (elems[j] == "B")
				{
					Instantiate(boxPrefab, new Vector3(i + 0.5f, 0.5f, j + 0.5f), Quaternion.identity);
				}
				else if (elems[j] == "W")
				{
					Instantiate(wallPrefab, new Vector3(i + 0.5f, 0.5f, j + 0.5f), Quaternion.identity);
				}
				else if (elems[j] == "I")
				{
					GameObject item = Instantiate(itemPrefab, new Vector3(i + 0.5f, 0.25f, j + 0.5f), Quaternion.identity) as GameObject;
				}
				else if (elems[j] == "S")
				{
					GameObject sceptre = Instantiate(sceptrePrefab, new Vector3(i + 0.5f, 0.5f, j + 0.5f), Quaternion.identity) as GameObject;
				}
				else if (elems[j] == "P")
				{
					player.transform.position = new Vector3(i + 0.5f, player.transform.position.y, j + 0.5f);
				}
			}

		}

		int max = (width > height) ? width : height;

		Vector3 posCam = topCamera.transform.position;
		posCam.x = width/2f;
		posCam.y = max;
		posCam.z = height/2f;
		Debug.Log (posCam.ToString());
		topCamera.transform.position = posCam;

	}

}
