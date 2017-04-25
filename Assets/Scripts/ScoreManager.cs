using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

	private int score;
	private int currentLevel;
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

	/// <summary>
	/// Configures the next level so that it is unlocked and active
	/// Persists the users level in order to allocate stars
	/// </summary>
	public void SaveGameState()
	{
		int nextLevel = currentLevel + 1;
		if (nextLevel < currentLevel) {
			// unlock next level, make it active
			PlayerPrefs.SetInt ("Level" + nextLevel.ToString (), 1);
		} 
		PlayerPrefs.SetInt ("Level" + currentLevel.ToString () + "_score", score);
		PlayerPrefs.Save ();
	}

	#endregion // PUBLIC_SCORE_METHODS
}
