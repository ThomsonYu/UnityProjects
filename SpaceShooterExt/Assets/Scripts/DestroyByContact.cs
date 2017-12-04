using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour {

    public GameObject explosion;
    public GameObject playerExplosion;
	public int scoreValue;

	private GameController gameController;

	void Start(){
		GameObject gameControllerObject = GameObject.FindWithTag ("GameController");
		if (gameControllerObject != null) {
			gameController = gameControllerObject.GetComponent<GameController> ();
		}
		if (gameController == null) {
			Debug.Log ("Cannot find 'GameController' script");
		}
	}

    // trigger: OnTriggerEnter - called when other collider enters the trigger
    // On the first frame, it collides with Boundary thus deleting the asteroid and boundary
    // Create tag for boundary
    private void OnTriggerEnter(Collider other)
    {
		if (other.CompareTag("Boundary") || other.CompareTag("Enemy") || other.CompareTag("Boss"))
        {
            return;
        }

		if (this.CompareTag ("Boss")) {
			if (other.CompareTag ("Bolt")) {
				gameController.decreaseBossLife ();
				Destroy (other.gameObject);
				if (gameController.bossDead ()) {
					Instantiate (explosion, transform.position, transform.rotation);	
					Destroy (gameObject);
					gameController.GameOver ();
				}
			}
		} else if (other.CompareTag ("Player")) {
			gameController.decreasePlayerLife ();
			Destroy (gameObject);
			if (gameController.playerDead ()) {
				Instantiate (playerExplosion, other.transform.position, other.transform.rotation);
				Destroy (other.gameObject);
				gameController.GameOver ();
			}
		} else {
			if (explosion != null) {
				Instantiate (explosion, transform.position, transform.rotation);	
			}

			if (other.CompareTag ("Bolt")) {
				gameController.AddScore (scoreValue);
			}
			
			Destroy (other.gameObject);
			Destroy (gameObject);
		}
    }
}