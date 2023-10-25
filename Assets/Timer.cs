using System.Collections;
using UnityEngine;
using TMPro;

public class Temporizador : MonoBehaviour
{
    public float tiempoInicial = 60f;
    private float tiempoRestante;
    public TMP_Text textoTemporizador;

    private void Start()
    {
        tiempoRestante = tiempoInicial;
        ActualizarTextoTemporizador();
        StartCoroutine(ContarTiempoRegresivo());
    }

    private void ActualizarTextoTemporizador()
    {
        int minutos = Mathf.FloorToInt(tiempoRestante / 60);
        int segundos = Mathf.FloorToInt(tiempoRestante % 60);
        textoTemporizador.text = minutos.ToString("00") + ":" + segundos.ToString("00");
    }

    private IEnumerator ContarTiempoRegresivo()
    {
        while (tiempoRestante > 0)
        {
            yield return new WaitForSeconds(1f);
            tiempoRestante -= 1f;
            ActualizarTextoTemporizador();
        }
        Debug.Log("Tiempo agotado!");
    }
}
