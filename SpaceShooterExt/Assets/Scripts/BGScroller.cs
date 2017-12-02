using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGScroller : MonoBehaviour {

	public float scrollSpeed;
	public float tileSizeZ;

	private Vector3 startPosition;

	// Use this for initialization
	void Start () {
		startPosition = transform.position;	
	}
	
	/*
	 * Math.Repeat(float t, float length) -> loops value of t, so that it is never larger than length and never smaller than 0.
	 * Ex: 3.0 for t, 2.5 for length, result will be 0.5
	 */
	void Update () {
		float newPosition = Mathf.Repeat (Time.time * scrollSpeed, tileSizeZ);
		transform.position = startPosition + Vector3.forward * newPosition;
	}
}
