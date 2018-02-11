using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusScript : MonoBehaviour {

    public GameObject eventSystem;
    public GameObject[] foods = new GameObject[6];

    private int c;
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
