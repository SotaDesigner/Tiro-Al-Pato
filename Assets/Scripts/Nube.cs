using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nube : MonoBehaviour
{
    //variable tipo Animator para poder modificar la velocidad de la animación
    Animator controlador;
    //Usamos SerializerField para mostrar una variable privada en Unity
    [SerializeField]
    //La variable velocidad cambiará la velocidad de la animacion
    public float velocidad;

    Transform generadorDePatos;

    void Start()
    {
        generadorDePatos = GameObject.FindGameObjectWithTag("GeneradorPatos").GetComponent<Transform>();
        //inicialización del Animator
        controlador = GetComponent<Animator>();
        velocidad = GameControl.velocidadNube/2;
        controlador.speed = velocidad;
    }
    /// <summary>
    /// Llamar desde la animación
    /// </summary>
    void DestruirObjeto()
    {
        Destroy(gameObject);
    }
}
