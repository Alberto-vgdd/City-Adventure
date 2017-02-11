using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class easterEggLaberinto : MonoBehaviour {

	void OnTriggerEnter(Collider Col){
		if (Col.tag == "Player") {
			this.GetComponent<AudioSource> ().Play();
		}
	}

	void OnTriggerExit(Collider Col){
		if (Col.tag == "Player") {
			this.GetComponent<AudioSource> ().Stop();
		}
	}


}
