using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickAumentoSuma1 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void OnMouseDown()
    {
        if (Clicable.puntos > GameManager.coste_clicador)
        {
            GameManager.numero_clicador++;
            GameManager.coste_clicador *= 2;
        }
    }
}
