using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    //Recolectables

    public int cantidadMoneda = 0;
    public int cantidadDiamante = 0;
    public TextMeshProUGUI textoMoneda;
    public TextMeshProUGUI textoDiamante;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;

            DontDestroyOnLoad(gameObject);


        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AgregarMoneda(int value)
    {
        cantidadMoneda+=value;
        Debug.Log("Monedas recogidas: " + cantidadMoneda);
        textoMoneda.text = cantidadMoneda.ToString();
    }

    public void AgregarDiamante(int value)
    {
        cantidadDiamante += value;
        textoDiamante.text = cantidadDiamante.ToString();
    }
}