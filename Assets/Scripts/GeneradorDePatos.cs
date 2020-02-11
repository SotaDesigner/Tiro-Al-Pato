using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneradorDePatos : MonoBehaviour
{
    
    public GameObject[] patos;
    public float tiempoInvocacion;

    void Start()
    {
        InvokeRepeating("InctanciarPatos", 1, tiempoInvocacion);
    }

    void InctanciarPatos()
    {
        int nPato;
        nPato = Random.Range(0, patos.Length);
        Instantiate(patos[nPato], VectorRandon(), Quaternion.identity);   
    }

    Vector3 VectorRandon()
    {
        Vector3 posicionPato = new Vector3(transform.position.x , transform.position.y);
        return posicionPato;
    }
}
