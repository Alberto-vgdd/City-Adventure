using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraAnimation : MonoBehaviour {

    public Vector3 m_Position, m_Position2;
    private bool m_IsActived, m_IsActivated2;
	// Use this for initialization
	void Awake ()
    {
        m_IsActived = false;
        m_IsActivated2 = false;

    }
	
	// Update is called once per frame
	void Update ()
    {
        if (m_IsActivated2)
        {
            transform.localPosition = Vector3.Lerp(transform.localPosition, m_Position2, 3f * Time.deltaTime);
        }
        else  if (m_IsActived)
        {
            transform.localPosition = Vector3.Lerp(transform.localPosition, m_Position, 0.5f * Time.deltaTime);
        }
       
	}

    public void enable()
    {
        m_IsActived = true;
        Invoke("enable2", 5f);
    }

    public void enable2()
    {
        m_IsActivated2 = true;
        Invoke("exitGame", 1f);

    }

    public void exitGame()
    {
        Application.Quit();
    }
}
