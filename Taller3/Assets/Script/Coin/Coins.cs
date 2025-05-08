using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coins : MonoBehaviour
{

    public float pickupDistance = 2f;
    public int coinValue = 50;
    private Transform player;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        float distancia = Vector3.Distance(transform.position, player.position);

        // Si está cerca y se hace clic izquierdo
        if (distancia < pickupDistance && Input.GetMouseButtonDown(0))
        {
            // Sumar el valor al GameController
            GameManager.Instance.AgregarMoneda(coinValue);

            // Destruir la moneda
            Destroy(gameObject);

        }
    }
}
