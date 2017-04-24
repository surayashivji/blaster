using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class LevelManager : MonoBehaviour {

	[System.Serializable]
	public class Level 
	{
		public string levelText;
		public int unlocked; 
		public bool isInteractable;
	}

	public GameObject button; 
	public Transform spacer;
	public List<Level> levels;

	// Use this for initialization
	void Start () {
		// PlayerPrefs.DeleteAll ();
		PopulateLevels ();
	}

	void PopulateLevels()
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
			b.GetComponent<Button> ().onClick.AddListener (() => LoadLevel ("Level" + b.levelNumberText.text)); 

			if (PlayerPrefs.GetInt ("Level" + b.levelNumberText.text + "_score") > 0) 
			{
				// one star
				b.star1.SetActive(true);
			}

			if (PlayerPrefs.GetInt ("Level" + b.levelNumberText.text + "_score") > 200) 
			{
				// two stars
				b.star1.SetActive(true);
				b.star2.SetActive(true);
			}
			if (PlayerPrefs.GetInt ("Level" + b.levelNumberText.text + "_score") > 400) 
			{
				// 3 stars
				b.star1.SetActive(true);
				b.star2.SetActive(true);
				b.star3.SetActive(true);
			}

			levelButton.transform.SetParent (spacer);
		}
		SaveInitialValues ();
	}

	private void SaveInitialValues()
	{ 
		GameObject[] allButtons = GameObject.FindGameObjectsWithTag ("LevelButton");
		foreach (GameObject obj in allButtons) {
			LevelButton b = obj.GetComponent<LevelButton> ();
			PlayerPrefs.SetInt ("Level" + b.levelNumberText.text, b.buttonUnlocked);
			PlayerPrefs.Save ();
		}
	}

	void LoadLevel(string val)
	{
		Application.LoadLevel (val);
	}
}
