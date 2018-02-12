//////////////////////////////////
// Práctica: Pinball
// Alumno/a: Francisco Javier Florín Cárdenas
// Curso: 2017/18
// Fichero: BonusSCript.cs
/////////////////////////////////
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodGeneratorScript : MonoBehaviour {

    // GameObject que instanciará
    public GameObject[] foods = new GameObject[6];

    // Use this for initialization
    void Start () {
        StartCoroutine(GenerateFood());
    }

    private IEnumerator GenerateFood()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(4, 10));
            GameObject food = Instantiate(foods[Random.Range(0, foods.Length)]);
            food.GetComponent<Transform>().position = new Vector3(Random.Range(7f, 10f), 0.3f, Random.Range(-1f, 4f));
            GetComponent<AudioSource>().Play();
        }
    }
}
