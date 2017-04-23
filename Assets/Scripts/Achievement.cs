using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Achievement {
	private string name;
	public string Name
	{
		get { return name; }
		set { name = value; }
	}

	private string description;
	public string Description
	{
		get { return description; }
		set { description = value; }
	}

	private bool unlocked;
	public bool Unlocked
	{
		get { return unlocked; }
		set { unlocked = value; }
	}
		
	private int spriteIndex;
	public int SpriteIndex
	{
		get { return spriteIndex; }
		set { spriteIndex = value; }
	}

	// reference to achievement in game world
	private GameObject achivementReference;

	public Achievement(string name, string description, int index, GameObject reference) 
	{
		this.name = name;
		this.description = description;
		this.unlocked = false;
		this.spriteIndex = index;
		this.achivementReference = reference;
		LoadAchievement ();
	}

	// if achivement isn't unlocked, return true; otherwise, false
	public bool canEarnAchievement() 
	{
		if (!unlocked) 
		{
			achivementReference.GetComponent<Image> ().sprite = AchievementManager.Instance.unlockedSprite;
			achivementReference.transform.GetChild (3).GetComponent<Image>().sprite = AchievementManager.Instance.starSprite;
			PersistAchievement (true);
			return true;
		}
		return false;
	}

	// save achivement to player preferences for persistence
	public void PersistAchievement(bool value) 
	{
		unlocked = value;
		// set whether achievement has been received
		PlayerPrefs.SetInt(name, value ? 1 : 0);
		PlayerPrefs.Save ();
	}

	// load achivement info from player preferences
	public void LoadAchievement()
	{
		unlocked = PlayerPrefs.GetInt (name) == 1 ? true : false;
		if (unlocked) 
		{
			// change menu sprite to orange
			achivementReference.GetComponent<Image> ().sprite = AchievementManager.Instance.unlockedSprite;
			// change toggle to star
			achivementReference.transform.GetChild (3).GetComponent<Image>().sprite = AchievementManager.Instance.starSprite;
		}
	}
}
