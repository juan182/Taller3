using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pausa : MonoBehaviour
{
    public GameObject menuPausa;

    public void pausa()
    {

            menuPausa.SetActive(true);
            Time.timeScale = 0f; // Pausar el juego
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            pausa();
        }
    }

}
