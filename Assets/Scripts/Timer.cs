using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

	private Text timerText;
	public float myTimer = 30;
	private bool isGMPaused;

	// Use this for initialization
	void Start () 
	{
		timerText = GetComponent<Text> ();
		isGMPaused = GameManager.Instance.isPaused;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (!isGMPaused) {
			myTimer -= Time.deltaTime;
		}
		timerText.text = myTimer.ToString ("f0");
	}
}