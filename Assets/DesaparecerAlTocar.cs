using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesaparecerAlTocar : MonoBehaviour
{
    public GameObject sistemaParticulas;
    private ParticleSystem particleSystem;
    private bool isCollected = false;
    public int requiredCollectibles = 4;
    public GameObject gameManager;
    private int collectibleCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        particleSystem = sistemaParticulas.GetComponent<ParticleSystem>();
        particleSystem.Stop();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player") && !isCollected)
        {
            Collect();
        }
    }

    void Collect()
    {
        isCollected = true;
        gameObject.SetActive(false);
        particleSystem.Play();
        collectibleCount++; // Incrementa el contador
        Debug.Log("Coleccionable recogido. Contador: " + collectibleCount);

        if (gameManager != null && collectibleCount == requiredCollectibles)
        {
            gameManager.SendMessage("EndGame");
        }
    }
}