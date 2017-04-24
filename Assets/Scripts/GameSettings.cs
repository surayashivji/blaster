using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameSettings {

	#region PRIVATE_VARIABLES

	private bool _musicOn;
	private bool _soundOn;

	#endregion

	public GameSettings() 
	{
		_musicOn = true;
		_soundOn = true;
	}

	public bool musicOn 
	{
		get { return _musicOn; }
		set 
		{  
			_musicOn = value;
			if (value) {
				// set the background music on
				GameObject.Find("BackgroundMusic").GetComponent<AudioSource>().Play();
			} 
			else {
				// set the background music off
				GameObject.Find("BackgroundMusic").GetComponent<AudioSource>().Stop();
			}
		}
	}

	public bool soundOn 
	{
		get { return _soundOn; }
		set 
		{  
			_soundOn = value;
		}
	}
}
