using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement2D : MonoBehaviour
{

	private Rigidbody2D m_PlayerRigidbody;
	public float m_PlayerMovementSpeed;
	public float m_JumpForceValue;


	private float m_HorizontalInput;
	private float m_VerticalInput;
	private bool m_JumpInput;

	private bool m_IsJumping;
	private bool m_IsOnFloor;

	Animator anim;

	void Awake ()
	{
		anim = GetComponent<Animator> ();
		m_PlayerRigidbody = GetComponent<Rigidbody2D>();

	}

	// Update is called once per frame
	void Update ()
	{
		ReadInputs();
	}


	void FixedUpdate()
	{
		Move();
		Jump();

	}


	void ReadInputs()
	{
		m_HorizontalInput = Input.GetAxis("Horizontal");
		m_JumpInput = Input.GetButton("Jump");
	}

	void Move()
	{
		if (m_HorizontalInput > 0 || m_HorizontalInput <0) {
			
			anim.SetBool ("moving", true);
			m_PlayerRigidbody.transform.Translate (new Vector2 (m_HorizontalInput, 0f).normalized * Time.fixedDeltaTime * m_PlayerMovementSpeed);
		} else {
			anim.SetBool ("moving", false);
		}

	}

	void Jump()
	{
		if (m_IsOnFloor && !m_IsJumping && m_JumpInput)
		{
            GetComponent<AudioSource>().Play();
			m_PlayerRigidbody.AddForce(new Vector2(0f, m_JumpForceValue), ForceMode2D.Impulse);
			m_IsJumping = true;

		}
	}


	void OnCollisionEnter2D(Collision2D otherObject)
	{
		if (otherObject.collider.tag.Equals("Floor"))
		{
			m_IsJumping = false;
			m_IsOnFloor = true;
		}
	}


	void OnCollisionExit2D(Collision2D otherObject)
	{
		if (otherObject.collider.tag.Equals("Floor"))
		{
			m_IsOnFloor = true;
		}
	}
}
