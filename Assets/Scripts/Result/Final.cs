using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Final : MonoBehaviour {

	[SerializeField] GameObject startOver;

	void Start () {

		if (PlayerPrefs.GetInt ("Continue") == 1) {
			GetComponent<Text> ().text = (PlayerPrefs.GetInt ("Lie2")>=1)?"Watch the game title again.":"Focus is your weapon to against distraction.";
			transform.Find ("Result").GetComponent<Text> ().text = 
				"You spent " + PlayerPrefs.GetFloat ("CostTime2").ToString ("F0") + " seconds, and got " + PlayerPrefs.GetInt ("Truth2") + " correct " + PlayerPrefs.GetInt ("Lie2") + " wrong.";
			startOver.SetActive(true);
		}
	}

	public void Startover () {
		PlayerPrefs.SetInt ("Continue", 0);
		Application.LoadLevel ("Home");
	}
}
