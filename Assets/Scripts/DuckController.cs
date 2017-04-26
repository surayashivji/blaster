using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DuckController : MonoBehaviour {

	public float moveSpeed;
	private Vector3 moveDirection;
	public Vector3 a, b;
	public float x1, x2;

	// time it takes for target to go into fire mode
	public float timeToFireMode = 3f;

	public float timeToDeath = 5.0f;

	// fire particle system
	public GameObject fireParticlePrefab;

	// current fire game object
	private GameObject currentFireParticle;

	// return true if target is burning
	public static bool targetBurning;

	// wet duck prefab
	public GameObject wetDuckPrefab; 

	// current wet duck prefab
	private GameObject currentwetDuckPrefab;

	// dead duck prefab
	public GameObject deadDuckPrefab;

	// current dead duck prefab
	private GameObject currentdeadDuckPrefab;

	private ScoreManager scoreManager;

	[SerializeField]
	private PolygonCollider2D[] colliders;
	private int currentColliderIndex = 0;
	private Transform spawnPoint;


	public void SetColliderForSprite( int spriteNum )
	{
		colliders[currentColliderIndex].enabled = false;
		currentColliderIndex = spriteNum;
		colliders[currentColliderIndex].enabled = true;
	}

	void Update()
	{
		Vector3 currentPosition = transform.position;

		Vector3 moveToward = new Vector3(Random.Range(-100f, 100f), Random.Range(-50f, 50f), 0) * moveSpeed;
		moveDirection = moveToward - currentPosition;
		moveDirection.z = 0;
		moveDirection.Normalize ();

		Vector3 target = moveDirection * moveSpeed + currentPosition;

		gameObject.transform.position = Vector3.Lerp(currentPosition, target, 1f);
	}
		
	void Start()
	{
		scoreManager = GameObject.Find("ScoreManager").GetComponent<ScoreManager>();
		moveDirection = Vector3.left;
		spawnPoint = GameObject.Find("SpawnPoint").transform;
		targetBurning = false;
		StartCoroutine(SetTargetOnFire(timeToFireMode, this.gameObject));
		StartCoroutine(KillTarget(timeToDeath, this.gameObject));
	}

	private IEnumerator SetTargetOnFire(float seconds, GameObject obj) 
	{
		yield return new WaitForSeconds(seconds);
		if (obj != null) {
			while (GameManager.Instance.isPaused) 
			{
				yield return new WaitForSeconds(1);
			}
			targetBurning = true;
			currentFireParticle = Instantiate(fireParticlePrefab, obj.transform.position, Quaternion.identity);
			currentFireParticle.transform.localScale=new Vector3(.5f,1f,0.5f);
			currentFireParticle.transform.parent = obj.transform;
		} else {
			// object has already been killed
			yield break;
		}
	}
		
	void OnCollisionEnter(Collision collisionInfo)
	{
		if (collisionInfo.collider.tag == "sphere") {
			Debug.Log ("Bullet hit duck");
			loadWetDuck();
			AddToScore (80);
			if (targetBurning) {
				AddToScore (50);
			}
			Destroy (this.gameObject);
		}
	}
		
	void OnBecameInvisible()
	{ 
		if (Camera.main == null)
		{
			Debug.Log("camera is null");
			return;
		}
		Destroy (this.gameObject);
	}

	private IEnumerator KillTarget(float seconds, GameObject obj) 
	{
		Debug.Log ("We know the duck is alive");
		yield return new WaitForSeconds(seconds);
		if (obj != null) {
			while (GameManager.Instance.isPaused) 
			{
				yield return new WaitForSeconds(1);
			}
			Debug.Log ("duck hasn't been killed by sphere yet, so destroy");
			loadDeadDuck ();
			Destroy (obj);
//			SceneManager.LoadScene("GameOver");
			PrepareForNextLevel (false);

		} else {
//			SceneManager.LoadScene("WinLevel");
			PrepareForNextLevel (true);
			yield break;

		}
	}

	private void loadWetDuck()
	{
		currentwetDuckPrefab = Instantiate(wetDuckPrefab, transform.position, transform.rotation);
		Debug.Log("Instantiated a wet Duck at" + currentwetDuckPrefab.transform.position);
	}

	private void loadDeadDuck()
	{
		currentdeadDuckPrefab = Instantiate(deadDuckPrefab, transform.position, transform.rotation);
		Debug.Log("Instantiated a dead Duck at" + currentdeadDuckPrefab.transform.position);

	}

	private void EnforceBounds()
	{
		Vector3 newPosition = transform.position; 
		Camera mainCamera = Camera.main;
		Vector3 cameraPosition = mainCamera.transform.position;

		float xDist = mainCamera.aspect * mainCamera.orthographicSize; 
		float xMax = cameraPosition.x + xDist;
		float xMin = cameraPosition.x - xDist;

		if ( newPosition.x < xMin || newPosition.x > xMax ) {
			newPosition.x = Mathf.Clamp( newPosition.x, xMin, xMax );
			moveDirection.x = -moveDirection.x;
		}

		float yMax = mainCamera.orthographicSize;

		if (newPosition.y < -yMax || newPosition.y > yMax) {
			newPosition.y = Mathf.Clamp( newPosition.y, -yMax, yMax );
			moveDirection.y = -moveDirection.y;
		}
			
		transform.position = newPosition;
	}

	#region SCORE_MANAGER_ACCESSORS

	public void AddToScore(int val)
	{
		scoreManager.UpdateScore (val);
	}

	public void PrepareForNextLevel(bool didWin)
	{
		scoreManager.SaveGameState (didWin);
	}

	#endregion // SCORE_MANAGER_ACCESSORS

}