using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class RequireCoin : MonoBehaviour {

	public static int nowCoin = 0;
	public static int maxCoin = 0;
	public static int coinPerQuest = 0;
	int[] requestCoin;

	public void Init () {
		requestCoin = new int[3] { 426, 689, 902 };

		nowCoin = 0;
		maxCoin = requestCoin [Random.Range (0, requestCoin.Length)];
	}

	public void Setup () {
		coinPerQuest = Mathf.CeilToInt((float)maxCoin / 15) + Random.Range (0, 5);
	}
	
	void FixedUpdate () {
		transform.Find ("Amount").GetComponent<Text> ().text = nowCoin.ToString ().PadLeft (3, '0') + "/" + maxCoin.ToString ();
	}

	public static void Add (int amt) {
		nowCoin += amt;
	}
}
