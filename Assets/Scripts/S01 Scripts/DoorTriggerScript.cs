using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTriggerScript : MonoBehaviour
{
    private bool m_AlreadyActived;
    public HUDUnityErrorScript m_HUDS01;
    public GameObject m_SecretPath;


	// Use this for initialization
	void Awake ()
    {
        m_AlreadyActived = false;
        m_SecretPath.SetActive(false);

    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}


    void OnCollisionEnter(Collision otherObject)
    {
        if (otherObject.collider.tag.Equals( "Player") && !m_AlreadyActived)
        {
            m_AlreadyActived = true;
            Invoke("LaunchHUDError", 2f);
            Invoke("ShowSecretPath", 3.5f);
        }
    }

    void LaunchHUDError()
    {
        m_HUDS01.LaunchError();
        
    }

    void ShowSecretPath()
    {
        m_SecretPath.SetActive(true);
        gameObject.SetActive(false);
    }
}
