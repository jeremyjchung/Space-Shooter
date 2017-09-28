using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByBoundary : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	void OnTriggerExit(Collider other)
	{
		// Destroy everything that leaves the trigger
		Destroy(other.gameObject);
	}
}
