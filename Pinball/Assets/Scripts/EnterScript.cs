//////////////////////////////////
// Práctica: Pinball
// Alumno/a: Francisco Javier Florín Cárdenas
// Curso: 2017/18
// Fichero: EnterSCript.cs
/////////////////////////////////
using UnityEngine;

public class EnterScript : MonoBehaviour {

    // Muro que se moverá una vez pasada la bola
    public GameObject wall;
    
    // Posición inicial del muro
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
