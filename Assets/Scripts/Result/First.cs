using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class First : MonoBehaviour {

	[SerializeField] GameObject tryAgain;

	void Start () {
		if (PlayerPrefs.GetInt ("Continue") >= 0) {
			GetComponent<Text> ().text = (PlayerPrefs.GetInt ("Lie")>=1)?"Is that too hard to you?":"You can do fast.";
			transform.Find ("Result").GetComponent<Text> ().text = 
				"You spent " + PlayerPrefs.GetFloat ("CostTime").ToString("F0") + " seconds, and got " + PlayerPrefs.GetInt ("Truth") + " correct " + PlayerPrefs.GetInt ("Lie") + " wrong.";
			if (PlayerPrefs.GetInt ("Continue") == 0) 
				tryAgain.SetActive(true);
		}
	}

	public void TryAgain () {
		PlayerPrefs.SetInt ("Continue", 1);
		Application.LoadLevel ("Main");
	}
}
