using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

/*public class derrota : MonoBehaviour
{
    public TMP_Text mensajeTexto;
    public TMP_Text tiempoTexto;
    public Canvas mensajeCanvas;
    public float tiempoTotal = 60f; // Tiempo total del juego en segundos
    private float tiempoRestante;
    private bool juegoTerminado = false;
    // Start is called before the first frame update
    void Start()
    {
        tiempoRestante = tiempoTotal;
        ActualizarTiempo();
        mensajeCanvas.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(!juegoTerminado)
        {
            tiempoRestante -= Time.deltaTime;
            ActualizarTiempo();

            if (tiempoRestante <= 0f)
            {
                TiempoAgotado();
            }
        }
    }

    void ActualizarTiempo()
    {
        tiempoTexto.text = "Tiempo: " + Mathf.CeilToInt(tiempoRestante).ToString();
    }

    private bool mensajeMostrado = false;

    void TiempoAgotado()
    {
        if (!mensajeMostrado)
        {
            tiempoRestante = 0f;
            juegoTerminado = true;
            ActualizarTiempo();
            mensajeTexto.text = "Tiempo agotado!";
            mensajeCanvas.enabled = true;
            Time.timeScale = 0;
            mensajeMostrado = true;
        }
     
    }
}*/
