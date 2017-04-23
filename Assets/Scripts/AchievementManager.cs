using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AchievementManager : MonoBehaviour {

	public GameObject achievementPrefab;

	public Sprite[] iconSprites;

	public GameObject displayedAchievement;

	// collection of available achievements
	public Dictionary<string, Achievement> achievements = new Dictionary<string, Achievement>();

	public Sprite unlockedSprite;

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
		//PlayerPrefs.DeleteAll();
		InstantiateAchievement ("AchievementList", "Amateur", "Beat Level 1 to unlock!", 0);
	}

	void Update() {
// Example of setting an achievement for earning
//		if (Input.GetKeyDown (KeyCode.W)) {
//			EarnAchievement("Amateur");
//		}
		// 
	}

	public void EarnAchievement(string title) 
	{
		if (achievements [title].canEarnAchievement()) 
		{
			// achivement earned, instantiate the achivement on the screen and then remove
			GameObject a = (GameObject)Instantiate(displayedAchievement);
			SetAchievementInfo ("EarnCanvas", a, title);
		}
	}

	public void InstantiateAchievement(string parent, string title, string description, int spriteIndex)
	{
		// create new achievement
		GameObject a = (GameObject)Instantiate (achievementPrefab);
		Achievement newAchievement = new Achievement (title, description, spriteIndex, a); 
		achievements.Add (title, newAchievement);
		SetAchievementInfo (parent, a, title);
	}

	public void SetAchievementInfo(string parent, GameObject a, string title) {
		a.transform.SetParent (GameObject.Find (parent).transform);
		// set achievement info
		a.transform.localScale = new Vector3 (1, 1, 1); // set scale back to 1
		a.transform.GetChild (0).GetComponent<Text> ().text = title;
		a.transform.GetChild (1).GetComponent<Text> ().text = achievements[title].Description;
		a.transform.GetChild (2).GetComponent<Image> ().sprite = iconSprites [achievements[title].SpriteIndex];
	}
}

// EarnAchievement("Amateur");