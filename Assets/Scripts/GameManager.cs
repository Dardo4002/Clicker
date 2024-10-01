using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI pipas;

    //clicador
    public TextMeshProUGUI clicador;
    public TextMeshProUGUI coste_clicador;
    public static int numero_clicador = 0;
    public static float aumento_clicador = 0.1f;
    public static float aumento_coste_clicador = 1.3f;
    public static float indice_aumento_coste_clicador = 1.2f; //importante que sea más de 1

    //granja






    void Start()
    {
        pipas.text = "0";
    }

    void Update()
    {
        Sumar();
        ActualizarTexto();
    }

    private void ActualizarTexto()
    {
        pipas.text = "Puntos " + Mathf.FloorToInt(Clicable.puntos);
        clicador.text = "Tienes " + numero_clicador;
        coste_clicador.text = "Cuesta " + aumento_coste_clicador;
    }

    private void Sumar ()
    {
        Clicador();
    }

    private void Clicador()
    {
        Clicable.puntos += Time.deltaTime * aumento_clicador * numero_clicador;
    }

    public void AumentoClicador()
    {
        if (Clicable.puntos > aumento_coste_clicador)
        {
            numero_clicador++;
            Clicable.puntos -= aumento_coste_clicador;
            aumento_coste_clicador *= indice_aumento_coste_clicador;

            //al loro con la de abajo, hacer que no salgan decimales en coste de compra
            //aumento_coste_clicador = Mathf.FloorToInt(aumento_coste_clicador);
        }
    }
}
