using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDestroyByContact : MonoBehaviour {

	public GameObject explosion;
	public GameObject miniExplosion;
	private GameController gameController;
	public int lives;

	void Start() {
		GameObject gameControllerObject = GameObject.FindWithTag ("GameController");
		if (gameControllerObject) {
			gameController = gameControllerObject.GetComponent<GameController> ();
		} else {
			Debug.Log ("Cannot find 'GameController'");
		}
	}

	void OnTriggerEnter(Collider other) {
		
		if (other.tag == "Boundary" || other.tag == "Player Shot") {
			return;
		}

		if (other.tag == "Enemy Shot") {
			Destroy (other.gameObject);
		}

		lives--;
		gameController.minusLives ();

		if (lives > 0) {
			Instantiate (miniExplosion, transform.position, transform.rotation);
		} else {
			Instantiate (explosion, transform.position, transform.rotation);
			Destroy (gameObject);
			gameController.GameOver ();
		}

	}
}

