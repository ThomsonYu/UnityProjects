using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour {

	public GameObject shot;
	public Transform[] shotSpawns;
	public float fireRate;
	public float delay;
	public float arcShotDelay;
	//public AudioClip[] clips;

	private AudioSource audioSource;
	private int shotType;

	// Invoke repeating for repeating the Fire method
	void Start () {
		audioSource = GetComponent<AudioSource> ();
		StartCoroutine (Fire());
		shotType = 1;
	}

	IEnumerator Fire(){
		yield return new WaitForSeconds(delay);
		while (true) {
			if (this.CompareTag ("Boss")) {
				shotType = Random.Range (1, 3);
				if (shotType == 1) {
					foreach (var shotSpawn in shotSpawns) {
						Instantiate (shot, shotSpawn.position, shotSpawn.rotation);
					}
					audioSource.Play ();
				}
				if (shotType == 2) {
					foreach (var shotSpawn in shotSpawns) {
						Instantiate (shot, shotSpawn.position, shotSpawn.rotation);
						audioSource.Play ();
						yield return new WaitForSeconds (arcShotDelay);
					}
				}
			} else {
				foreach (var shotSpawn in shotSpawns) {
					Instantiate (shot, shotSpawn.position, shotSpawn.rotation);
				}
				audioSource.Play ();
			}
			yield return new WaitForSeconds (fireRate);
		}
	}
}
