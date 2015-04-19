using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	public enum GameState {
		GetReady,
		GetReady2,
		GamePlay,
		NextQues,
		GameEnd
	}
	public static GameState State;

	void Start () {
		StartCoroutine ("WaitThenStart");
	}

	IEnumerator WaitThenStart () {
		yield return new WaitForSeconds (0f);

		GameObject.Find ("RequireCoin").SendMessage("Init");
		Debug.Log (PlayerPrefs.GetInt ("Continue"));
		if (PlayerPrefs.GetInt ("Continue") == 0) {
			StateChange ("GetReady");
		} else if (PlayerPrefs.GetInt ("Continue") == 1) {
			StateChange ("GetReady2");
		}
	}

	void StateSetup () {
		switch (State) {
		
		case GameState.GetReady:
			if(GameObject.Find ("RequireCoin") != null) {
				GameObject.Find ("RequireCoin").SendMessage("Setup");
			}
			GameObject.Find ("ButtonHandler").SendMessage("Label");
			State = GameState.GamePlay;
			break;
		
		case GameState.GetReady2:
			GameObject.Find ("RequireCoin").SetActive(false);
			GameObject.Find ("Earn_YES").SetActive(false);
			GameObject.Find ("Earn_NO").SetActive(false);
			break;
		
		case GameState.GamePlay:
			break;

		case GameState.NextQues:
			GameObject.Find ("QuestionHandler").SendMessage("Next");
			goto case GameState.GetReady;
			break;
		
		case GameState.GameEnd:
			if (PlayerPrefs.GetInt ("Continue") == 0) {
				PlayerPrefs.SetFloat ("CostTime", Timer.nowTime);
				PlayerPrefs.SetInt ("Truth", ButtonHandler.truth);
				PlayerPrefs.SetInt ("Lie", ButtonHandler.lie);
			}
			else if (PlayerPrefs.GetInt ("Continue") == 1) {
				PlayerPrefs.SetFloat ("CostTime2", Timer.nowTime);
				PlayerPrefs.SetInt ("Truth2", ButtonHandler.truth);
				PlayerPrefs.SetInt ("Lie2", ButtonHandler.lie);
			}
			Application.LoadLevel ("Result");
			break;
		}
	}

	public void StateChange (string state) {
		switch (state) {
		
		case "GetReady": State = GameState.GetReady; break;
		case "GetReady2": State = GameState.GetReady2; break;
		case "GamePlay": State = GameState.GamePlay; break;
		case "NextQues": State = GameState.NextQues; break;
		case "GameEnd": State = GameState.GameEnd; break;
		
		}
		StateSetup ();
	}
}
