using UnityEngine;
using System.Collections;

public class Tutorial : MonoBehaviour {
	
	private PlayerController player;

	// Use this for initialization
	void Start () {
		player = FindObjectOfType(System.Type.GetType("PlayerController")) as PlayerController;
	}
	
	// Update is called once per frame
	void Update () {

		float z = player.transform.position.z;

		if (z < 5.5f) {
			guiText.text = "Bien venu dans le tutoriel.\n"
						 + "Vous pouvez vous déplacer avec les touches Z, Q, S, D.\n"
						 + "Mettez vous face à une caisse et avancez pour la déplacer.";
		}
		else if (z < 8.5f) {
			guiText.text = "Il n'est possible que de pousser une seule caisse à la fois.\n";
		}
		else if (z < 12.5f) {
			guiText.text = "Les bombes peuvent etre ramassées et utilisées plus tard.\n"
						 + "Un bonus de temps est donné à chaque fois que l'on en collecte une";
		}
		else if (z < 15.5f) {
			guiText.text = "Lorsque vous ne trouvez pas de solutions, vous pouvez utiliser une bombe pour faire exploser une caisse.\n"
						 + "Chaque bombe utilisée donne un malus de temps.\n\n"
						 + "(Excepté pour ce tutoriel, tous les niveaux sont entièrement réalisables sans utiliser de bombes.)";
		}
		else if (z < 18.5f) {
			guiText.text = "Le but ultime est de récupérer le sceptre à l'autre extrémité du labyrinthe.";
		}
	}
}
