using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Cuando hago click en la pantalla ejecuta una animacion de la camara de forma aleatoria
/// </summary>
public class ControlDisparo : MonoBehaviour
{
    
    public GameObject agujeroDeBalaAzul;
    public GameObject agujeroDeBalaSuelo;
    public GameObject agujeroDeBalaDianaPato;
    public int municionNube;

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && GameControl.municion > 0 && GameControl.tiempo > 0)
        {
            GastarBala();
            AgujeroDeBala();
        }
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            AgujeroDeBalaMovil();
            GastarBala();
        }
    }
    void GastarBala()
    {
        GameControl.municion--;
    }

    /// <summary>
    /// AgujeroDeBala nos dirá la posición del ratón al clickear y así crear el sprite en su localización
    /// </summary>
    void AgujeroDeBala()
    {
        RaycastHit2D _impacto;
        
        //Nos transforma el vecto3 de la pantalla ha la pantalla de nuestro juego
        Vector3 _mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        // Lanzamos un rayo en la posicion mousePos a traves del eje Z
        _impacto = Physics2D.Raycast(_mousePos, Vector2.zero);
        Vector3 agujeroPos = new Vector3(_mousePos.x, _mousePos.y, 0);
        if (_impacto)
        {
            //instancia el prefac del agujero, dentro del pbjeto que hemos impactado
            //Instantiate(agujeroDeBala, agujeroPos, Quaternion.identity, _impacto.collider.transform);
            //Debug.Log(_impacto.collider.transform.name);
            if(_impacto.collider.transform.tag == ("ParedAzul"))
            {
                agujeroDeBalaAzul.GetComponent<SpriteRenderer>().sortingLayerName = _impacto.collider.gameObject.GetComponent<SpriteRenderer>().sortingLayerName;
                agujeroDeBalaAzul.GetComponent<SpriteRenderer>().sortingOrder = _impacto.collider.gameObject.GetComponent<SpriteRenderer>().sortingOrder;

                Instantiate(agujeroDeBalaAzul, agujeroPos, Quaternion.identity, _impacto.collider.transform);
                
            }
            else if (_impacto.collider.transform.tag == ("Suelo"))
            {
                agujeroDeBalaSuelo.GetComponent<SpriteRenderer>().sortingLayerName = _impacto.collider.gameObject.GetComponent<SpriteRenderer>().sortingLayerName;
                agujeroDeBalaSuelo.GetComponent<SpriteRenderer>().sortingOrder = _impacto.collider.gameObject.GetComponent<SpriteRenderer>().sortingOrder;

                Instantiate(agujeroDeBalaSuelo, agujeroPos, Quaternion.identity, _impacto.collider.transform);
                
            }
            else if(_impacto.collider.transform.CompareTag("Diana"))
            {
                agujeroDeBalaDianaPato.GetComponent<SpriteRenderer>().sortingLayerName = _impacto.collider.gameObject.GetComponent<SpriteRenderer>().sortingLayerName;
                agujeroDeBalaDianaPato.GetComponent<SpriteRenderer>().sortingOrder = _impacto.collider.gameObject.GetComponent<SpriteRenderer>().sortingOrder;

                Instantiate(agujeroDeBalaDianaPato, agujeroPos, Quaternion.identity, _impacto.collider.transform);

                Destroy(_impacto.collider.gameObject);
                GameControl.puntuacion += Diana.puntuacionPorDiana;
                GameControl.velocidadDiana += 0.1f;

            }
            else if(_impacto.collider.transform.CompareTag("Nube"))
            {
                GameControl.municion += municionNube;
                Destroy(_impacto.collider.gameObject);

                GameControl.velocidadNube += 0.05f;
            }
            else           
            {
                agujeroDeBalaDianaPato.GetComponent<SpriteRenderer>().sortingLayerName = _impacto.collider.gameObject.GetComponent<SpriteRenderer>().sortingLayerName;
                agujeroDeBalaDianaPato.GetComponent<SpriteRenderer>().sortingOrder = _impacto.collider.gameObject.GetComponent<SpriteRenderer>().sortingOrder;

                Instantiate(agujeroDeBalaDianaPato, agujeroPos, Quaternion.identity, _impacto.collider.transform);
                
                Destroy(_impacto.collider.gameObject);
                GameControl.puntuacion += ControlPatitos.puntuacionPorPato;
                GameControl.velocidadPatos += 0.02f;
                GameControl.tiempo += 5;
            }
        }     
       
    }
    void AgujeroDeBalaMovil()
    {
        RaycastHit2D _impacto;
        Touch touch = Input.GetTouch(0);
        //Nos transforma el vecto3 de la pantalla ha la pantalla de nuestro juego
        Vector3 _mousePos = Camera.main.ScreenToWorldPoint(touch.position);
        // Lanzamos un rayo en la posicion mousePos a traves del eje Z
        _impacto = Physics2D.Raycast(_mousePos, Vector2.zero);
        Vector3 agujeroPos = new Vector3(_mousePos.x, _mousePos.y, 0);
        if (_impacto)
        {
            //instancia el prefac del agujero, dentro del pbjeto que hemos impactado
            //Instantiate(agujeroDeBala, agujeroPos, Quaternion.identity, _impacto.collider.transform);
            //Debug.Log(_impacto.collider.transform.name);
            if (_impacto.collider.transform.tag == ("ParedAzul"))
            {
                agujeroDeBalaAzul.GetComponent<SpriteRenderer>().sortingLayerName = _impacto.collider.gameObject.GetComponent<SpriteRenderer>().sortingLayerName;
                agujeroDeBalaAzul.GetComponent<SpriteRenderer>().sortingOrder = _impacto.collider.gameObject.GetComponent<SpriteRenderer>().sortingOrder;

                Instantiate(agujeroDeBalaAzul, agujeroPos, Quaternion.identity, _impacto.collider.transform);

            }
            else if (_impacto.collider.transform.tag == ("Suelo"))
            {
                agujeroDeBalaSuelo.GetComponent<SpriteRenderer>().sortingLayerName = _impacto.collider.gameObject.GetComponent<SpriteRenderer>().sortingLayerName;
                agujeroDeBalaSuelo.GetComponent<SpriteRenderer>().sortingOrder = _impacto.collider.gameObject.GetComponent<SpriteRenderer>().sortingOrder;

                Instantiate(agujeroDeBalaSuelo, agujeroPos, Quaternion.identity, _impacto.collider.transform);

            }
            else if (_impacto.collider.transform.CompareTag("Diana"))
            {
                agujeroDeBalaDianaPato.GetComponent<SpriteRenderer>().sortingLayerName = _impacto.collider.gameObject.GetComponent<SpriteRenderer>().sortingLayerName;
                agujeroDeBalaDianaPato.GetComponent<SpriteRenderer>().sortingOrder = _impacto.collider.gameObject.GetComponent<SpriteRenderer>().sortingOrder;

                Instantiate(agujeroDeBalaDianaPato, agujeroPos, Quaternion.identity, _impacto.collider.transform);

                Destroy(_impacto.collider.gameObject);
                GameControl.puntuacion += Diana.puntuacionPorDiana;
                GameControl.velocidadDiana += 0.1f;

            }
            else if (_impacto.collider.transform.CompareTag("Nube"))
            {
                GameControl.municion += municionNube;
                Destroy(_impacto.collider.gameObject);

                GameControl.velocidadNube += 0.05f;
            }
            else
            {
                agujeroDeBalaDianaPato.GetComponent<SpriteRenderer>().sortingLayerName = _impacto.collider.gameObject.GetComponent<SpriteRenderer>().sortingLayerName;
                agujeroDeBalaDianaPato.GetComponent<SpriteRenderer>().sortingOrder = _impacto.collider.gameObject.GetComponent<SpriteRenderer>().sortingOrder;

                Instantiate(agujeroDeBalaDianaPato, agujeroPos, Quaternion.identity, _impacto.collider.transform);

                Destroy(_impacto.collider.gameObject);
                GameControl.puntuacion += ControlPatitos.puntuacionPorPato;
                GameControl.velocidadPatos += 0.02f;
                GameControl.tiempo += 5;
            }
        }

    }

}
