using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolBehaviour : MonoBehaviour {

	private Transform target;
	private bool persiguiendo;
	public float speedyBoy;

	void OnTriggerEnter(Collider other)
	{
//		print ("Se entra en el colaidah");
		if (other.tag == "Player") 
		{
			persiguiendo = true;
		}

	}

	void OnTriggerExit()
	{
		persiguiendo = false;
	}

	void SearchAndDestroy()
	{
		target = GameObject.FindGameObjectWithTag("Player").transform;

		if (persiguiendo) 
		{
			this.transform.position = Vector3.MoveTowards (this.transform.position, target.position, speedyBoy*Time.deltaTime);	
		}

	}

//	// Use this for initialization
//	void Start () 
//	{
//		
//	}
	
	// Update is called once per frame
	void Update () {
		SearchAndDestroy ();
	}
}
