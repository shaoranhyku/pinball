using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurboScript : MonoBehaviour {

    public float force = 3f;

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            collision.gameObject.GetComponent<Rigidbody>().AddForce(Vector3.forward * force);
        }

    }
}
