using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseManager : MonoBehaviour {

	public GameObject pausePanel;

	public void togglePauseButton()
	{
//		pausePanGO = GameObject.FindGameObjectWithTag ("pauseGO");
		Debug.Log ("toggle pause called");
//		timer = GameObject.Find ("Timer").GetComponent<Timer> ();
		GameManager.Instance.isPaused = !GameManager.Instance.isPaused;
		// pause timer
		if (GameManager.Instance.isPaused) 
		{
			Debug.Log ("We are now paused");
			// we are now paused
			// pause timer, set panel to active
			pausePanel.SetActive(true);

		}
		else 
		{
			Debug.Log ("unpause the game please");
			// unpause game, unpause timer
			// set panel to inactive
			pausePanel.SetActive(false);
		}
	}

}
