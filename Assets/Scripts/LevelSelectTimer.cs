using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LevelSelectTimer : MonoBehaviour {

	int score = 500;
	private int numLevels = 4;
	private int currentLevel;

	// Use this for initialization
	void Start () {
		ConfigureCurrentLevel();
		StartCoroutine (Time ());
	}

	private IEnumerator Time()
	{
		yield return new WaitForSeconds (2);
		SceneManager.LoadScene (7);
	}

	private void ConfigureCurrentLevel()
	{
		for (int x = 1; x < numLevels; x++) 
		{
			if (SceneManager.GetActiveScene ().name == "Level" + x) 
			{
				currentLevel = x;
				SaveGameState ();
			}
		}
	}

	private void SaveGameState()
	{
		int nextLevel = currentLevel + 1;
		if (nextLevel < currentLevel) {
			// unlock next level, make it active
			PlayerPrefs.SetInt ("Level" + nextLevel.ToString (), 1);
			PlayerPrefs.SetInt ("Level" + currentLevel.ToString () + "_score", score);
			PlayerPrefs.Save ();
		} 
		else 
		{
			PlayerPrefs.SetInt ("Level" + currentLevel.ToString () + "_score", score);
			PlayerPrefs.Save ();
		}
	}
}
