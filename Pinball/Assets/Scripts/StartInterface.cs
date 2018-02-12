using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartInterface : MonoBehaviour {

	// Use this for initialization
	void Start ()
	{
		GameManager.points = 0;
		GameManager.lifes = 2;
		GameManager.bonus = false;
	}
	
	public void Click()
	{
		SceneManager.LoadScene("Pinball");
	}
}
