using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Boundary {
	public float xMin, xMax, zMin, zMax;
}

public class GameController : MonoBehaviour {

	public GameObject hazard;
	public GameObject enemy;
	public Vector3 spawnValue;
	public int hazardCount;
	public float spawnWait;
	public float startWait;
	public float waveWait;
	public GUIText scoreText;
	public GUIText restartText;
	public GUIText gameOverText;
	public GUIText livesRemainingText;

	private bool gameOver;
	private bool restart;
	private int score;
	private int lives;

	void Update() {
		if (restart) {
			if (Input.GetKey (KeyCode.R)) {
				Application.LoadLevel (Application.loadedLevel);
			}
		}
	}

	IEnumerator SpawnWaves () {
		yield return new WaitForSeconds (startWait);

		while (!gameOver) {
			for (int i = 0; i < hazardCount; i++) {
				Vector3 spawnPosition = new Vector3 (Random.Range(-spawnValue.x,spawnValue.x), spawnValue.y, spawnValue.z);
				Quaternion spawnRotation = Quaternion.identity; 
				Instantiate (hazard, spawnPosition, spawnRotation);
				if (i % 2 == 0 && i <= 6) {
					Vector3 enemySpawnPosition = new Vector3 (Random.Range(-spawnValue.x,spawnValue.x), spawnValue.y, spawnValue.z);
					Quaternion enemySpawnRotation = Quaternion.Euler (0.0f, 180.0f, 0.0f);
					Instantiate (enemy, spawnPosition, enemySpawnRotation);
				}
				yield return new WaitForSeconds (spawnWait);
			}

			yield return new WaitForSeconds (waveWait);
		}

		restartText.text = "Press 'R' to play again";
		restart = true;
	}

	// Use this for initialization
	void Start () {
		restartText.text = "";
		gameOverText.text = "";
		gameOver = false;
		restart = false;
		score = 0;
		lives = 3;
		UpdateScore ();
		UpdateLives ();
		StartCoroutine (SpawnWaves ());
	}

	void UpdateScore () {
		scoreText.text = "Score: " + score;
	}

	void UpdateLives() {
		livesRemainingText.text = "Lives: " + lives;
	}

	public void minusLives() {
		lives--;
		UpdateLives ();
	}

	public void addScore(int newScoreValue) {
		score += newScoreValue;
		UpdateScore ();
	}

	public void GameOver () {
		gameOverText.text = "Game Over";
		gameOver = true;
	}
}
