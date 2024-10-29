using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Clicable : MonoBehaviour
{
    //cosas de clicable
    [SerializeField] static public float puntos = 0;
    [SerializeField] static public int mejora_jugador = 0;
    [SerializeField] public GameObject pipa;

    //Cambio de tamanhos
    public Vector2 tamanho_normal = Vector2.one;
    public Vector2 escala_cambio_tamanho = new Vector3(0.5f, 0.5f);
    public float duracion_transicion = 0.1f;
    private bool transicionando = false;

    void Start()
    {
    }
    private void OnMouseDown()
    {
        puntos += mejora_jugador + 1;
        CrearPipa();

        
        StartCoroutine(CambioTamanho());
        
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

    //Más magia negra de chatgpt
    IEnumerator CambioTamanho()
    {
        transicionando = true;

        //encogimiento
        yield return StartCoroutine(CambioEscala(tamanho_normal, escala_cambio_tamanho, duracion_transicion));

        //Crecimiento
        yield return StartCoroutine(CambioEscala(escala_cambio_tamanho, tamanho_normal, duracion_transicion));

        transicionando = false;
    }

    IEnumerator CambioEscala(Vector2 desde_escala, Vector2 a_escala, float duracion)
    {
        float elapsed = 0;
        while (elapsed < duracion)
        {
            transform.localScale = Vector2.Lerp(desde_escala, a_escala, elapsed / duracion);
            elapsed += Time.deltaTime;
            yield return null;
        }
        transform.localScale = a_escala;
    }


}
