      





using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuckController : MonoBehaviour {

	public float moveSpeed;
	private Vector3 moveDirection;
	public Vector3 a, b;
	public float x1, x2;
	public float timeToDeath = 30.0f;

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

		Vector3 moveToward = new Vector3(Random.Range(-10f, 10f), Random.Range(-100f, 100f), 0) * moveSpeed;
		moveDirection = moveToward - currentPosition;
		moveDirection.z = 0;
		moveDirection.Normalize ();

		Vector3 target = moveDirection * moveSpeed + currentPosition;

		gameObject.transform.position = Vector3.Lerp(currentPosition, target, 1f);

		//Debug.Log ("radius of duck is" + gameObject.GetComponent<Renderer> ().bounds.extents.magnitude);

//				a = gameObject.transform.position;
//				x1 = a.x;
//				b = target;
//				x2 = b.x;
//				if (x2 < x1)
//					gameObject.GetComponent<SpriteRenderer>().flipX = true;
//				else
//					gameObject.GetComponent<SpriteRenderer>().flipX = false;



		//EnforceBounds ();
	
	
	}


	void Start(){
		moveDirection = Vector3.left;
		spawnPoint = GameObject.Find("SpawnPoint").transform;
		StartCoroutine(KillTarget(timeToDeath, this.gameObject));

	}


	void OnCollisionEnter(Collision collisionInfo)
	{
		if (collisionInfo.collider.tag == "sphere") {
			Debug.Log ("Bullet hit duck");
			Destroy (gameObject);
		}
	}

	void OnCollisionStay(Collision collisionInfo)
	{
		print(gameObject.name + " and " + collisionInfo.collider.name + " are still colliding");
	}

	void OnCollisionExit(Collision collisionInfo)
	{
		print(gameObject.name + " and " + collisionInfo.collider.name + " are no longer colliding");
	}

	void OnBecameInvisible()
	{ 
		Destroy(gameObject);
	}

	private IEnumerator KillTarget(float seconds, GameObject obj) {
		Debug.Log ("We know the duck is alive");
		yield return new WaitForSeconds(seconds);
		if (obj != null) {
			// target has not been shot with sphere
			// destroy target object and particle
			// GAME OVER
			Debug.Log ("duck hasn't been killed by sphere yet, so destroy");
			Destroy (obj);
			Application.LoadLevel ("GameOver");
		} else {
			// target has already been destroyed by user
			Application.LoadLevel("WinLevel");
			yield break;

		}
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
