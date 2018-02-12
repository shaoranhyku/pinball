//////////////////////////////////
// Práctica: Pinball
// Alumno/a: Francisco Javier Florín Cárdenas
// Curso: 2017/18
// Fichero: TurboScript.cs
/////////////////////////////////
using UnityEngine;

public class TurboScript : MonoBehaviour {

    // Fuerza con la que se lanzará la bola
    public float force = 3f;

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            collision.gameObject.GetComponent<Rigidbody>().AddForce(Vector3.forward * force);
            GetComponent<AudioSource>().Play();
            GameManager.points += 200;
        }

    }
}
