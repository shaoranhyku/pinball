using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathScript : MonoBehaviour {

    public GameObject wall;
    public GameObject system;

    private Vector3 initPosition;

    private void Start()
    {
        initPosition = wall.GetComponent<Transform>().position;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Ball"))
        {
            StartCoroutine(Death(other.gameObject));
        }
        
    }

    private IEnumerator Death(GameObject other)
    {
        system.GetComponent<AudioSource>().volume = 0f;
        GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(2.7f);
        if (GameManager.lifes > 0)
        {
            if (!GameManager.bonus)
            {
                system.GetComponent<AudioSource>().volume = 0.4f;
            }
            wall.GetComponent<Transform>().position = new Vector3(initPosition.x, 0.5f, initPosition.z);
            other.GetComponent<Transform>().position = new Vector3(12.02f, 0.4f, -6.5f);
            other.GetComponent<AudioSource>().Play();
            GameManager.lifes--;
        }
        yield break;
    }

}
