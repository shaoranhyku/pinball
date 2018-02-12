//////////////////////////////////
// Práctica: Pinball
// Alumno/a: Francisco Javier Florín Cárdenas
// Curso: 2017/18
// Fichero: EventSystem.cs
/////////////////////////////////
using UnityEngine;
using UnityEngine.UI;

public class EventSystem : MonoBehaviour {

	// Texto que mostrará los puntos
    public Text pointsText;
	// Texto que mostrará las vidas
    public Text lifesText;
	
	// Update is called once per frame
	void Update () {
        pointsText.text = GameManager.points.ToString();
        lifesText.text = GameManager.lifes.ToString();
	}
}
