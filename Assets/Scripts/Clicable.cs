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

    //No te voy a mentir, esto es magia negra de chatgpt xd
    void CrearPipa()
    {
        // Obtener la posición del clic en el mundo
        Vector3 clickPos = Input.mousePosition;

        // Convertir la posición del clic a coordenadas del mundo
        clickPos.z = Camera.main.nearClipPlane; // Puedes ajustar esto según tu necesidad
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(clickPos);

        // Calcular la posición local en el objeto
        Vector3 localPosition = transform.InverseTransformPoint(worldPosition);


        Instantiate(pipa, localPosition, Quaternion.identity);
    }
}
