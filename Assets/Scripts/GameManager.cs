using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI Puntos;
    public TextMeshProUGUI textosuma1;
    public static int suma1 = 1;
    public static int aumentosuma1 = 2;

    public static int costeaumentosuma1 = 10;
    void Start()
    {
        Puntos.text = "0";
    }

    void Update()
    {
        Sumar();
        ActualizarTexto();
    }

    private void ActualizarTexto()
    {
        Puntos.text = "Puntos " + Mathf.FloorToInt(Clicable.puntos);
        textosuma1.text = "Suma1 " + suma1;
    }

    private void Sumar ()
    {
        Suma1();
    }

    private void Suma1()
    {
        Clicable.puntos += Time.deltaTime * aumentosuma1 * suma1;
    }

    public void AumentoSuma1()
    {
        if (Clicable.puntos > costeaumentosuma1)
        {
            suma1++;
            costeaumentosuma1 *=  2;
        }
    }
}
