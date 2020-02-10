using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatoClick : MonoBehaviour
{
    public int vida = 3;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //click

    private void OnMouseDown()
    {
        Debug.Log("Pinchado");

        vida--;

        if (vida == 0)
        {
            Destroy(gameObject);
        }

    }
}
