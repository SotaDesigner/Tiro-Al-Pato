using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlPatitos : MonoBehaviour
{
    //variable tipo Animator para poder modificar la velocidad de la animación
    Animator controlador;
    //Usamos SerializerField para mostrar una variable privada en Unity
    [SerializeField]
    //La variable velocidad cambiará la velocidad de la animacion
    public float velocidad;
    public static int puntuacionPorPato;

    Transform generadorDePatos;

    void Start()
    {
        generadorDePatos = GameObject.FindGameObjectWithTag("GeneradorPatos").GetComponent<Transform>();
        //inicialización del Animator
        controlador = GetComponent<Animator>();
        velocidad = GameControl.velocidadPatos;
        controlador.speed = velocidad/5;
        Mathf.Round(velocidad);
        puntuacionPorPato = (int)velocidad * 2;
    }

    /// <summary>
    /// Será llamada desde la animación
    /// </summary>
    void Destruir()
    {
        Destroy(gameObject);
    }
}
