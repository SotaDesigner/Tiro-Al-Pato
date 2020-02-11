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
    public Text textPutuacionFinal;
    public Text textoPuntuacionMaxima;
    public static float velocidadPatos;
    public static float velocidadDiana;
    public static float velocidadNube;
    public static int municion = 50;
    public static int tiempo = 50;
    public static int puntuacionMaxima;
    public GameObject panelGameOver;
    int municionInicio;
    bool juegoTerminado = false;

    private void Start()
    {
        puntuacionMaxima = PlayerPrefs.GetInt("mScore");
        velocidadPatos = 1;
        velocidadDiana = velocidadPatos;
        velocidadNube = velocidadPatos;
        municionInicio = municion;
        InvokeRepeating("RestarTiempo", 0.3f, 0.3f);
    }
    void Update()
    {
        textPuntuacion.text = puntuacion.ToString();
        textMunicion.text = municion.ToString();
        textTiempo.text = tiempo.ToString(); 
        if(municion <= 0 && !juegoTerminado|| tiempo <= 0 && !juegoTerminado)
        {
            juegoTerminado = true;
            panelGameOver.SetActive(true);
            textPutuacionFinal.text = textPuntuacion.text;
            GuardarPuntuacion();
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
        if(tiempo > 0)
        tiempo -= 1;
    }

    public void Salir()
    {
        Application.Quit();
    }
    public void Reiniciar()
    {
        panelGameOver.SetActive(false);
        SceneManager.LoadScene(1);
        municion = 50;
        tiempo = 50;
        puntuacion = 0;
    }

    public void GuardarPuntuacion()
    {
        if(puntuacionMaxima < puntuacion)
        {
            puntuacionMaxima = puntuacion;
            textoPuntuacionMaxima.text = puntuacionMaxima.ToString();
            PlayerPrefs.SetInt("mScore", puntuacionMaxima);
        }
        else
        {
            textoPuntuacionMaxima.text = puntuacionMaxima.ToString();
        }
    }
}
