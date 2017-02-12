using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AgroEnemyScript : MonoBehaviour
{
    public GameObject m_EnemyGameObject;
    private bool m_IsUsed;
    public AudioSource m_audio1;
    public AudioSource m_audio2;
    public Animator m_HUDanimator;

	
	void Awake ()
    {
        m_EnemyGameObject.GetComponent<DiamondScript>().enabled = false;
        m_EnemyGameObject.GetComponent<NavMeshAgent>().enabled = false;
        m_EnemyGameObject.GetComponent<ParticleSystem>().Stop();
        m_IsUsed = false;
    }
	
	void OnTriggerEnter(Collider otherObject)
    {
        if (otherObject.CompareTag("Player") && !m_IsUsed) 
        {
            m_IsUsed = true;
            m_EnemyGameObject.GetComponent<DiamondScript>().enabled = true;
            m_EnemyGameObject.GetComponent<NavMeshAgent>().enabled = true;
            m_EnemyGameObject.GetComponent<ParticleSystem>().Play();
            m_audio1.Play();
            m_audio2.Play();

            m_HUDanimator.SetTrigger("VIRUSE");


        }
    }
}
