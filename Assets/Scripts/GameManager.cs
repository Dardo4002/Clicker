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
    public TextMeshProUGUI t_clicador;
    public TextMeshProUGUI t_coste_clicador;
    public static int numero_clicador = 0;
    public static float pps_clicador = 0.1f;
    public static float coste_clicador = 10f;
    public static float indice_coste_clicador = 1.75f; //importante que sea más de 1

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
        t_clicador.text = "Tienes " + numero_clicador;
        t_coste_clicador.text = "Cuesta " + coste_clicador;
    }

    private void Sumar ()
    {
        Clicador();
    }

    private void Clicador()
    {
        Clicable.puntos += Time.deltaTime * pps_clicador * numero_clicador;
    }

    public void AumentoClicador()
    {
        if (Clicable.puntos > coste_clicador)
        {
            numero_clicador++;
            Clicable.puntos -= coste_clicador;
            coste_clicador *= indice_coste_clicador;

            //al loro con la de abajo, hacer que no salgan decimales en coste de compra
            coste_clicador = Mathf.FloorToInt(coste_clicador);
        }
    }
}
