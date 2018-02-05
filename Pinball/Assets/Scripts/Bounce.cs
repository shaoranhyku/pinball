using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounce : MonoBehaviour {

    public Color changeColor;

    private MeshRenderer mesh;
    private Color capsuleColor;
    private float force = 4f;

    // Use this for initialization
    void Start () {
        mesh = GetComponent<MeshRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            capsuleColor = mesh.material.GetColor("_Color");
            mesh.material.SetColor("_Color", changeColor);
            GetComponent<AudioSource>().Play();

            // Calculate Angle Between the collision point and the player
            Vector3 dir = collision.contacts[0].point - transform.position;
            // We then get the opposite (-Vector3) and normalize it
            dir = -dir.normalized;
            // And finally we add force in the direction of dir and multiply it by force. 
            // This will push back the player
            collision.gameObject.GetComponent<Rigidbody>().AddForce(dir * force, ForceMode.Impulse);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            mesh.material.SetColor("_Color", capsuleColor);
        }
    }
}
