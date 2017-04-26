using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

	public static Timer instance;

	private Text timerText;

	private float myTimer = 25.0f;

	private ScoreManager scoreManager;

	void Awake()
	{
		instance = this;
	}

	// Use this for initialization
	void Start () 
	{
		timerText = GetComponent<Text> ();
		scoreManager = GameObject.Find("ScoreManager").GetComponent<ScoreManager>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (GameManager.Instance.isPaused) 
		{
			return;
		}
		myTimer -= Time.deltaTime;
		timerText.text = myTimer.ToString("####");
		if (myTimer < 1) {
			Debug.Log (myTimer);
			PrepareForNextLevel(true);
			return;
		}
	}

	public void Reset()
	{
		myTimer = 25f;
		timerText.text = myTimer.ToString("####");
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