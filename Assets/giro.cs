using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class giro : MonoBehaviour
{
    public float velocidadRotacion = 50.0f; // Velocidad de rotación en grados por segundo

    void Update()
    {
        // Rota el objeto en su eje Y
        transform.Rotate(Vector3.up * velocidadRotacion * Time.deltaTime);
    }
}
