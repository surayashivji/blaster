using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsManager : MonoBehaviour {

	// references to UI Controls
	public Button musicButton;
	public Button soundButton;

	// possible sprites for toggle
	public Sprite targetSprite;
	public Sprite graySprite;

	private GameSettings gameSettings;

	void Awake() {
		gameSettings = new GameSettings ();

		// initalize sprites according to game setting values
		SetButtonImage (musicButton, gameSettings.musicOn);
		SetButtonImage (soundButton, gameSettings.soundOn);
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

	/// <summary>
	/// Fired when the background music toggle is clicked
	/// </summary>
	public void OnMusicToggle() {
		gameSettings.musicOn = !gameSettings.musicOn;
		SetButtonImage (musicButton, gameSettings.musicOn);
	}

	/// <summary>
	/// Fired when the song toggle is clicked
	/// </summary>
	public void OnSoundToggle() {
		gameSettings.soundOn = !gameSettings.soundOn;
		SetButtonImage (soundButton, gameSettings.soundOn);
	}

	/// <summary>
	/// Fired when the user resets his/her game progress
	/// Clears all achivement progress and deletes all player preferences
	/// </summary>
	public void OnResetClicked() {
		PlayerPrefs.DeleteAll();
	}

	#endregion
}
