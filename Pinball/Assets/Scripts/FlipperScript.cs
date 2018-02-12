//////////////////////////////////
// Práctica: Pinball
// Alumno/a: Francisco Javier Florín Cárdenas
// Curso: 2017/18
// Fichero: FlipperScript.cs
/////////////////////////////////
using UnityEngine;

public class FlipperScript : MonoBehaviour {

    // Ángulo de posición de descanso
    public float restPosition = 0f;
    // Ángulo de posición presionado
    public float pressedPosition = 45f;
    // Fuerza del golpe de impacto
    public float hitStrength = 10000f;
    // Fuerza del flipper
    public float flipperDamper = 150f;
    // Nombre de la entrada
    public string inputName;

    private bool soundPlayed = false;
    
    private HingeJoint hingeJoint;

	// Use this for initialization
	void Start () {
        hingeJoint = GetComponent<HingeJoint>();
        hingeJoint.useSpring = true;
	}
	
	// Update is called once per frame
	void Update () {
        JointSpring spring = new JointSpring();
        spring.spring = hitStrength;
        spring.damper = flipperDamper;

		if(Input.GetAxis(inputName) == 1)
        {
            spring.targetPosition = pressedPosition;
            if (!soundPlayed)
            {
                GetComponent<AudioSource>().Play();
                soundPlayed = true;
            }
        }
        else
        {
            soundPlayed = false;
            spring.targetPosition = restPosition;
        }

        hingeJoint.spring = spring;
        hingeJoint.useLimits = true;
	}
}
