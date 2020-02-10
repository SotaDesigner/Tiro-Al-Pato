using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneradorDePatos : MonoBehaviour
{
    
    public GameObject[] patos;


    void Start()
    {
        InvokeRepeating("InctanciarPatos", 1, 1);
    }

    void InctanciarPatos()
    {
        int nPato;
        nPato = Random.Range(0, patos.Length);
        Instantiate(patos[nPato], VectorRandon(), Quaternion.identity);   
    }

    Vector3 VectorRandon()
    {
        Vector3 posicionPato = new Vector3(transform.position.x , Random.Range(-2, 3), 0);
        return posicionPato;
    }
}
