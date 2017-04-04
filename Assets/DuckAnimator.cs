using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuckAnimator : MonoBehaviour {

	public Sprite[] sprites;
	public float framesPerSecond;
	private SpriteRenderer spriteRenderer;

	// Use this for initialization
	void Start () {
		spriteRenderer = gameObject.GetComponent<SpriteRenderer> ();		
	}
	
	// Update is called once per frame
	void Update () {

		//calculate number of frames that should render per second

		int index = (int)(Time.timeSinceLevelLoad * framesPerSecond);
		index = index % sprites.Length;
		spriteRenderer.sprite = sprites[ index ];

		
	}
}
