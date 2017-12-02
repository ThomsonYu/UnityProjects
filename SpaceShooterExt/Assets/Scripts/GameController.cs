using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

    public GameObject[] hazards;
    public Vector3 spawnValue;
    public int hazardCount;
    public float spawnWait, startWait, waveWait;

    public Text restartText, gameOverText, scoreText;

    private bool gameOver;
    private bool restart;
	private int score;

    void Start()
    {
        gameOver = false;
        restart = false;
        restartText.text = "";
        gameOverText.text = "";
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
    }

    // Quarternion.identity corresponds with "no rotation" of the quarternion
    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait);
		while (true)
		{
	        for (int i = 0; i < hazardCount; i++)
	        {
				GameObject hazard = hazards[Random.Range(0, hazards.Length)];
	            Vector3 spawnPosition = new Vector3(Random.Range(-spawnValue.x, spawnValue.x), spawnValue.y, spawnValue.z);
	            Quaternion spawnRotation = Quaternion.identity;
	            Instantiate(hazard, spawnPosition, spawnRotation);
	            yield return new WaitForSeconds(spawnWait);
	        }
			yield return new WaitForSeconds (waveWait);
            if (gameOver)
            {
                restartText.text = "Press 'R' to Restart";
                restart = true;
                break;
            }
		}
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
}

/**
 * To have a function that can pause without pausing the entire game we need the function to be a co-routine
 * For it to be a co-routine, it cant return void, it must return IEnumerator.
 * WaitForSeconds must be written as yield return new
 * Coroutine can't be called like regular function. It must be called through StartCoroutine(signature)
 */