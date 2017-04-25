using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour {

	// Singleton GameManager
	public static GameManager Instance { set; get; }

	public bool isPaused;

	private Timer timer;

	private void Awake() 
	{
		Instance = this;
		DontDestroyOnLoad (this.gameObject);
		isPaused = false;
		// after loading game content
		SceneManager.LoadScene ("MenuScene");
	}

	public void TogglePause()
	{
		Debug.Log ("toggle pause called");
		timer = GameObject.Find ("Timer").GetComponent<Timer> ();
		isPaused = !isPaused;
		// pause timer
		if (isPaused) 
		{
			Debug.Log ("We are now paused");
			// we are now paused
			// pause timer
			// set panel to active
			GameObject.Find ("PausePanel").SetActive(true);

		}
		else 
		{
			Debug.Log ("unpause the game please");
			// unpause game
			// unpause timer
			// set panel to inactive
			GameObject.Find ("PausePanel").SetActive(false);
		}
	}
}
