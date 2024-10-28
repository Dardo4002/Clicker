using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Clicable : MonoBehaviour
{
    [SerializeField] static public float puntos = 0;
    [SerializeField] static public int mejora_jugador = 0;
    [SerializeField] public GameObject pipa;
    void Start()
    {
    }
    private void OnMouseDown()
    {
        puntos += mejora_jugador + 1;
        CrearPipa();
    }

    void CrearPipa()
    {
        // Obtener la posici�n del clic en el mundo
        Vector3 clickPos = Input.mousePosition;

        // Convertir la posici�n del clic a coordenadas del mundo
        clickPos.z = Camera.main.nearClipPlane; // Puedes ajustar esto seg�n tu necesidad
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(clickPos);

        // Calcular la posici�n local en el objeto
        Vector3 localPosition = transform.InverseTransformPoint(worldPosition);

        Debug.Log($"Clic en el objeto en posici�n local: {localPosition}");

        Instantiate(pipa, localPosition, Quaternion.identity);
    }
}
