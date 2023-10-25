using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class movimiento : MonoBehaviour
{
    public float playerspeed = 10f;
    public Color newColor = Color.red;
    public float tiempoDeDetencion = 2f;
    private bool detenerse = false;
    public float tiempoDeCambio = 2f;
    private Color colorOriginal;
    private Animator animator;
    public string juego;

   /* public TMP_Text mensajeTexto;
    public TMP_Text tiempoTexto;
    public Canvas mensajeCanvas;
    public float tiempoTotal = 60f; // Tiempo total del juego en segundos
    private float tiempoRestante;
    private bool juegoTerminado = false;
    private bool mensajeMostrado = false;  // Variable para controlar si el mensaje se ha mostrado
    public KeyCode reiniciarKey = KeyCode.R;*/


    

    // Start is called before the first frame update
    void Start()
    {
        colorOriginal = GetComponent<Renderer>().material.color;
        animator = GetComponent<Animator>();
       /* ActualizarTiempo();
        tiempoRestante = tiempoTotal;*/
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("ObjetoColisionador"))
        {
            GetComponent<Renderer>().material.color = newColor;
            StartCoroutine(EsperarYReanudarMovimiento());
            StartCoroutine(RevertirColorDespuesDeTiempo());
        }
     }

    private IEnumerator EsperarYReanudarMovimiento()
    {
        detenerse = true;
        yield return new WaitForSeconds(tiempoDeDetencion);
        detenerse = false;
    }

    private IEnumerator RevertirColorDespuesDeTiempo()
    {
        yield return new WaitForSeconds(tiempoDeCambio);
        GetComponent<Renderer>().material.color = colorOriginal;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Moneda"))
        {
            Destroy(other.gameObject);
        }

        if (other.CompareTag("acabao"))
        {
            FinalizarPartida();
        }
    }

    void FinalizarPartida()
    {
        detenerse = true;
        StartCoroutine(CargarEscenaDespuesDeTiempo(1f));
    }

    private IEnumerator CargarEscenaDespuesDeTiempo(float tiempo)
    {
        yield return new WaitForSeconds(tiempo);
        SceneManager.LoadScene(juego);
    }

    // Update is called once per frame
    void Update()
    {
       if (!detenerse)
       {
         

         if (Input.GetKey(KeyCode.W)) 
         transform.Translate(Vector2.up * playerspeed * Time.deltaTime);

         if (Input.GetKey(KeyCode.S))
         transform.Translate(Vector2.down * playerspeed * Time.deltaTime);
        
         if (Input.GetKey(KeyCode.A)) 
         {
            transform.Translate(Vector2.left * playerspeed * Time.deltaTime);
            transform.localScale = new Vector3(-2.5f, 2.5f, 1f);
         }


         if (Input.GetKey(KeyCode.D))
         {
            transform.Translate(Vector2.right * playerspeed * Time.deltaTime);
            transform.localScale = new Vector3(2.5f, 2.5f, 1f);
         }

         animator.SetBool("isRunning", Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D));

       }

       /*  if (!juegoTerminado)
         {
            tiempoRestante -= Time.deltaTime;
            ActualizarTiempo();

            if (tiempoRestante <= 0f)
            {
                TiempoAgotado();
            }

            if (Input.GetKeyDown(KeyCode.R) && juegoTerminado)
            {
                ReiniciarJuego();
            }
         }

    }

    /*void ReinciarJuego()
    {
        juegoTerminado = false;
        mensajeCanvas.enabled = false;
        mensajeMostrado = false;
        tiempoRestante = tiempoTotal;
        ActualizarTiempo();
        Time.timeScale = 1;
    }*/
}
}
