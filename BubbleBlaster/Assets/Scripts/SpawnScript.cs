using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class SpawnScript : MonoBehaviour {

	public GameObject targetPrefab;

	// number of targets
	public int numOfInstances;

	public float timeToSpawn = 3;

	public float distanceFromCamera = 60;

	// padding between targets
	public float padding = 0.1f;

	private Dictionary<Vector3, GameObject> targetDict = new Dictionary<Vector3, GameObject>();

	// positions where the target can be placed on the screen (within bounds, not overlapping with other targets)
	private List<Vector3> availablePositions = new List<Vector3>();

	private float zPos = 0;


	void Start () {
		CalculateAvailablePositions ();
		StartCoroutine (Spawn ());
	}
		
	private void CalculateAvailablePositions() {
		// find discrete x & y positions where the target prefab can be placed without overlapping with other targets
		Camera camera = Camera.main;
		Vector3 bottomLeft = camera.ViewportToWorldPoint(new Vector3(0,0,distanceFromCamera));
		Vector3 topRight = camera.ViewportToWorldPoint (new Vector3 (1, 1, distanceFromCamera));
		float minX = bottomLeft.x;
		float maxX = topRight.x;
		float minY = bottomLeft.y;
		float maxY = topRight.y;

		// pick Z value from any vector
		zPos = bottomLeft.z;

		// create a single instance of the prefab for calculations
		var target = Instantiate (targetPrefab) as GameObject;

		// if the target has a box collider, calculate the offset required to keep the object on screen
		var collider = target.GetComponent<BoxCollider>();

		Vector2 objectSize = Vector2.zero;

		if (collider != null) {
			Vector2 sizeOffset = Vector2.zero;
			Vector2 colliderCenterOffset = Vector2.zero;

			var t = target.transform;

			colliderCenterOffset = -collider.center;
			colliderCenterOffset.x *= t.localScale.x;
			colliderCenterOffset.y *= t.localScale.y;

			sizeOffset.x = collider.size.x * 0.5f * t.localScale.x;
			sizeOffset.y = collider.size.y * 0.5f * t.localScale.y;

			objectSize = new Vector2(collider.size.x *t.localScale.x, collider.size.y * t.localScale.y);

			// recalculate min & max positions
			minX = minX + colliderCenterOffset.x + sizeOffset.x;
			maxX = maxX + colliderCenterOffset.x - sizeOffset.x;
			minY = minY + colliderCenterOffset.y + sizeOffset.y;
			maxY = maxY + colliderCenterOffset.y - sizeOffset.y;
		}

		// destroy the target instance
		Destroy(target);

		// create list of available positions
		for (float x = minX; x <= maxX; x += objectSize.x + padding) {
			for (float y = minY; y <= maxY; y += objectSize.y + padding) {
				availablePositions.Add(new Vector3(x,y,zPos));
			}
		}
	}

	private IEnumerator Spawn() {
		if (availablePositions.Count < numOfInstances) {
			Debug.LogError ("Number of prefabs requested is greater than available positions");
			yield return null;
		} else {
			while (targetDict.Count != numOfInstances) {
				var target = Instantiate (targetPrefab) as GameObject;
				SetPosition (target.transform);

				//add to list
				targetDict.Add (target.transform.position, target);
				yield return new WaitForSeconds(Random.Range(timeToSpawn, 2 * timeToSpawn));
			}
		}

	}

	private void SetPosition(Transform t) {
		Vector3 proposedPosition = availablePositions [Random.Range (0, availablePositions.Count)];
		availablePositions.Remove (proposedPosition);
		t.position = proposedPosition;
	}

	// add position where the target was just destroyed back into list of available positions
	public void ReclaimPosition(Vector3 position) {
		availablePositions.Add (position);
	}
}