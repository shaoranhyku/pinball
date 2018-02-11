using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncerScript : MonoBehaviour {

    public Texture texturaCambiar;

    private Renderer render;
    private Texture texturaOriginal;
    private bool active = true;

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