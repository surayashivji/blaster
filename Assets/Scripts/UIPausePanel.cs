using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class UIPausePanel : MonoBehaviour {

	public void RestartTapped() {
	
		GameManager.Instance.RestartLevel ();
	}

	public void MenuTapped() {
		GameManager.Instance.ReturnToMenu ();
	}

}
