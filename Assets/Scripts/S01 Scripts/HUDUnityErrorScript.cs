using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDUnityErrorScript : MonoBehaviour
{
    private AudioSource m_AudioSource;
    private Animator m_Animator;
    private bool m_IsActivated;
    private Image m_ErrorImage;

   
	
	void Awake ()
    {
        m_Animator = GetComponent<Animator>();
        m_AudioSource = GetComponent<AudioSource>();
        m_ErrorImage = GetComponent<Image>();
        m_IsActivated = false;

    }
	
	// Update is called once per frame
	void Update ()
    {
		if (Input.GetMouseButtonDown(0) && m_IsActivated)
        {
            PlayErrorSound();
        }
	}


    public void LaunchError()
    {
        m_IsActivated = true;
        m_Animator.SetTrigger("UnityError");
        Invoke("PlayErrorSound",1.5f);
    }


   void PlayErrorSound()
    {
        m_AudioSource.Play();
    }
}
