using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AchievementManager : MonoBehaviour {

	public GameObject achievementPrefab;

	public Sprite[] iconSprites;
	public Sprite[] toggleSprites;

	public GameObject displayedAchievement;

	// collection of available achievements
	public Dictionary<string, Achievement> achievements = new Dictionary<string, Achievement>();

	public Sprite unlockedSprite;
	public Sprite starSprite;

	private static AchievementManager instance;

	public static AchievementManager Instance
	{
		get 
		{
			if(instance == null) 
			{
				instance = GameObject.FindObjectOfType<AchievementManager> ();
			}
			return AchievementManager.instance; 
		}
	}

	// Use this for initialization
	void Start () {
		// PlayerPrefs.DeleteAll();

		// instantiate all available achivements
		InstantiateAchievement ("AchievementList", "Amateur", "Complete the tutorial to unlock!", 0);
		InstantiateAchievement ("AchievementList", "Superstar", "Beat Level 1 to unlock!", 1);
		InstantiateAchievement ("AchievementList", "Trojan", "Beat Level 2 to unlock!", 2);
		InstantiateAchievement ("AchievementList", "Max Nikkas", "It's a secret!", 3);
	}

	// EarnAchievement("Amateur");
	/// <summary>
	/// Called when a user earns a specific achievement
	/// @param title: title of the achivement earned
	/// </summary>
	public void EarnAchievement(string title) 
	{
		if (achievements [title].canEarnAchievement()) 
		{
			achievements [title].Unlocked = true;
			// achivement earned, instantiate the achivement on the screen and then remove
//			GameObject a = (GameObject)Instantiate(displayedAchievement);
//			SetAchievementInfo ("EarnCanvas", a, title);
		}
	}

	/// <summary>
	/// Creates an achivement based on a parent in the hierarchy, title, description, and icon sprite index
	/// </summary>
	public void InstantiateAchievement(string parent, string title, string description, int spriteIndex)
	{
		// create new achievement
		GameObject a = (GameObject)Instantiate (achievementPrefab);
		Achievement newAchievement = new Achievement (title, description, spriteIndex, a); 
		achievements.Add (title, newAchievement);
		SetAchievementInfo (parent, a, title);
	}

	/// <summary>
	/// Sets the visual information of an achivement based on the title
	/// </summary>
	public void SetAchievementInfo(string parent, GameObject a, string title) {
		a.transform.SetParent (GameObject.Find (parent).transform);
		// set achievement info
		a.transform.localScale = new Vector3 (1, 1, 1); // set scale back to 1
		a.transform.GetChild (0).GetComponent<Text> ().text = title;
		a.transform.GetChild (1).GetComponent<Text> ().text = achievements[title].Description;
		a.transform.GetChild (2).GetComponent<Image> ().sprite = iconSprites [achievements[title].SpriteIndex];
		a.transform.GetChild (3).GetComponent<Image>().sprite = toggleSprites [0];
	}
}