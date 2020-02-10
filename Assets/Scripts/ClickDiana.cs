using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickDiana : MonoBehaviour
{
    //Variable tipo Animator
    Animator animator;
    Collider2D _col;

    void Start()
    {
        //Inicializamos animator
        animator = GetComponent<Animator>();
        _col = GetComponent<Collider2D>();
    }

    void OnMouseDown()
    {
        Invoke("DesactivarCollider", 2);
        //al pulsar caerá la diana
        //cuidado con las mayusculas y minusculas
        animator.SetTrigger("Activar");
        //con Ivoke retrasamos la funcion ejecutarAnimación x segundo
        Invoke("ejecutarAnimacion", Random.Range(1,9));
    }

    void ejecutarAnimacion()
    {
        _col.enabled = true;
        animator.SetTrigger("Activar");
    }

    bool DesactivarColider()
    {
        return _col.enabled = false;
    }
}
