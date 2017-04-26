using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WinOrLose : MonoBehaviour {

	private GameObject scoreManagerGO;

	private ScoreManager scoreManager;
	private int currLevel;

	void Awake()
	{
		Debug.Log ("yee");
		SceneManager.sceneLoaded += ConfigureWinOrLose;
	}

	void Start () {
		Debug.Log ("bbs");
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

		Debug.Log ("CHECK HERE PLS BE 1 ------ \n");
		Debug.Log (currLevel);

		Debug.Log ("CHECK HERE PLS BE 2?? load if after pls ------ \n");
		Debug.Log (currLevel + 1);
	}

	void Destroy()
	{
		SceneManager.sceneLoaded -= ConfigureWinOrLose;
	}

	private void ConfigureWinOrLose(Scene newScene, LoadSceneMode loadMode)
	{
		Debug.Log ("pls");

		Scene currentScene = SceneManager.GetActiveScene (); // WinLevel || GameOver

		if (currentScene.name == "WinLevel") 
		{
			Debug.Log ("Kanye");
			Debug.Log ("We are on win scene");
			Button nextLevelBtn = GameObject.Find ("NextLevelButton").GetComponent<Button> ();
			nextLevelBtn.onClick.AddListener (() => {
				NextLevel();
			});
//			nextLevelBtn.onClick.AddListener (NextLevel);
		} 
		else if(currentScene.name == "GameOver")
		{
			Debug.Log ("Zayn");
			Debug.Log ("We are on game over scene");
			Button restartBtn = GameObject.Find ("RestartButton").GetComponent<Button> ();
//			restartBtn.onClick.AddListener (RestartLevel);
			restartBtn.onClick.AddListener (() => {
				RestartLevel();
			});
		}

		Destroy ();
	}


}
