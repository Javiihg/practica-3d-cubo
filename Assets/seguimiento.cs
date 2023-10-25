using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class seguimiento : MonoBehaviour
{
    public GameObject Personaje;
    private Vector3 posicionRelativa;
    // Start is called before the first frame update
    void Start()
    {
        posicionRelativa = transform.position - Personaje.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Personaje.transform.position + posicionRelativa;
    }
}
