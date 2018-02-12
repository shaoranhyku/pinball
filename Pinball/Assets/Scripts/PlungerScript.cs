//////////////////////////////////
// Práctica: Pinball
// Alumno/a: Francisco Javier Florín Cárdenas
// Curso: 2017/18
// Fichero: PlungerScript.cs
/////////////////////////////////
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlungerScript : MonoBehaviour {

    // Fuerza del plunger
    public float maxPower = 100f;
    // Slider que mostrará la potencia actual
    public Slider powerSlider;
    // Audio que sonará mientras se acumula potencia
    public AudioClip chargeSound;
    // Audio que sonará al lanzarse la bola
    public AudioClip launchSound;

    // Potencia con la que se lanzará la bola
    private float power;
    // Bolas que colisionan
    private List<Rigidbody> ballList;
    // Indica si hay una bola en el plunger
    private bool ballReady;
    // AudioSource del GameObject
    private AudioSource audioSource;
    // Indica si el audio ha comenzado a sonar
    private bool audioPlayed;

	// Use this for initialization
	void Start () {
        powerSlider.minValue = 0;
        powerSlider.maxValue = maxPower;
        ballList = new List<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
        if (ballReady)
        {
            powerSlider.gameObject.SetActive(true);
        }
        else{
            powerSlider.gameObject.SetActive(false);
        }

        powerSlider.value = power;

        if (ballList.Count > 0)
        {
            ballReady = true;
            if (Input.GetKey(KeyCode.Space))
            {
                if (!audioPlayed)
                {
                    audioSource.clip = chargeSound;
                    audioSource.loop = true;
                    audioSource.Play();
                    audioPlayed = true;
                }
                if (power < powerSlider.maxValue)
                {
                    power += 100 * Time.deltaTime;
                }
            }
            if (Input.GetKeyUp(KeyCode.Space))
            {
                audioPlayed = false;
                audioSource.loop = false;
                audioSource.clip = launchSound;
                audioSource.Play();
                foreach (Rigidbody r in ballList)
                {
                    r.AddForce(power * Vector3.forward);
                }
            }
        }
        else
        {
            ballReady = false;
            power = 0f;
        }
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ball"))
        {
            ballList.Add(other.gameObject.GetComponent<Rigidbody>());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Ball"))
        {
            ballList.Remove(other.gameObject.GetComponent<Rigidbody>());
            power = 0f;
        }
    }
}
