using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class CuentaAtras : MonoBehaviour
{

    public float tiempoTotal;
    private float aux;
    public Text texto;
    private float porcentaje;

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
            SceneManager.LoadScene("S03");
        }
        porcentaje = 100 - (tiempoTotal * 100 / aux);
        texto.text = "DISC DEFRAG: " + porcentaje.ToString("F2") + "%";

    }
}
