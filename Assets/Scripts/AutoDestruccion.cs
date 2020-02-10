using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDestruccion : MonoBehaviour
{
    public float timpoVida = 5f;
    void Start()
    {
        Destroy(gameObject, timpoVida);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
