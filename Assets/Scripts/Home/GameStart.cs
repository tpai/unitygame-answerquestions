using UnityEngine;
using System.Collections;

public class GameStart : MonoBehaviour {

	Animator anim;

	void Start () {
		anim = transform.Find ("GameTitle").GetComponent<Animator> ();
	}

	public void TitleFadeIn () {
		anim.SetTrigger ("fade");
		StartCoroutine (ChangeLevel ("Main"));
	}

	IEnumerator ChangeLevel (string level) {
		yield return new WaitForSeconds (.5f);
		Application.LoadLevel (level);
	}
}
