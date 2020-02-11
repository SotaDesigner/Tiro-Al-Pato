using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameControl : MonoBehaviour
{
    public static int puntuacion = 0;
    public Text textPuntuacion;
    public Text textMunicion;
    public Text textTiempo;
    public static float velocidadPatos;
    public static int municion;
    public static int tiempo;
    int municionInicio;


    private void Start()
    {
        velocidadPatos = 1;
        municionInicio = municion;
        InvokeRepeating("RestarTiempo", 0.5f, 0.5f);
    }
    void Update()
    {
        textPuntuacion.text = puntuacion.ToString();
        textMunicion.text = municion.ToString();
        if(municion < 0)
        {
            Time.timeScale = 0;
        }
    }

    public void Restart()
    {
        puntuacion = 0;
        municion = municionInicio;
        SceneManager.LoadScene(0);
    }

    public void RestarTiempo()
    {
        tiempo -= 1;
    }
}
