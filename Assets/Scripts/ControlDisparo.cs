using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Cuando hago click en la pantalla ejecuta una animacion de la camara de forma aleatoria
/// </summary>
public class ControlDisparo : MonoBehaviour
{
    
    public Animator anim;
    public GameObject agujeroDeBalaAzul;
    public GameObject agujeroDeBalaSuelo;
    public GameObject agujeroDeBalaDianaPato;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GastarBala();
            Temblar();
            AgujeroDeBala();
        }
    }

    void GastarBala()
    {
        GameControl.municion--;
    }
    /// <summary>
    /// Temblar nos selecionará de manera randon una de las 3 animaciones que tenemos para la cámara 
    /// </summary>
    void Temblar()
    {
        //Nos da el nombre aleatorio
        string nombreTrigger = "Shot" + Random.Range(1, 4);

        //Ejecuta la animación qe anteriormente nos ha dado el string
        anim.SetTrigger(nombreTrigger);
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
                
                GameControl.puntuacion = GameControl.puntuacion + 2;
            }
            else           
            {
                agujeroDeBalaDianaPato.GetComponent<SpriteRenderer>().sortingLayerName = _impacto.collider.gameObject.GetComponent<SpriteRenderer>().sortingLayerName;
                agujeroDeBalaDianaPato.GetComponent<SpriteRenderer>().sortingOrder = _impacto.collider.gameObject.GetComponent<SpriteRenderer>().sortingOrder;

                Instantiate(agujeroDeBalaDianaPato, agujeroPos, Quaternion.identity, _impacto.collider.transform);
                
                Destroy(_impacto.collider.gameObject);
                GameControl.puntuacion += ControlPatitos.puntuacionPorPato;
                GameControl.velocidadPatos += 0.05f;
            }


        }
        
        
        //creamos una nuevo vector para que los agujeros queden a la altura del escenario, si no no se verán ya que sladrá a la altura de la camara. 

       
       
    }

}
