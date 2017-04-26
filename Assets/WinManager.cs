using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinManager : MonoBehaviour {

	public void NextLevel()
	{
		GameManager.Instance.NextLevel ();
	}

	public void RestartLevel()
	{
		GameManager.Instance.RestartLevel ();
	}
}
