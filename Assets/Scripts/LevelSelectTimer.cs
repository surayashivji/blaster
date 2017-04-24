using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LevelSelectTimer : MonoBehaviour {

	int score = 500;

	// Use this for initialization
	void Start () {
		PlayerPrefs.SetInt ("Level2", 1);
		PlayerPrefs.SetInt ("Level1_score", score);
		PlayerPrefs.Save ();
		Debug.Log ("b somethin");
		Debug.Log (PlayerPrefs.GetInt ("Level2"));
		StartCoroutine (Time ());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private IEnumerator Time()
	{
		yield return new WaitForSeconds (2);
		SceneManager.LoadScene (7);
	}
}
