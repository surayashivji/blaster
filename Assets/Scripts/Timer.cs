using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

	private Text timerText;

	private float myTimer = 30.0f;
//	public float MyTimer 
//	{
//		get { return myTimer; }
//	}

	private bool isGMPaused;

	private ScoreManager scoreManager;

	// Use this for initialization
	void Start () 
	{
		timerText = GetComponent<Text> ();
		scoreManager = GameObject.Find("ScoreManager").GetComponent<ScoreManager>();
		isGMPaused = GameManager.Instance.isPaused;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (!isGMPaused) {
			myTimer -= Time.deltaTime;
		}
		timerText.text = myTimer.ToString();
		if (myTimer < 1) {
			Debug.Log (myTimer);
			Debug.Log ("We out here");
//			ScoreManager.Instance.SaveGameState (true);
			PrepareForNextLevel(true);
//			SceneManager.LoadScene("WinLevel");
		}
	}


	#region SCORE_MANAGER_ACCESSORS

	public void AddToScore(int val)
	{
		scoreManager.UpdateScore (val);
	}

	public void PrepareForNextLevel(bool didWin)
	{
		scoreManager.SaveGameState (didWin);
	}

	#endregion // SCORE_MANAGER_ACCESSORS


}