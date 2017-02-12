using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AgroEnemyDisabler : MonoBehaviour
{
    private bool m_IsUsed;
    public GameObject m_AgroEnablerGameObject;
    public GameObject m_EnemyGameObject;
    public Transform m_Camera;
   public GameObject m_Player;

    // Use this for initialization
    void Awake ()
    {
        m_IsUsed = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    void OnTriggerEnter(Collider otherObject)
    {
        if (otherObject.CompareTag("Player") && !m_IsUsed)
        {
            
            m_IsUsed = true;
            m_EnemyGameObject.GetComponent<DiamondScript>().enabled = false;
            m_EnemyGameObject.GetComponent<NavMeshAgent>().enabled = false;
            m_EnemyGameObject.GetComponent<ParticleSystem>().Stop();
            GetComponent<AudioSource>().Play();
            m_Player.GetComponent<Animator>().Play("PlayerDeath");

            m_Camera.GetComponent<CameraAnimation>().enable();



        }
    }
}
