using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	public GameObject player;

	//Take current transform position of the camera and subtract the transform position of the player for difference between the two
	private Vector3	offset;

	// Use this for initialization
	void Start () {
		offset = transform.position - player.transform.position;
	}
	
	// Update is called once per frame
	// LateUpdate better for camera
	void LateUpdate () {
		transform.position = player.transform.position + offset;
	}
}
