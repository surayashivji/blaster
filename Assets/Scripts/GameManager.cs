using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour {

	// Singleton GameManager
	public static GameManager Instance { set; get; }

	public bool isPaused;

	private Timer timer;
	private GameObject pausePanGO;

	private ScoreManager scoreManager;

	private void Awake() 
	{
		Instance = this;
		DontDestroyOnLoad (this.gameObject);
		scoreManager = ScoreManager.Instance;
		isPaused = false;
		// after loading game content
		SceneManager.LoadScene ("MenuScene");
	}

	public void TogglePause()
	{
		pausePanGO = GameObject.FindGameObjectWithTag ("pauseGO");
		Debug.Log ("toggle pause called");
		timer = GameObject.Find ("Timer").GetComponent<Timer> ();
		isPaused = !isPaused;
		// pause timer
		if (isPaused) 
		{
			Debug.Log ("We are now paused");
			// we are now paused
			// pause timer, set panel to active
			pausePanGO.SetActive(true);

		}
		else 
		{
			Debug.Log ("unpause the game please");
			// unpause game, unpause timer
			// set panel to inactive
			pausePanGO.SetActive(false);
		}
	}


	public void RestartLevel() 
	{
		Debug.Log ("CHECK HERE PLS BE 1 ------ \n");
		Debug.Log (scoreManager.CurrentLevel);
	}

	public void NextLevel() 
	{

		Debug.Log ("CHECK HERE PLS BE 1 ------ \n");
		Debug.Log (scoreManager.CurrentLevel);

		Debug.Log ("CHECK HERE PLS BE 2?? load if after pls ------ \n");
		Debug.Log (scoreManager.CurrentLevel+ 1);
	}


}
