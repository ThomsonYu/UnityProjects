using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour {

	public GameObject shot;
	public Transform[] shotSpawns;
	public float fireRate;
	public float delay;
	//public AudioClip[] clips;

	private AudioSource audioSource;

	// Invoke repeating for repeating the Fire method
	void Start () {
		audioSource = GetComponent<AudioSource> ();
		InvokeRepeating ("Fire", delay, fireRate);
	}

	void Fire()
	{
		foreach (var shotSpawn in shotSpawns){
			Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
		}

		/* AudioClip clip = clips[Random.Range(0, clips.length)];
		 * audioSource.clip = clip;
		 */

		audioSource.Play ();
	}
}
