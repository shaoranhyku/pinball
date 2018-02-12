using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndingInterface : MonoBehaviour
{

    public Text pointText;
    
    private void Start()
    {
        pointText.text = String.Format("POINTS: {0}",GameManager.points);
    }

    public void Retry()
    {
        GameManager.points = 0;
        GameManager.lifes = 2;
        GameManager.bonus = false;
        SceneManager.LoadScene("Pinball");
    }

    public void Quit()
    {
        Application.Quit();
    }
    
}
