using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
	
public class CuentaAtras : MonoBehaviour
{
	public AudioSource camara;
    public float tiempoTotal;
    private float aux;
    public Text texto;
    private float porcentaje;
	public GameObject ErrorImage;
	public AudioClip ErrorSound;

    // Use this for initialization
    void Start()
    {
        aux = tiempoTotal;

    }

    // Update is called once per frame
    void Update()
    {
        tiempoTotal -= Time.deltaTime;
        
        if (tiempoTotal <= 0)
        {
			camara.clip = ErrorSound;
			camara.Play ();
			ErrorImage.GetComponent<Image>().enabled = true;
			Invoke ("Restart", 3f);

        }
        porcentaje = 100 - (tiempoTotal * 100 / aux);
        texto.text = "DISC DEFRAG: " + porcentaje.ToString("F2") + "%";

    }

	void Restart(){
		SceneManager.LoadScene ("S03");
	}
}
