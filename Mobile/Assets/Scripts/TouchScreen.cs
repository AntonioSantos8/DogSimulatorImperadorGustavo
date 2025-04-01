using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchScreen : MonoBehaviour
{
    Vector2 inicialPos;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            inicialPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
        if (Input.GetButtonUp("Fire1"))
        {
            Vector2 finalPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if(finalPos.x < inicialPos.x)
            {
                print("Esquerda");
            }
            if (finalPos.x > inicialPos.x)
            {
                print("Direita");
            }
        }
    }
}
