using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diamonds : MonoBehaviour
{
    public int diamondValue = 100;

    private void OnTriggerEnter(Collider other)  // Usamos OnTriggerEnter para el collider de tipo trigger
    {
        if (other.CompareTag("Player"))  // Verificamos si la colisión es con el jugador
        {

            GameManager.Instance.AgregarDiamante(diamondValue);  

            Destroy(gameObject);  
        }
    }
}
