using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destruir : MonoBehaviour
{
    Animator mA;
    [SerializeField]
    
    private void Start()
    {
        mA = GetComponent<Animator>();
    }

    /// <summary>
    /// Llamar desde la animación
    /// </summary>
    void DestruirObjeto()
    {
        Destroy(gameObject);
    }
}
