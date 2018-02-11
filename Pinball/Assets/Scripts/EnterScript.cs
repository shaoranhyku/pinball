using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterScript : MonoBehaviour {

    public GameObject wall;

    private Vector3 initPosition;

    private void Start()
    {
        initPosition = wall.GetComponent<Transform>().position;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Ball"))
        {
            wall.GetComponent<Transform>().position = new Vector3(initPosition.x, 0f, initPosition.z);
        }
    }
}
