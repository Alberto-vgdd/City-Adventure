using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class changeView : MonoBehaviour {

    public Camera camara;
    public bool pitchDown;
	// Use this for initialization
	void Start () {
		
	}

    public void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "Player")
        {
 

            pitchDown = true;
           
        }
    }

    // Update is called once per frame
   
	
	// Update is called once per frame
	void Update () {
		if(pitchDown)
            if(camara.GetComponent<AudioSource>().pitch >= 0f){
                camara.GetComponent<AudioSource>().pitch -= 0.35f * Time.deltaTime;
            }else
            {
                SceneManager.LoadScene("S01");
            }
	}
}
