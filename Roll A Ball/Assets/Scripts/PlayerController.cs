using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {
    /** Original Starter Code - REMOVED
	// Use this for initialization
	void Start () {
		
	}
	
    // Called before rendering a frame, where most game code goes
	// Update is called once per frame
	void Update () {
		
	}
    **/
    
    // Can be seen in Unity
    public float speed;
	public Text countText;
	public Text winText;

	private Rigidbody rb;
	private int count;

	void Start () {
		rb = GetComponent<Rigidbody> ();
		count = 0;
		SetCountText ();
		winText.text = "";
	}

    // Called just before any physics calculations. Where our physics code goes
    void FixedUpdate()
    {
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);

		rb.AddForce (movement * speed);
    }

	void OnTriggerEnter(Collider other) 
	{
		// Destroy(other.gameObject);
		if (other.gameObject.CompareTag ("Pick Up")) 
		{
			other.gameObject.SetActive (false);
			count++;
			SetCountText ();
		}
	}

	void SetCountText ()
	{
		countText.text = "Count: " + count.ToString ();
		if (count >= 12) {
			winText.text = "You Win!";
		}
	}
}

// Performance optimization
/*
 * Static colliders shouldn't move, unity is recalculating static colliders
 * we should set colliders to dynamic
 * Any game object with a collider and rigid body is considered dynamic
 * Any game object with a collider but no rigid body is static
 * For these game objects, add rigid body component and set 'Is Kinematic'
 * 
 * Static colliders shouldn't move like walls and floors
 * Dynamic colliders can move, and have rigid body attached
 * Standard rigid bodies are moved using physic forces
 * Kinematic rigid bodies are moved using their transform
 */
