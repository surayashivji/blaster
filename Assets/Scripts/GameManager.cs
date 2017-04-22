using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour {

	// Singleton GameManager
	public static GameManager Instance { set; get; }

	private void Awake() 
	{
		Instance = this;
		DontDestroyOnLoad (this.gameObject);

		// after loading game content
		SceneManager.LoadScene ("MenuScene");
	}
}
