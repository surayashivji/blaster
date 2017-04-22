using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsManager : MonoBehaviour {

	// references to UI Controls
	public Button musicButton;
	public Button soundButton;
	public Button colorBlindButton;

	// possible sprites for toggle
	public Sprite targetSprite;
	public Sprite graySprite;

	private GameSettings gameSettings;

	void Awake() {
		gameSettings = new GameSettings ();

		// initalize sprites according to game setting values
		SetButtonImage (musicButton, gameSettings.musicOn);
		SetButtonImage (soundButton, gameSettings.soundOn);
		SetButtonImage (colorBlindButton, gameSettings.colorBlindOn);
	}

	public void SetButtonImage(Button btn, bool toggleValue) {
		if (toggleValue) {
			// toggle on - target button shows
			btn.image.sprite = targetSprite;
		} else {
			// toggle off - gray circle shows
			btn.image.sprite = graySprite;
		}
	}

	#region Setting Toggle Methods 

	// music toggle clicked
	public void OnMusicToggle() {
		gameSettings.musicOn = !gameSettings.musicOn;
		SetButtonImage (musicButton, gameSettings.musicOn);
	}

	// sound toggle clicked
	public void OnSoundToggle() {
		gameSettings.soundOn = !gameSettings.soundOn;
		SetButtonImage (soundButton, gameSettings.soundOn);
	}

	// color blind toggle clicked
	public void OnColorBlindToggle() {
		gameSettings.colorBlindOn = !gameSettings.colorBlindOn;
		SetButtonImage (colorBlindButton, gameSettings.colorBlindOn);
	}

	#endregion
}
