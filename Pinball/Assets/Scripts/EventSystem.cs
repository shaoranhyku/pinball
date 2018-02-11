using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EventSystem : MonoBehaviour {

    public Text pointsText;
    public Text lifesText;
	
	// Update is called once per frame
	void Update () {
        pointsText.text = GameManager.points.ToString();
        lifesText.text = GameManager.lifes.ToString();
	}
}
