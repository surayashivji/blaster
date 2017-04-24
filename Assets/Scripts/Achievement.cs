using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Achievement {

	#region PRIVATE_VARIABLES

	private string name;
	private string description;
	private bool unlocked;
	private int spriteIndex;
	// reference to achievement in game world
	private GameObject achivementReference;

	#endregion // PRIVATE_VARIABLES

	public string Name
	{
		get { return name; }
		set { name = value; }
	}

	public string Description
	{
		get { return description; }
		set { description = value; }
	}

	public bool Unlocked
	{
		get { return unlocked; }
		set { unlocked = value; }
	}
		
	public int SpriteIndex
	{
		get { return spriteIndex; }
		set { spriteIndex = value; }
	}
		
	/// <summary>
	/// Constructs an achivement object with a name (title), description, icon sprite index,
	/// and reference to achivement game object it will attach to
	/// </summary>
	public Achievement(string name, string description, int index, GameObject reference) 
	{
		this.name = name;
		this.description = description;
		this.unlocked = false;
		this.spriteIndex = index;
		this.achivementReference = reference;
		LoadAchievement ();
	}

	/// <summary>
	/// @return true if the achivement isn't unlocked; otherwise, false
	/// </summary>
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

	/// <summary>
	/// Persists each avhivement to player preferences
	/// </summary>
	public void PersistAchievement(bool value) 
	{
		unlocked = value;
		// set whether achievement has been received
		PlayerPrefs.SetInt(name, value ? 1 : 0);
		PlayerPrefs.Save ();
	}

	/// <summary>
	/// Load achivement info from player preferences
	/// </summary>
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
