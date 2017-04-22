using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameSettings {

	private bool _musicOn;
	private bool _soundOn;
	private bool _colorBlindOn;

	public GameSettings() 
	{
		_musicOn = true;
		_soundOn = true;
		_colorBlindOn = false;
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

	public bool colorBlindOn 
	{
		get { return _colorBlindOn; }
		set 
		{  
			_colorBlindOn = value;
			if (value) {
				// set color blind mode on
			} 
			else {
				// set color blind mode off
			}
		}
	}
}
