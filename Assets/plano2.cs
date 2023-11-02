using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

public class plano2 : MonoBehaviour
{
    private Color colorOriginal;
    private Renderer rend;
    private Vector3 escalaOriginal;
    private bool escalado = false;
    private float tiempoDeReduccion = 3.0f;
    private float tiempoPasado = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
        colorOriginal = rend.material.color;
        escalaOriginal = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        if (escalado)
        {
            tiempoPasado += Time.deltaTime;
            float t = Mathf.Clamp01(tiempoPasado / tiempoDeReduccion);
            transform.localScale = Vector3.Lerp(escalaOriginal, Vector3.zero, t);

            if (t >= 1.0f)
            {
                escalado = false;
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            CambiarColor();
            ReducirEscalado();
            escalado = true;
        }
    }

    private void CambiarColor()
    {
        Color nuevoColor = new Color(Random.value, Random.value, Random.value);

        rend.material.color = nuevoColor;
    }

    private void ReducirEscalado()
    {
        transform.localScale = Vector3.zero;
    }

    public void RestaurarColorOriginalYEscalado()
    {
        rend.material.color = colorOriginal;
        transform.localScale = escalaOriginal;
        escalado = false;
    }
}
