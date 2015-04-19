using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class QuestionHandler : MonoBehaviour {

	int index = 0;
	[SerializeField] Text title;
	[SerializeField] Image icon;
	[SerializeField] Sprite[] sprites;
	string[] name;

	void Start () {
		name = new string[8] { "square", "triangle", "circle", "star", "club", "diamond", "heart", "spade" };

		Setup ();
	}
	
	void Next () {
		if (index < 7)
			index ++;
		else
			GameObject.Find ("GameManager").SendMessage ("StateChange", "GameEnd");
		Setup ();
	}

	void Setup () {
		title.text = "Is this " + name [index] + "?";
		icon.sprite = sprites [index];
	}
}
