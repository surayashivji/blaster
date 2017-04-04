      





using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuckController : MonoBehaviour {

	public float moveSpeed;
	private Vector3 moveDirection;
	public Vector3 a, b;
	public float x1, x2;


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

	}

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
