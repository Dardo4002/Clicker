using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI pipas;

    //Jugador
    public TextMeshProUGUI t_jugador;
    public TextMeshProUGUI t_coste_jugador;
    public static float coste_mejora_jugador = 10f;
    public static float indice_coste_mejora_jugador = 1.75f; //importante que sea más de 1

    //clicador
    public TextMeshProUGUI t_clicador;
    public TextMeshProUGUI t_coste_clicador;
    public static int numero_clicador = 0;
    public static float pps_clicador = 0.1f;
    public static float coste_clicador = 10f;
    public static float indice_coste_clicador = 1.75f; //importante que sea más de 1

    //granja
    public TextMeshProUGUI t_granja;
    public TextMeshProUGUI t_coste_granja;
    public static int numero_granja = 0;
    public static float pps_granja = 1f;
    public static float coste_granja = 10f;
    public static float indice_coste_granja = 1.75f; //importante que sea más de 1





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
        pipas.text = "" + Mathf.FloorToInt(Clicable.puntos);

        //CANTIDAD
        //clicador
        t_clicador.text = "Tienes " + numero_clicador;
        t_coste_clicador.text = "Cuesta " + coste_clicador;
        
        //granja
        t_granja.text = "Tienes " + numero_granja;
        t_coste_granja.text = "Cuesta " + coste_granja;

        //MEJORAS
        //jugador
        t_jugador.text = "Mejora numero " + Clicable.mejora_jugador;
        t_coste_jugador.text = "Coste " + coste_mejora_jugador;
    }

    //SUMAS
    private void Sumar ()
    {
        Clicador();
        Granja();
    }

    private void Clicador()
    {
        Clicable.puntos += Time.deltaTime * pps_clicador * numero_clicador;
    }

    private void Granja()
    {
        Clicable.puntos += Time.deltaTime * pps_granja * numero_granja;
    }

    public void AumentoClicador()
    {
        if (Clicable.puntos >= coste_clicador)
        {
            numero_clicador++;
            Clicable.puntos -= coste_clicador;
            coste_clicador *= indice_coste_clicador;

            //al loro con la de abajo, hacer que no salgan decimales en coste de compra
            coste_clicador = Mathf.FloorToInt(coste_clicador);
        }
    }

    public void AumentoGranja()
    {
        if (Clicable.puntos >= coste_granja)
        {
            numero_granja++;
            Clicable.puntos -= coste_granja;
            coste_granja *= indice_coste_granja;

            //al loro con la de abajo, hacer que no salgan decimales en coste de compra
            coste_granja = Mathf.FloorToInt(coste_granja);
        }
    }



    //MEJORAS
    public void AumentoMejoraJugador()
    {
        if (Clicable.puntos >= coste_mejora_jugador)
        {
            Clicable.mejora_jugador++;
            Clicable.puntos -= coste_mejora_jugador;
            coste_mejora_jugador *= indice_coste_mejora_jugador;

            //al loro con la de abajo, hacer que no salgan decimales en coste de compra
            coste_mejora_jugador = Mathf.FloorToInt(coste_mejora_jugador);
        }
    }
}
