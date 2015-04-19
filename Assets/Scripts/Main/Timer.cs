using UnityEngine;
using System.Collections;

public class Timer : MonoBehaviour {

	public static float nowTime;

	void Start () {
		nowTime = 0f;
	}
	
	void Update () {
		nowTime += Time.deltaTime;
	}
}
