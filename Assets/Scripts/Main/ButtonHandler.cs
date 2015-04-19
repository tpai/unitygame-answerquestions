using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ButtonHandler : MonoBehaviour {

	public static int truth = 0;
	public static int lie = 0;
	int truthMoney = 0;
	int lieMoney = 0;
	[SerializeField] Text earn_yes;
	[SerializeField] Text earn_no;
	[SerializeField] Button yes;
	[SerializeField] Button no;

	Animator anim;

	void Start () {
		anim = GetComponent<Animator> ();
		truth = 0;
		lie = 0;
	}

	public void Label () {
		truthMoney = RequireCoin.coinPerQuest;
		lieMoney = RequireCoin.coinPerQuest * 5;
		earn_yes.text = "+"+truthMoney.ToString ();
		earn_no.text = "+"+lieMoney.ToString ();
	}
	
	public void Click (bool b) {
		if (b) {
			truth ++;
			RequireCoin.Add (truthMoney);
		} else {
			lie ++;
			RequireCoin.Add (lieMoney);
		}
		yes.interactable = false;
		no.interactable = false;
		StartCoroutine ("UnlockButton");
	}

	IEnumerator UnlockButton () {
		yield return new WaitForSeconds (1f);
		GameObject.Find ("GameManager").SendMessage ("StateChange", "NextQues");
		anim.SetBool ("switch", (Random.Range (0, 2)==1)?true:false);
		yes.interactable = true;
		no.interactable = true;
	}
}
