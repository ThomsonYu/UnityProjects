using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {
    /** Original Starter Code - REMOVED
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    **/

    /* Called before rendering a frame, where most game code goes
    void Update()
    {
        
    }
    */

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