using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementLaberinto : MonoBehaviour
{

    private Rigidbody m_PlayerRigidbody;
    public float m_PlayerMovementSpeed;
    public float m_JumpForceValue;


    private float m_HorizontalInput;
    private float m_VerticalInput;
    private bool m_JumpInput;
	private bool m_Quit;

    private bool m_IsJumping;
    public bool m_IsOnFloor;


	void Awake ()
    {
        m_PlayerRigidbody = GetComponent<Rigidbody>();
        	
	}
	

	void Update ()
    {
        ReadInputs();
		checkQuit ();

    }


    void FixedUpdate()
    {
        CheckInFloor();
        Move();
        Jump();
        
    }

	void checkQuit(){
		if (m_Quit) {
			Application.Quit ();
		}
	}


    void ReadInputs()
    {
		m_Quit = Input.GetButtonDown ("Back");
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
        if (Physics.Raycast(m_PlayerRigidbody.position, Vector3.down, 2.6f))
        {
            m_IsOnFloor = true;
            m_IsJumping = false;
        }
        else
        {
            m_IsOnFloor = false;
        }
    }


    void OnTriggerEnter(Collider Col)
    {
        if (Col.tag == ("Muerte"))
       {
			this.GetComponent<Transform> ().position = Checkpoint.UltimaPosicionCheckPoint;
       }
   }


    //void OnTriggerExit(Collider otherObject)
    //{
    //    if (otherObject.tag.Equals("Floor"))
    //    {
    //        m_IsOnFloor = false;
    //    }
    //}
}
