using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nube : MonoBehaviour
{
    Animator mA;
    [SerializeField]
    public int masMunicion;
    private void Start()
    {
        mA = GetComponent<Animator>();
    }
    private void OnMouseDown()
    {
        GameControl.municion += masMunicion;
        Destroy(gameObject);
    }
    /// <summary>
    /// Llamar desde la animación
    /// </summary>
    void DestruirObjeto()
    {
        Destroy(gameObject);
    }
}
