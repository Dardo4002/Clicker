using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clicable : MonoBehaviour
{
    [SerializeField] static public float puntos = 0;
    void Start()
    {
    }
    private void OnMouseDown()
    {
        puntos++;
    }
}
