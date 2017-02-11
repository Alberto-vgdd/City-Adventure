using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationScript : MonoBehaviour
{
    private Transform m_PlayerModelTransform;
    public float m_MovementSpeed;
    public AudioSource m_PlayerFloatingSoundSource;


    private float m_SinValue;
    public float m_MinimumVolumeValue;
    public float m_MaximunVolumeValue;

    public Animator m_PlayerAnimator;


    void Awake ()
    {
        m_PlayerModelTransform = transform.FindChild("PlayerModel");
        m_PlayerAnimator = GetComponent<Animator>();
    }
	

	void Update ()
    {
        m_SinValue = Mathf.Sin(Time.time * m_MovementSpeed);
        m_PlayerFloatingSoundSource.volume = Mathf.Max(m_MinimumVolumeValue, m_MaximunVolumeValue * m_SinValue);
        m_PlayerModelTransform.localPosition = new Vector3(0f, m_SinValue, 0f);   
	}
}
