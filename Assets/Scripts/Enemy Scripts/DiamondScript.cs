using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.AI;

public class DiamondScript : MonoBehaviour
{

    private NavMeshAgent m_NavigationMeshAgent;
    public Transform m_Target;
    private bool m_PlayerAlive;
    public Animator m_HUD;

    // Use this for initialization
    void Awake ()
    {
        m_NavigationMeshAgent = GetComponent<NavMeshAgent>();
        m_PlayerAlive = true;

    }
	
	// Update is called once per frame
	void Update ()
    {
        if (m_PlayerAlive)
        {
            m_NavigationMeshAgent.SetDestination(m_Target.position);
        }
        else
        {
            m_NavigationMeshAgent.enabled = false;
            gameObject.GetComponent<ParticleSystem>().Stop();
        }
    }


    void OnCollisionEnter(Collision otherObject)
    {
        if (m_PlayerAlive && otherObject.collider.CompareTag("Player"))
        {
            m_PlayerAlive = false;
            m_Target.Find("Main Camera") .parent= null;
        
            m_Target.GetComponent<Animator>().Play("PlayerDeath");
            m_HUD.Play("Avast Animation 2");
            Invoke("ResetLevel", 4.5f);
        }
    }

    void ResetLevel()
    {
        SceneManager.LoadScene("S05");
    }


}
