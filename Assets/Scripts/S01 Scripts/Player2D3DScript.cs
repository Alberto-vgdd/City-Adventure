using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2D3DScript : MonoBehaviour
{

    public GameObject m_Player;

	// Use this for initialization
	void Start ()
    {
        Invoke("ActivatePlayer", 4f);
	}
	
    void ActivatePlayer()
    {
        m_Player.SetActive(true);
        gameObject.SetActive(false);
    }

  
}
