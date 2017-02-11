using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyboxTextBehaviour : MonoBehaviour {

	public GameObject[] textos;

	int dummy;

	void Awake()
	{
		for (int i = 0; i < textos.Length; i++) 
		{
			textos [i].GetComponentInChildren<MeshRenderer> ().material.SetColor("_Color.a", new Color(0,0,0,0));
		}

	}


	void PlayAnimation(GameObject target)
	{	target.GetComponentInChildren<Animation> ().Play ();	}

	void manageAnimation()
	{
		dummy = Random.Range (0, textos.Length);

		while (textos [dummy].GetComponentInChildren<Animation> ().isPlaying)
		{	dummy = Random.Range (0, textos.Length);	}

		PlayAnimation (textos [dummy]);
	}


	// Use this for initialization
	void Start () 
	{
		InvokeRepeating ("manageAnimation", 0.0f, 2.0f);
	}
	
//	// Update is called once per frame
//	void Update () {
//		
//	}
}
