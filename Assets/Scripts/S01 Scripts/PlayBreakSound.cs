﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayBreakSound : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter(Collision other)
    {
        if (other.collider.tag == "Floor")
        {
            GetComponent<AudioSource>().Play();
        }
    }
}
