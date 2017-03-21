using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

	private Text timerText;
	private float myTimer = 30;
	private bool increaseTimer = true;

	// Use this for initialization
	void Start () {
		timerText = GetComponent<Text> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (increaseTimer) {
			myTimer -= Time.deltaTime;
			timerText.text = myTimer.ToString ("f0");
		}
		if(myTimer < 0) {
			increaseTimer = false;
			levelPassed ();
		}
	}

	private void levelPassed() {
		Debug.Log ("TIME over, level passed!!!");
		GameManager.Instance.ChangeScene ("WinLevel");
	}
}