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

	public int curLevelNum = 0;

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
		SceneManager.LoadScene ("Level" + curLevelNum);
	}

	public void NextLevel() 
	{
		if (curLevelNum < 4) {
			curLevelNum++;
			SceneManager.LoadScene ("Level" + curLevelNum);
		} else 
		{
			// user beat all the levels!
		}
	}


}
