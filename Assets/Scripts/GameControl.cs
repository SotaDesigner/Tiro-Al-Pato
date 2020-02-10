using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameControl : MonoBehaviour
{
    public static int puntuacion = 0;
    public Text textPuntuacion;

    void Update()
    {
        textPuntuacion.text = puntuacion.ToString();
    }

    public void Restart()
    {
        puntuacion = 0;
        SceneManager.LoadScene(0);
    }
}
