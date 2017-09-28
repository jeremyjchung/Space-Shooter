using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDestroyByContact : MonoBehaviour {

	public GameObject explosion;
	private GameController gameController;
	public int scoreValue;

	// Use this for initialization
	void Start () {
		GameObject gameControllerObject = GameObject.FindWithTag ("GameController");
		if (gameControllerObject) {
			gameController = gameControllerObject.GetComponent<GameController> ();
		} else {
			Debug.Log ("Cannot find 'GameController'");
		}
	}

	void OnTriggerEnter(Collider other) {

		if (other.tag == "Boundary") {
			return;
		}

		if (other.tag == "Enemy Shot" || other.tag == "Enemy") {
			return;
		}

		if (other.tag == "Player Shot") {
			Destroy (other.gameObject);
		}

		Instantiate (explosion, transform.position, transform.rotation);
		Destroy (gameObject);
		gameController.addScore (scoreValue); 
	}
}
