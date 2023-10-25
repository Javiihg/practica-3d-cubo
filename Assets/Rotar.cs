using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotar : MonoBehaviour
{
    private bool detenerRotacion = false;
    public float tiempoDeDetencion = 2f;

    // Update is called once per frame
    void Update()
    {
        if (!detenerRotacion)
        {
            transform.Rotate(0, 0, 90 * Time.deltaTime); // Ajusta la velocidad de rotación según tus necesidades
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && !detenerRotacion)
        {
            detenerRotacion = true;
            StartCoroutine(EsperarYReanudarRotacion());
        }
    }

    private IEnumerator EsperarYReanudarRotacion()
    {
        yield return new WaitForSeconds(tiempoDeDetencion);
        detenerRotacion = false;
    }
}
