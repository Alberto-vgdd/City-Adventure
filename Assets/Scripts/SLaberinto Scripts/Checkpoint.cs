using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour {

	public static Vector3 UltimaPosicionCheckPoint;

	// Use this for initialization
	void Start () {
		UltimaPosicionCheckPoint = this.GetComponent<Transform> ().position;
	}

	void OnTriggerEnter(Collider Col){
		if (Col.tag == "Checkpoint") {
			UltimaPosicionCheckPoint = Col.GetComponent<Transform> ().position;
		}
	}
}
