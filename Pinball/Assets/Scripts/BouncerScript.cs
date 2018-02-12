//////////////////////////////////
// Práctica: Pinball
// Alumno/a: Francisco Javier Florín Cárdenas
// Curso: 2017/18
// Fichero: BouncerSCript.cs
/////////////////////////////////
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncerScript : MonoBehaviour {

    // Textura el adquirirá el bouncer en la colisión
    public Texture texturaCambiar;
    
    // Renderer del GameObject
    private Renderer render;
    // Textura original del GameObject
    private Texture texturaOriginal;
    // Indica si está activo la obtención de puntos
    private bool active = true;

    // Use this for initialization
    void Start()
    {
        render = GetComponent<Renderer>();
        texturaOriginal = render.material.GetTexture("_MainTex");
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            render.material.SetTexture("_MainTex", texturaCambiar);
            GetComponent<AudioSource>().Play();
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            if (active)
            {
                GameManager.points += 200;
            }
            StartCoroutine(RestoreColor());
        }
    }

    private IEnumerator RestoreColor()
    {
        active = false;
        yield return new WaitForSeconds(4);
        active = true;
        render.material.SetTexture("_MainTex", texturaOriginal);
        yield break;
    }
}