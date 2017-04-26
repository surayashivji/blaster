using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour {

	// Singleton GameManager
	public static GameManager Instance { set; get; }

	public bool isPaused;

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

	public void RestartLevel() 
	{
		Debug.Log ("CHECK HERE PLS BE 1 ------ \n");
		Debug.Log (ScoreManager.Instance.CurrentLevel);
		SceneManager.LoadScene ("Level" + ScoreManager.Instance.CurrentLevel);
	}

	public void NextLevel() 
	{
//		Debug.Log ("CHECK HERE PLS BE 2?? load if after pls ------ \n");
//		Debug.Log (scoreManager.CurrentLevel+ 1);
		if (ScoreManager.Instance.CurrentLevel < 4) {
			SceneManager.LoadScene ("Level" + ScoreManager.Instance.CurrentLevel + 1);
		} else 
		{
			// user beat all the levels!
		}
	}


}
