using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpScript : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ball"))
        {
            GetComponent<AudioSource>().Play();
            GameManager.points += 100;
            StartCoroutine(DestroyDelay());
        }
    }

    private IEnumerator DestroyDelay()
    {
        GetComponent<Collider>().enabled = false;
        GetComponent<MeshRenderer>().enabled = false;
        yield return new WaitForSeconds(1);
        Destroy(gameObject);
        yield break;
    }
}
