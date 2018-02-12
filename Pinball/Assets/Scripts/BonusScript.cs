//////////////////////////////////
// Práctica: Pinball
// Alumno/a: Francisco Javier Florín Cárdenas
// Curso: 2017/18
// Fichero: BonusSCript.cs
/////////////////////////////////

using System.Collections;
using UnityEngine;

public class BonusScript : MonoBehaviour {

    // GameObject que representa el eventSystem, usado para bajar el volumen de la música
    public GameObject eventSystem;
    // GameObjects que instanciará el script
    public GameObject[] foods = new GameObject[6];

    // Contador de GameObjects instanciados
    private int c;
    // Posicion inicial de la bola
    private Vector3 initialPosition;

    private void Start()
    {
        initialPosition = GetComponent<Transform>().position;
    }

    private void OnCollisionEnter(Collision collision)
    {
        eventSystem.GetComponent<AudioSource>().volume = 0f;
        GameManager.bonus = true;
        GetComponent<AudioSource>().Play();
        c = 0;
        StartCoroutine(Bonus());
        StartCoroutine(Respawn());
    }

    private IEnumerator Respawn()
    {
        GetComponent<Transform>().position = new Vector3(initialPosition.x, -5, initialPosition.z);
        yield return new WaitForSeconds(45);
        GetComponent<Transform>().position = initialPosition;

        yield break;
    }

    private IEnumerator Bonus()
    {
        while (c < 9)
        {
            GameObject food = Instantiate(foods[UnityEngine.Random.Range(0, foods.Length)]);
            food.GetComponent<Transform>().position = new Vector3(UnityEngine.Random.Range(7f, 10f), 0.3f, UnityEngine.Random.Range(-1f, 4f));
            c++;
            yield return new WaitForSeconds(1);
        }
        GameManager.bonus = false;
        GetComponent<AudioSource>().Stop();
        eventSystem.GetComponent<AudioSource>().volume = 0.4f;
        yield break;
    }
}
