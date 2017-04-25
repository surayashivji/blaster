using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TargetLogic : MonoBehaviour {

	// time it takes for target to go into fire mode
	 float timeToFireMode = 10.0f;

	// time it takes for target to go from fire mode to destruction
	 float timeToDeath = 10.0f;

	// fire particle system
	public GameObject fireParticlePrefab;

	// current fire game object
	private GameObject currentFireParticle;

	// return true if target is burning
	public static bool targetBurning;

	private ScoreManager scoreManager;

	private int numberOfTargetsLeft;

	// Use this for initialization
	void Start () {
		scoreManager = GameObject.Find("ScoreManager").GetComponent<ScoreManager>();
		targetBurning = false;
		numberOfTargetsLeft = GameObject.FindObjectOfType<SpawnScript> ().numOfInstances;
		Debug.Log ("num left - " + numberOfTargetsLeft);
		StartCoroutine(SetTargetOnFire(timeToFireMode, this.gameObject));
	}

	/// <summary>
	/// Sets the target on fire by attaching a fire particle system to the game object
	/// @param seconds: number of seconds before setting the target on fire
	/// @param obj: target object to set on fire
	/// </summary>
	private IEnumerator SetTargetOnFire(float seconds, GameObject obj) 
	{
		Debug.Log ("Target is normal, wait for seconds before setting on fire");
		yield return new WaitForSeconds(seconds);
		Debug.Log ("set target on fire if it hasn't already been shot at");
		if(true)
		{
			Debug.Log ("falseeeee");
			// target has already been killed
			numberOfTargetsLeft--;
			Debug.Log("this target has already been killed no fire needed");
			AddToScore (50); // add 50 extra points becayse the user destroyed it before fire
			Debug.Log ("added score 50 - target destroyed");
			reclaimPositon (obj);
			yield break;
		} 
		else 
		{
			Debug.Log ("truuuu");
			Debug.Log ("00");
			Debug.Log ("set target on fire because it has not been killed");
			// set target on fire because it has not been killed
			targetBurning = true;
			currentFireParticle = Instantiate(fireParticlePrefab, obj.transform.position, Quaternion.identity);
			StartCoroutine(KillTarget(timeToDeath, obj));
		}
	}

	/// <summary>
	/// Kills Target if it hasn't been destroyed
	/// @param seconds: number of seconds to wait before killing
	/// @param obj: target game object to be killed
	/// </summary>
	private IEnumerator KillTarget(float seconds, GameObject obj) 
	{
		Debug.Log ("We know the target is on fire");
		yield return new WaitForSeconds(seconds);
		Debug.Log (obj);
		if (!(obj == null || obj.Equals(null)))
		{
			// target has not been shot with sphere
			// destroy target object and particle
			// GAME OVER
			Debug.Log ("target hasn't been killed by sphere yet, so destroy");
			Debug.Log ("\n here ");
			reclaimPositon (obj);
			Destroy (obj);
			Destroy (currentFireParticle);
			SceneManager.LoadScene("GameOver");
		} 
		else
		{
			Debug.Log ("null - target has already been destroyed by user (After fire)");
			// target has already been destroyed by user (After fire)
			numberOfTargetsLeft--;
			Debug.Log ("num left now - " + numberOfTargetsLeft);
			if (numberOfTargetsLeft == 1) 
			{
				SceneManager.LoadScene("WinLevel");
				// Achievement #1 Earned
				AchievementManager.Instance.EarnAchievement("Amateur");
			}
			yield break;
		}
	} 

	/// <summary>
	/// After a target is hit by the user, the position it held is able to be used again
	/// @param obj: game object that was killed with the position we need to recycle back in
	/// </summary>
	private void reclaimPositon(GameObject obj) 
	{
		GameObject.FindObjectOfType<SpawnScript> ().ReclaimPosition (obj.transform.position);
	}

	public void destroyParticle() 
	{
		Destroy (this.currentFireParticle);
	}

	#region SCORE_MANAGER_ACCESSORS

	public void AddToScore(int val)
	{
		scoreManager.UpdateScore (val);
	}

	public void PrepareForNextLevel()
	{
		scoreManager.SaveGameState ();
	}

	#endregion // SCORE_MANAGER_ACCESSORS
}
