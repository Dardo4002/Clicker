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
        if (Clicable.puntos > GameManager.costeaumentosuma1)
        {
            GameManager.suma1++;
            GameManager.costeaumentosuma1 *= 2;
        }
    }
}
