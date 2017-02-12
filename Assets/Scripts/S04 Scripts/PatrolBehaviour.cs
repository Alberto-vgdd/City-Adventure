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

	void OnTriggerExit(Collider other)
	{
        if (other.tag == "Player")
        {
            persiguiendo = false;
        }
    }

	void SearchAndDestroy()
	{
		if (persiguiendo) 
		{
			this.transform.position = Vector3.MoveTowards (this.transform.position, target.position, speedyBoy*Time.deltaTime);	
		}

	}

    void Awake()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }
	
	// Update is called once per frame
	void Update () {
		SearchAndDestroy ();
	}
}
