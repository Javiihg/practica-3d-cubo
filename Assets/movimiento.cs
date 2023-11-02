using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class movimiento : MonoBehaviour
{
    public float speed = 3.0f;
    public float alturaSalto = 10.0f;
    private bool enSuelo = true;
    private bool juegoPausado = false;
    private string mensajePausa = "DERROTA!! Presiona la barra espaciadora para reiniciar";

    private Rigidbody rb;
    private float initialFixedTimeScale;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
        initialFixedTimeScale = Time.fixedDeltaTime;
    }

    void OnGUI()
    {
        if (juegoPausado)
        {
            GUI.Label(new Rect(Screen.width / 2 - 150, Screen.height / 2 - 25, 300, 50), mensajePausa);

            if (Input.GetKeyDown(KeyCode.Space))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                juegoPausado = false;
                Time.timeScale = 1.0f;
                Time.fixedDeltaTime = initialFixedTimeScale;
            }
        }
    }

    void Update()
    {
        if (!juegoPausado)
        {
            float movimientoHorzizontal = Input.GetAxis("Horizontal");
            float movimientoVertical = Input.GetAxis("Vertical");

            Vector3 movimiento = new Vector3(movimientoHorzizontal, 0.0f, movimientoVertical);
            movimiento = movimiento.normalized * speed * Time.deltaTime;

            transform.Translate(movimiento);

            if (Input.GetButtonDown("Jump") && enSuelo)
            {
                rb.AddForce(Vector3.up * alturaSalto, ForceMode.Impulse);
                enSuelo = false;
            }
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Suelo"))
        {
            enSuelo = true;
        }

        if (collision.gameObject.CompareTag("ObjetoColisionable"))
        {
            Debug.Log("DEROTA!! Presiona la barra espaciadora para reiniciar");
            juegoPausado = true;
        }
    }
}