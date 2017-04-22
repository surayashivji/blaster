using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockLevel : MonoBehaviour {

	 public static int worlds = 1; // number of worlds
	 public static int levels = 3; // number of levels
	  
	 private int worldIndex;   
	 private int levelIndex;

	void Start ()
	{
		PlayerPrefs.DeleteAll(); // erase data on start
		LockLevels();   //call function LockLevels
	}
	  
	 // function to lock the levels
	 void  LockLevels ()
	{
		// loop thorugh all the levels of all the worlds
		for (int i = 0; i < worlds; i++)
		{
			for (int j = 1; j < levels; j++)
			{
				worldIndex  = (i+1);
				levelIndex  = (j+1);
				// create a PlayerPrefs of that particular level and world and set it's to 0, if no key of that name exists
				if(!PlayerPrefs.HasKey("level"+worldIndex.ToString() +":" +levelIndex.ToString()))
				{
					PlayerPrefs.SetInt("level"+worldIndex.ToString() +":" +levelIndex.ToString(),0);
				}
			}
		}
	}
}