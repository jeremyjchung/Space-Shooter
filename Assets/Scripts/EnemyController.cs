using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class MovementDurationRange {
	public float start, end;
}

public class EnemyController : MonoBehaviour {

	private Rigidbody rb;
	private AudioSource audio;
	public GameObject shot;
	public float fireRate;
	public float speed;
	public float horizontalSpeed;
	public MovementDurationRange movementDurationRange;
	public float tilt;
	public Boundary boundary;
	public Transform shotSpawn;

	private float nextFire;
	private float movementDuration;
	private float strafeSpeed;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
		rb.velocity = transform.forward * speed;

		nextFire = Time.time + fireRate;

		StartCoroutine (Move ());
	}
		
	void LateUpdate() {
		if (Time.time > nextFire) {
			Instantiate (shot, shotSpawn.position, shotSpawn.rotation);
			nextFire += fireRate;
		}
	}

	void FixedUpdate () {
		rb.velocity = new Vector3 (strafeSpeed, 0, rb.velocity.z);

		rb.position = new Vector3 
			(
				Mathf.Clamp(rb.position.x, boundary.xMin, boundary.xMax), 
				0.0f, 
				rb.position.z
			);
		rb.rotation = Quaternion.Euler (0.0f, 180.0f, rb.velocity.x * -tilt);
	}

	IEnumerator Move() {
		while (true) {
			movementDuration = Random.Range (movementDurationRange.start, movementDurationRange.end);
			strafeSpeed = Random.Range (-horizontalSpeed, horizontalSpeed);

			yield return new WaitForSeconds (movementDuration);
		}
	}
}
