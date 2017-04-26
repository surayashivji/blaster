using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WinOrLose : MonoBehaviour {

	public GameObject scoreManagerGO;

	private ScoreManager scoreManager;
	private int currLevel;

	void Start () {

		Scene currentScene = SceneManager.GetActiveScene ();
		if (currentScene.name == "WinLevel") 
		{
			Debug.Log ("We are on win scene");
			Button gameOverBtn = GameObject.Find ("RestartButton").GetComponent<Button> ();
			gameOverBtn.onClick.AddListener (RestartLevel);
		} 
		else if(currentScene.name == "GameOver")
		{
			Debug.Log ("We are on game over scene");
			Button nextLevelBtn = GameObject.Find ("NextLevelButton").GetComponent<Button> ();
			nextLevelBtn.onClick.AddListener (NextLevel);
		}

		scoreManager = scoreManagerGO.GetComponent<ScoreManager> ();
		currLevel = scoreManager.CurrentLevel;
		DontDestroyOnLoad (this.gameObject);
	}

	public void RestartLevel() 
	{
		Debug.Log ("CHECK HERE PLS BE 1 ------ \n");
		Debug.Log (currLevel);
	}

	public void NextLevel() 
	{
		Debug.Log ("CHECK HERE PLS BE 2?? load if after pls ------ \n");
		Debug.Log (currLevel + 1);
	}
}
