using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidDestroyByContact : MonoBehaviour {

	public GameObject explosion;
	private GameController gameController;
	public int scoreValue;

	void Start() {
		GameObject gameControllerObject = GameObject.FindWithTag ("GameController");
		if (gameControllerObject) {
			gameController = gameControllerObject.GetComponent<GameController> ();
		} else {
			Debug.Log ("Cannot find 'GameController'");
		}
	}

	void OnTriggerEnter(Collider other) {
		//Debug.Log (other.name);
		if (other.tag == "Boundary") {
			return;
		}

		if (other.tag == "Enemy" || other.tag == "Enemy Shot") {
			return;
		}

		if (other.tag == "Player Shot") {
			Destroy (other.gameObject);
		}
			
		Instantiate(explosion, transform.position, transform.rotation);
		gameController.addScore (scoreValue);
		Destroy (gameObject);
	}
}
