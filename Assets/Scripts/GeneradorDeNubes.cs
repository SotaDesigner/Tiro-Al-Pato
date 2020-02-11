﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneradorDeNubes : MonoBehaviour
{
    public GameObject[] nubes;
    float siguienteInvocacion;

    void Start()
    {
        float primeraNube = Random.Range(20, 35);
        InvokeRepeating("InctanciarPatos", primeraNube, siguienteInvocacion);
    }

    void InctanciarPatos()
    {
        int nNubes;
        nNubes = Random.Range(0, nubes.Length);
        siguienteInvocacion = Random.Range(20, 50);
        Instantiate(nubes[nNubes], Vector(), Quaternion.identity);
    }

    Vector3 Vector()
    {
        Vector3 posicionNube = new Vector3(transform.position.x, transform.position.y);
        return posicionNube;
    }
}
