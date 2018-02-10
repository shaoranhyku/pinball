using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncerScript : MonoBehaviour {

    public Texture texturaCambiar;

    private Renderer render;
    private Texture texturaOriginal;

    // Use this for initialization
    void Start()
    {
        render = GetComponent<Renderer>();
        texturaOriginal = render.material.GetTexture("_MainTex");
    }

    // Update is called once per frame
    void Update()
    {

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
            StartCoroutine(RestoreColor());
        }
    }

    private IEnumerator RestoreColor()
    {
        yield return new WaitForSeconds(4);
        render.material.SetTexture("_MainTex", texturaOriginal);
    }
}