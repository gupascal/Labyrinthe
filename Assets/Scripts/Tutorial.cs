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

		if (z < 4f) {
			guiText.text = "Bien venu dans le tutoriel.\n"
						 + "Vous pouvez vous déplacer avec les touches Z, Q, S, D et à l'aide de la souris.\n";
		}
		else if (z < 7.5f) {
			guiText.text = "Mettez vous face à une caisse et avancez pour la déplacer.\n";
		}
		else if (z < 10.5f) {
			guiText.text = "Il n'est possible que de pousser une seule caisse à la fois.\n"
						 + "Essayez, vous verrez!";
		}
		else if (z < 14.5f) {
			guiText.text = "Les bombes peuvent etre ramassées et utilisées plus tard.\n"
						 + "Un bonus de temps est donné à chaque fois que vous en collectez une.\n";
		}
		else if (z < 17.5f) {
			guiText.text = "Lorsque vous ne trouvez pas de solutions, vous pouvez utiliser une bombe pour faire exploser une caisse.\n"
						 + "Faites un clic gauche pour lancer une bombe, mais attention, chaque bombe utilisée donne un malus de temps!\n\n"
						 + "(Note: Excepté pour ce tutoriel, tous les niveaux sont entièrement réalisables sans utiliser de bombes.)\n";
		}
		else if (z < 20.5f) {
			guiText.text = "Le but ultime est de récupérer le sceptre à l'autre extrémité du labyrinthe.\n"
						 + "Pour vous aider, vous pouvez maintenir la touche F1 pour avoir une vue aérienne du niveau.\n"
						 + "Un appui sur F2 permet de passer d'une vue 1ère paersonne à une vue 3ème personne et vice-versa.";
		}
	}
}
