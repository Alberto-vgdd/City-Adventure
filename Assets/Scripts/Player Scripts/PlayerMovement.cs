using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    private Rigidbody m_PlayerRigidbody;
    public float m_PlayerMovementSpeed;
    public float m_JumpForceValue;


    private float m_HorizontalInput;
    private float m_VerticalInput;
    private bool m_JumpInput;

    private bool m_IsJumping;
    public bool m_IsOnFloor;
    private RaycastHit m_RaycastHit;


    void Awake ()
    {
        m_PlayerRigidbody = GetComponent<Rigidbody>();
        	
	}
	

	void Update ()
    {
        ReadInputs();
    }


    void FixedUpdate()
    {
        CheckInFloor();
        Move();
        Jump();
        
    }


    void ReadInputs()
    {
        m_HorizontalInput = Input.GetAxis("Horizontal");
        m_VerticalInput = Input.GetAxis("Vertical");
        m_JumpInput = Input.GetButton("Jump");
       
    }

    void Move()
    {
        m_PlayerRigidbody.transform.Translate(new Vector3(m_HorizontalInput, 0f, m_VerticalInput).normalized * Time.fixedDeltaTime * m_PlayerMovementSpeed);
    }

    void Jump()
    {
        if (m_IsOnFloor && !m_IsJumping && m_JumpInput)
        {
            m_IsJumping = true;
           m_PlayerRigidbody.AddForce(new Vector3(0f, m_JumpForceValue, 0f), ForceMode.VelocityChange);
        }
    }

    void CheckInFloor()
    {
      
        if (Physics.Raycast(m_PlayerRigidbody.position, Vector3.down, out m_RaycastHit,2.6f))
        {
            if (m_RaycastHit.collider.CompareTag("Floor"))
            {
                m_IsOnFloor = true;
                m_IsJumping = false;
            }
            
        }
        else
        {
            m_IsOnFloor = false;
        }
    }


    //void OnTriggerEnter(Collider otherObject)
    //{
    //    if (otherObject.tag.Equals("Floor"))
    //    {
    //        m_IsJumping = false;
    //        m_IsOnFloor = true;
    //    }
    //}


    //void OnTriggerExit(Collider otherObject)
    //{
    //    if (otherObject.tag.Equals("Floor"))
    //    {
    //        m_IsOnFloor = false;
    //    }
    //}
}
