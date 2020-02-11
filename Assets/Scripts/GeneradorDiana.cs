using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneradorDiana : MonoBehaviour
{
    public GameObject[] diana;
    float siguienteInvocacion;

    void Start()
    {
        float primeraDiana = Random.Range(5, 10);
        siguienteInvocacion = Random.Range(10, 20);
        InvokeRepeating("InctanciarPatos", primeraDiana, siguienteInvocacion);
    }

    void InctanciarPatos()
    {
        int nDiana;
        nDiana = Random.Range(0, diana.Length);
        Instantiate(diana[nDiana], Vector(), Quaternion.identity);
    }
    Vector3 Vector()
    {
        Vector3 posicionDiana = new Vector3(transform.position.x, transform.position.y);
        return posicionDiana;
    }
}
