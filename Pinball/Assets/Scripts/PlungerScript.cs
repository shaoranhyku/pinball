using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlungerScript : MonoBehaviour {

    public float maxPower = 100f;
    public Slider powerSlider;
    public AudioClip chargeSound;
    public AudioClip launchSound;

    private float power;
    private List<Rigidbody> ballList;
    private bool ballReady;
    private AudioSource audioSource;
    private bool audioPlayed = false;

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
