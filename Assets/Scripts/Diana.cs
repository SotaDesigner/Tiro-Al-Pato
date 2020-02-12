using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diana : MonoBehaviour
{
    //variable tipo Animator para poder modificar la velocidad de la animación
    Animator controlador;
    //Usamos SerializerField para mostrar una variable privada en Unity
    [SerializeField]
    //La variable velocidad cambiará la velocidad de la animacion
    public float velocidad;
    public static int puntuacionPorDiana;

    Transform generadorDePatos;

    void Start()
    {
        generadorDePatos = GameObject.FindGameObjectWithTag("GeneradorPatos").GetComponent<Transform>();
        //inicialización del Animator
        controlador = GetComponent<Animator>();
        velocidad = GameControl.velocidadDiana;
        controlador.speed = velocidad;
        Mathf.Round(velocidad);
        puntuacionPorDiana = (int)velocidad * 10;
    }

    /// <summary>
    /// Será llamada desde la animación
    /// </summary>
    void Destruir()
    {
        Destroy(gameObject);
    }
}
