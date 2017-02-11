using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour {


	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player") 
		{
			SceneManager.LoadScene ("S03");
		}
	}



	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
