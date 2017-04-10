      





using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuckController : MonoBehaviour {

	public float moveSpeed;
	private Vector3 moveDirection;
	public Vector3 a, b;
	public float x1, x2;
	// time it takes for target to go into fire mode
	public float timeToFireMode = 3.0f;

	public float timeToDeath = 30.0f;

	// fire particle system
	public GameObject fireParticlePrefab;

	// current fire game object
	private GameObject currentFireParticle;

	// return true if target is burning
	public static bool targetBurning;

	// wet duck prefab
	public GameObject wetDuckPrefab; 

	// current wet duck prefab
	public GameObject currentwetDuckPrefab;

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



	void Update(){
	
		Vector3 currentPosition = transform.position;

		Vector3 moveToward = new Vector3(Random.Range(-100f, 100f), Random.Range(-50f, 50f), 0) * moveSpeed;
		moveDirection = moveToward - currentPosition;
		moveDirection.z = 0;
		moveDirection.Normalize ();

		Vector3 target = moveDirection * moveSpeed + currentPosition;

		gameObject.transform.position = Vector3.Lerp(currentPosition, target, 1f);

	
	
	}


	void Start(){
		moveDirection = Vector3.left;
		spawnPoint = GameObject.Find("SpawnPoint").transform;
		targetBurning = false;
		StartCoroutine(SetTargetOnFire(timeToFireMode, this.gameObject));
		StartCoroutine(KillTarget(timeToDeath, this.gameObject));

	}

	private IEnumerator SetTargetOnFire(float seconds, GameObject obj) {
		Debug.Log ("Target is normal, wait for seconds before setting on fire");
		yield return new WaitForSeconds(seconds);
		Debug.Log ("set target on fire if it hasn't already been shot at");
		if (obj != null) {
			targetBurning = true;
			currentFireParticle = Instantiate(fireParticlePrefab, obj.transform.position, Quaternion.identity);
			currentFireParticle.transform.localScale=new Vector3(.5f,1f,0.5f);
			currentFireParticle.transform.parent = obj.transform;
		} else {
			// object has already been killed
			Debug.Log("this target has already been killed no fire needed");
			yield break;
		}
	}


	void OnCollisionEnter(Collision collisionInfo)
	{
		if (collisionInfo.collider.tag == "sphere") {
			Debug.Log ("Bullet hit duck");
			Instantiate (wetDuckPrefab,this.gameObject.transform.position,Quaternion.identity);
		}
	}
		

	void OnBecameInvisible()
	{ 
		if (Camera.main == null){
			Debug.Log("camera is null");
			return;
		}
		
		float yMax = Camera.main.orthographicSize - 0.5f;
		transform.position = new Vector3( spawnPoint.position.x, 
			Random.Range(-yMax, yMax), 
			transform.position.z );
		Debug.Log ("duck is invisible");
	}

	private IEnumerator KillTarget(float seconds, GameObject obj) {
		Debug.Log ("We know the duck is alive");
		yield return new WaitForSeconds(seconds);
		if (obj != null) {
			// target has not been shot with sphere
			// destroy target object and particle
			// GAME OVER
			Debug.Log ("duck hasn't been killed by sphere yet, so destroy");
			currentwetDuckPrefab = Instantiate (wetDuckPrefab,obj.transform.position,Quaternion.identity);
			Destroy (obj);
//			Application.LoadLevel ("GameOver");
		} else {
			// target has already been destroyed by user
			Application.LoadLevel("WinLevel");
			yield break;

		}
	} 

	private void EnforceBounds()
	{
		// 1
		Vector3 newPosition = transform.position; 
		Camera mainCamera = Camera.main;
		Vector3 cameraPosition = mainCamera.transform.position;

		// 2
		float xDist = mainCamera.aspect * mainCamera.orthographicSize; 
		float xMax = cameraPosition.x + xDist;
		float xMin = cameraPosition.x - xDist;

		// 3
		if ( newPosition.x < xMin || newPosition.x > xMax ) {
			newPosition.x = Mathf.Clamp( newPosition.x, xMin, xMax );
			moveDirection.x = -moveDirection.x;
		}
		// TODO vertical bounds

		float yMax = mainCamera.orthographicSize;

		if (newPosition.y < -yMax || newPosition.y > yMax) {
			newPosition.y = Mathf.Clamp( newPosition.y, -yMax, yMax );
			moveDirection.y = -moveDirection.y;
		}


		// 4
		transform.position = newPosition;
	}
















//	void OnTriggerEnter2D( Collider2D other )
//	{
//
//		if(other.gameObject.tag == "sphere")
//		{ 
//			Destroy (gameObject);
//
//		}
//	}
//
//	void OnCollisionEnter2D (Collision2D other)
//	{
//		if(other.gameObject.tag == "Enemy")
//		{ 
//			rb.AddRelativeForce( Vector3.Reflect(gameObject.transform.position, gameObject.transform.position));
//			Debug.Log ("Hit other duck");
//
//		}
//	}




//	public Vector3 a, b;
//	public float deltaTime = 1f / 30f, currentTime, x1, x2;
//	public SpriteRenderer SR;
//	public Bounds bounds;
//	GameObject newSprite;
//
//	void Start()
//	{
//		InvokeRepeating("UpdateDestiny", 0f, 1f);
//		InvokeRepeating("Move", 0f, deltaTime);
//	}
//	void OnCollisionEnter2D(Collision2D col) // if object collides with screen bounds then change destination to middle of the screen.
//	{
//		b = new Vector3(0, 0, 0);
//	}
//
//	void Move()
//	{
//		currentTime += deltaTime;
//		gameObject.transform.position = Vector3.Lerp(a, b, currentTime);
//		Vector3 off = Util.ScreenBoundsCheck (bounds, BoundsTest.onScreen);
//
//
//	}
//
//	void UpdateDestiny()
//	{
//		currentTime = 0.0f;
//		a = gameObject.transform.position;
//		x1 = a.x;
//		b = gameObject.transform.position + new Vector3(Random.Range(-100f, 100f), Random.Range(-20f, 20f), 0);
//		x2 = b.x;
//		if (x2 < x1)
//			gameObject.GetComponent<SpriteRenderer>().flipX = true;
//		else
//			gameObject.GetComponent<SpriteRenderer>().flipX = false;
//	}

}
