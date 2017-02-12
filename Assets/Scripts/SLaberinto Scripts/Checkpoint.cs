using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour {

	public static Vector3 UltimaPosicionCheckPoint;
	public GameObject Checkpoint1;
	public GameObject Checkpoint2;



	// Use this for initialization
	void Start () {
		UltimaPosicionCheckPoint = this.GetComponent<Transform> ().position;
	}

	void OnTriggerEnter(Collider Col){
		if (Col.tag == "Checkpoint") {
			UltimaPosicionCheckPoint = Col.GetComponent<Transform> ().position;
			aumentarIntensidadLuz ();
			reproducirSonido ();
		}
	}

	void aumentarIntensidadLuz ()
	{
		Checkpoint1.GetComponent<Light> ().intensity = 5;
		Checkpoint1.GetComponent<Light> ().range = 30;
		Checkpoint2.GetComponent<Light> ().intensity = 5;
		Checkpoint2.GetComponent<Light> ().range = 30;
	}

	void reproducirSonido (){
		Checkpoint1.GetComponent<AudioSource> ().Play ();
	}

}
