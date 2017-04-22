using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

	private Text timerText;
	private float myTimer = 30;

	// Use this for initialization
	void Start () 
	{
		timerText = GetComponent<Text> ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		myTimer -= Time.deltaTime;
		timerText.text = myTimer.ToString ("f0");
	}
}


