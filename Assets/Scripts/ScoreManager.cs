using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

	public static ScoreManager Instance { set; get; }

	private int score;

	private int currentLevel;
	public int CurrentLevel
	{
		get { return currentLevel; }
	}

	private int numLevels = 4;

	public Text scoreText;

	// Use this for initialization
	void Start () {
		
		ConfigureCurrentLevel ();

		// reset score
		score = 0;
	}

	/// <summary>
	/// Configure the current level
	/// </summary>
	private void ConfigureCurrentLevel()
	{
		for (int x = 1; x < numLevels; x++) 
		{
			if (SceneManager.GetActiveScene ().name == "Level" + x) 
			{
				currentLevel = x;
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		scoreText.text = score.ToString();
	}

	#region PUBLIC_SCORE_METHODS

	/// <summary>
	/// Update text score
	/// @param amt: amount of score to add
	/// </summary>
	public void UpdateScore(int amt)
	{
		score += amt;
	}

	#endregion // PUBLIC_SCORE_METHODS

	/// <summary>
	/// Configures the next level so that it is unlocked and active
	/// Persists the users level in order to allocate stars
	/// @param win: true if the user has won the current level; otherwise, false
	/// </summary>
	public void SaveGameState(bool win)
	{
		Debug.Log ("Saving game state!");
		int nextLevel = currentLevel + 1;
		Debug.Log ("next level is " + nextLevel);
		if (nextLevel < numLevels) {
			// unlock next level, make it active
			PlayerPrefs.SetInt ("Level" + nextLevel.ToString (), 1);
			Debug.Log(PlayerPrefs.GetInt("Level" + nextLevel.ToString ()));
		}
		// check if a score has already been saved
		string key = "Level" + currentLevel.ToString () + "_score";
		if (PlayerPrefs.HasKey (key)) 
		{
			// user has already stored a score
			// retrieve the score to see if it is greater than *score*
			if (PlayerPrefs.GetInt (key) < score) 
			{
				PlayerPrefs.SetInt (key, score);
				PlayerPrefs.Save ();
			}
		}
		if (win) {
			if (currentLevel == 1) {
				Debug.Log ("ACH SHOUD B HERE :/");
				//AchievementManager.Instance.EarnAchievement ("Amateur");
			} else if (currentLevel == 2) {
				
			} else if (currentLevel == 3) {
				
			} else if (currentLevel == 4) {
				
			}
			SceneManager.LoadScene ("WinLevel");
		} else {
			SceneManager.LoadScene("GameOver");
		}
	}
}
