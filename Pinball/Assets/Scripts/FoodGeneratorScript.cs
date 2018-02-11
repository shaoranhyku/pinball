using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodGeneratorScript : MonoBehaviour {

    public GameObject[] foods = new GameObject[6];

    // Use this for initialization
    void Start () {
        StartCoroutine(GenerateFood());
    }
	
	// Update is called once per frame
	void Update () {
		
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
