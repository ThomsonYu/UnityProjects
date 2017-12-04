using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

    public GameObject[] hazards;
	public GameObject boss;
    public Vector3 spawnValue;
    public int hazardCount;
    public float spawnWait, startWait, waveWait;
	public int playerLife, bossLife;
	public int waveCount;

    public Text restartText, gameOverText, scoreText, lifeText;

    private bool gameOver;
    private bool restart;
	private int score;

    void Start()
    {
        gameOver = false;
        restart = false;
        restartText.text = "";
        gameOverText.text = "";
		lifeText.text = "Lives: " + playerLife.ToString ();
		score = 0;
		UpdateScore ();
        StartCoroutine(SpawnWaves());
    }

    private void Update()
    {
        if (restart)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }

		if (gameOver)
		{
			restartText.text = "Press 'R' to Restart";
			restart = true;
		}
    }

    // Quarternion.identity corresponds with "no rotation" of the quarternion
    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait);

		for (int j = 0; j < waveCount; j++) {
			for (int i = 0; i < hazardCount; i++) {
				GameObject hazard = hazards [Random.Range (0, hazards.Length)];
				Vector3 spawnPosition = new Vector3 (Random.Range (-spawnValue.x, spawnValue.x), spawnValue.y, spawnValue.z);
				Quaternion spawnRotation = Quaternion.identity;
				Instantiate (hazard, spawnPosition, spawnRotation);
				yield return new WaitForSeconds (spawnWait);

				if (gameOver) {
					restartText.text = "Press 'R' to Restart";
					restart = true;
					break;
				}
			}
			if (gameOver) {
				break;
			}
		}

		if (!gameOver) {
			Vector3 bossSpawnPosition = new Vector3 (0.0f, spawnValue.y, spawnValue.z+4);
			Instantiate (boss, bossSpawnPosition, Quaternion.identity);
		}

//		while (true)
//		{
//			for (int i = 0; i < hazardCount; i++) {
//				GameObject hazard = hazards [Random.Range (0, hazards.Length)];
//				Vector3 spawnPosition = new Vector3 (Random.Range (-spawnValue.x, spawnValue.x), spawnValue.y, spawnValue.z);
//				Quaternion spawnRotation = Quaternion.identity;
//				Instantiate (hazard, spawnPosition, spawnRotation);
//				yield return new WaitForSeconds (spawnWait);
//			}
//			yield return new WaitForSeconds (waveWait);

			//if (currentWave < waveCount) {
//				for (int i = 0; i < hazardCount; i++) {
//					GameObject hazard = hazards [Random.Range (0, hazards.Length)];
//					Vector3 spawnPosition = new Vector3 (Random.Range (-spawnValue.x, spawnValue.x), spawnValue.y, spawnValue.z);
//					Quaternion spawnRotation = Quaternion.identity;
//					Instantiate (hazard, spawnPosition, spawnRotation);
//					yield return new WaitForSeconds (spawnWait);
//				}
//				//currentWave++;
//				yield return new WaitForSeconds (waveWait);
			//}
//			} else {
//				if (!bossSpawned) {
//					bossSpawned = true;
//					Vector3 spawnPosition = new Vector3 (0.0f, 0.0f, 0.0f);
//					Instantiate (boss, spawnPosition, Quaternion.identity);
//				}
//			}

//        if (gameOver)
//        {
//            restartText.text = "Press 'R' to Restart";
//            restart = true;
//            break;
//        }
    }

	public void AddScore(int newScoreValue){
		score += newScoreValue;
		UpdateScore ();
	}

	public int GetScore(){
		return score;
	}

	void UpdateScore()
	{
		scoreText.text = "Score: " + score;
	}

    public void GameOver()
    {
        gameOverText.text = "Game Over!";
        gameOver = true;
    }

	public void decreasePlayerLife(){
		playerLife--;
		lifeText.text = "Lives: " + playerLife.ToString ();
	}

	public bool playerDead(){
		return playerLife == 0;
	}

	public void decreaseBossLife(){
		bossLife--;
	}

	public bool bossDead(){
		return bossLife == 0;
	}
}

/**
 * To have a function that can pause without pausing the entire game we need the function to be a co-routine
 * For it to be a co-routine, it cant return void, it must return IEnumerator.
 * WaitForSeconds must be written as yield return new
 * Coroutine can't be called like regular function. It must be called through StartCoroutine(signature)
 */