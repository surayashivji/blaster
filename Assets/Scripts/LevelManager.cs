using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class LevelManager : MonoBehaviour {

	#region LEVEL_OBJECT
	[System.Serializable]
	public class Level
	{
		public string levelText;
		public int unlocked; 
		public bool isInteractable;
	}
	#endregion // LEVEL_OBJECT

	public GameObject button; 
	public Transform spacer;
	public List<Level> levels;


	void Start () {
		// PlayerPrefs.DeleteAll ();
		PopulateLevels ();
	}

	/// <summary>
	/// Fill in default info for each level (unlocked if not level 1, no earned stars)
	/// </summary>
	private void PopulateLevels()
	{
		foreach(var level in levels)
		{
			// instantiate a new level within the spacer
			GameObject levelButton = (GameObject)Instantiate (button);

			// set information for button
			LevelButton b = levelButton.GetComponent<LevelButton> ();
			b.levelNumberText.text = level.levelText;

			// read unlocked from player prefs
			if (PlayerPrefs.GetInt ("Level" + b.levelNumberText.text) == 1)
			{
				// set level to be unlocked
				level.unlocked = 1;
				level.isInteractable = true;
			}

			// set level manager button for unity editor
			b.buttonUnlocked = level.unlocked;
			b.GetComponent<Button>().interactable = level.isInteractable;
			b.GetComponent<Button> ().onClick.AddListener (() => LoadLevel (b.levelNumberText.text)); 

			// set number of earned stars according to score
			int currLevelIndex = int.Parse(b.levelNumberText.text);
			int persistedScore = PlayerPrefs.GetInt ("Level" + b.levelNumberText.text + "_score");

			switch (currLevelIndex) 
			{
				case 1: // level 1
					if (persistedScore > 200) 
					{
						b.star1.SetActive(true);
						if (persistedScore > 500) 
						{
							b.star2.SetActive(true);
							if (persistedScore > 700) 
							{
								b.star3.SetActive(true);
							}
						}
					}
					break;
				case 2: // level 2
					if (persistedScore > 300) 
					{
						b.star1.SetActive(true);
						if (persistedScore > 500) 
						{
							b.star2.SetActive(true);
							if (persistedScore > 650) 
							{
								b.star3.SetActive(true);
							}
						}
					}
					break;
				case 3: // level 3
					break;
				case 4: // level 4
					break;
				default:
					break;
			}

			// make level button prefab a child of the layout spacer
			levelButton.transform.SetParent (spacer);
		}
		SaveInitialValues ();
	}

	/// <summary>
	/// Persist default information for each level
	/// </summary>
	private void SaveInitialValues()
	{ 
		GameObject[] allButtons = GameObject.FindGameObjectsWithTag ("LevelButton");
		foreach (GameObject obj in allButtons) {
			LevelButton b = obj.GetComponent<LevelButton> ();
			PlayerPrefs.SetInt ("Level" + b.levelNumberText.text, b.buttonUnlocked);
			PlayerPrefs.Save ();
		}
	}
		
	/// <summary>
	/// Loads a level
	/// @param val: name of level to load
	/// </summary>
	void LoadLevel(string val)
	{
		GameManager.Instance.curLevelNum = int.Parse (val);
//		Application.LoadLevel (val);
		SceneManager.LoadScene ("Level" + val);
	}
}