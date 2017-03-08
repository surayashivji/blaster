using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour {

	public void onPlay() {
		GameManager.Instance.ChangeScene ("InitialScene");
	}
}
