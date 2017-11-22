using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Serializing is way of storing and transferring information. Unity needs to have properties serialized to be able to viewed in the inspector
[System.Serializable]
public class Boundary
{
    public float zMin, zMax, xMin, xMax;
}

public class PlayerController : MonoBehaviour {

    public float speed;
    public Boundary boundary;
    public float tilt;

    public GameObject shot;
    public Transform shotSpawn;

    public float fireRate;
    public float nextFire;

    private Rigidbody rb;
	private AudioSource audioSource;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
		audioSource = GetComponent<AudioSource> ();
    }

    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time > nextFire){
            nextFire = Time.time + fireRate;
            Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
			audioSource.Play ();
        }
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rb.velocity = movement * speed;

        // Set boundarys for player to avoid leaving the screen
        rb.position = new Vector3
            (
                Mathf.Clamp (rb.position.x, boundary.xMin, boundary.xMax),
                0.0f,
                Mathf.Clamp(rb.position.z, boundary.zMin, boundary.zMax)
            );

        // Tilt the player when moving left or right
        rb.rotation = Quaternion.Euler(0.0f, 0.0f, rb.velocity.x * -tilt);
    }
}


/*
 * For Materials, using a mobile shader (Mobile -> Particles -> Additive) will be less resource
 * intensive than using just Particles/Additive. However you might sacrifice quality and control.
 * You lose ability to change tint colour but is not needed for bolt.
 * 
 */