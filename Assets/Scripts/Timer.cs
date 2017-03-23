using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

	protected string currentLevel;
	protected int worldIndex;
	protected int levelIndex;

	private Text timerText;
	private float myTimer = 30;
	private bool increaseTimer = true;

	// Use this for initialization
	void Start () {
		currentLevel = Application.loadedLevelName;
		Debug.Log ("Current Level is" + currentLevel);

		timerText = GetComponent<Text> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (increaseTimer) {
			myTimer -= Time.deltaTime;
			timerText.text = myTimer.ToString ("f0");
		}
		if(myTimer < 0) {
			increaseTimer = false;
			levelPassed ();
		}
	}

	private void levelPassed() {
		Debug.Log ("TIME over, level passed!!!");
		GameManager.Instance.ChangeScene ("WinLevel");
	}
//
//	protected void  UnlockLevels (){
//		  //set the playerprefs value of next level to 1 to unlock
//		  for(int i = 0; i < LockLevel.worlds; i++){
//			   for(int j = 1; j < LockLevel.levels; j++){               
//				    if(currentLevel == "Level"+(i+1).ToString() +"." +j.ToString()){
//					     worldIndex  = (i+1);
//					     levelIndex  = (j+1);
//					     PlayerPrefs.SetInt("level"+worldIndex.ToString() +":" +levelIndex.ToString(),1);
//					    }
//				   }
//			  }
//		  //load the World1 level 
//		  Application.LoadLevel("LevelScene");
//		 }

}