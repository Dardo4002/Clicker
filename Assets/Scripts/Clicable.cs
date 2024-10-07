using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clicable : MonoBehaviour
{
    [SerializeField] static public float puntos = 0;
    [SerializeField] static public int mejora_jugador = 0;
    void Start()
    {
    }
    private void OnMouseDown()
    {
        puntos += mejora_jugador + 1;
    }
}
