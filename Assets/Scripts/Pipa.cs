using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipa : MonoBehaviour
{
    //Muerte
    [SerializeField] float contador_muerte = 5f;

    //Impulso
    [SerializeField] float random_impulse;
     float random_impulse_angle_x;
    float random_impulse_angle_y;
    [SerializeField] Vector2 vector_random;

    //Tamanho
    [SerializeField] Vector2 tamanho;


    //Angulo y fuerza
    [SerializeField] float random_angle;


    // Start is called before the first frame update
    void Start()
    {

        Rigidbody2D pito = GetComponent<Rigidbody2D>();
        Muerte();
        Angulo();
        Impulso(pito);
        CambioTamanho();
    }

    private void Update()
    {
        
    } 

    //Elimina las pipas después de un tiempo
    void Muerte()
    {
        Destroy(gameObject, contador_muerte);
    }

    //Establece el ángulo de las pipas al ser creadas
    void Angulo()
    {
        random_angle = Random.Range(0f, 360f);
        transform.rotation = Quaternion.Euler(0, 0, random_angle);
    }

    //Establece la fuerza y ángulo de la fuerza con el que las pipas aparecen
    void Impulso(Rigidbody2D pito)
    {
        random_impulse = Random.Range(1f, 5f);
        random_impulse_angle_x = Random.Range(-360f, 360f);
        random_impulse_angle_y = Random.Range(-360f, 360f);

        pito.AddForce(new Vector2(random_impulse_angle_x, random_impulse_angle_y).normalized * random_impulse, ForceMode2D.Impulse);
    }

    void CambioTamanho()
    {
        float tamanho = Random.Range(0.8f, 1.2f);
        transform.localScale = new Vector2(tamanho, tamanho);
    }
}
