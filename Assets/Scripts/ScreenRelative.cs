using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenRelative : MonoBehaviour {

	public enum ScreenEdge {LEFT, RIGHT, TOP, BOTTOM};
	public ScreenEdge screenEdge;
	public float yOffset;
	public float xOffset;


	// Use this for initialization
	void Start () 
	{

		Vector3 newPosition = transform.position;
		Camera camera = Camera.main;

		// 2
		switch(screenEdge)
		{

		case ScreenEdge.LEFT:
			newPosition.x = -camera.aspect * camera.orthographicSize + xOffset;
			newPosition.y = yOffset;
			break;
		case ScreenEdge.BOTTOM:
			newPosition.y = -camera.orthographicSize + yOffset;
			newPosition.x = xOffset;
			break;

		// 3
		case ScreenEdge.RIGHT:
			newPosition.x = camera.aspect * camera.orthographicSize + xOffset;
			newPosition.y = yOffset;
			break;

			// 4
		case ScreenEdge.TOP:
			newPosition.y = camera.orthographicSize + yOffset;
			newPosition.x = xOffset;
			break;
		}
		// 5
		transform.position = newPosition;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
