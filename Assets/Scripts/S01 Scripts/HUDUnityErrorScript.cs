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
    private bool m_MoveError;


    void Awake ()
    {
        m_Animator = GetComponent<Animator>();
        m_AudioSource = GetComponent<AudioSource>();
        m_ErrorImage = transform.Find("UnityErrorImage"). GetComponent<Image>();
        m_IsActivated = false;
        m_MoveError = false;
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (m_IsActivated)
        {
            if (Input.GetButtonDown("Jump"))
            {
                PlayErrorSound();
            }

            if (m_MoveError)
            {
                m_ErrorImage.rectTransform.anchoredPosition = new Vector2(Input.GetAxis("Horizontal") * 150f, Input.GetAxis("Vertical") * 150f);
            }
           
        }
	
    }


    public void LaunchError()
    {
        m_IsActivated = true;
        m_Animator.SetTrigger("UnityError");
        Invoke("PlayErrorSound",1.5f);
        Invoke("MoveError", 3.5f);
        
    }


   void PlayErrorSound()
    {
        m_AudioSource.Play();
    }

    void MoveError()
    {
        m_MoveError = true; 
    }
}
