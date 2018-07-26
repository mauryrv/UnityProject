using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class GameController : MonoBehaviour {


	private int currentScore = 0;
	public Text scoreText;
	public AudioSource inGameAudio;
	public Text timerText;
	private float time = 10;


	// Use this for initialization
	void Start () {
		inGameAudio.Play ();

		scoreText.text = "Score: 0";
	}
	
	// Update is called once per frame
	void Update () {
		time -= Time.deltaTime;

		timerText.text = "Time left: " + (int)time + " s";

		if ((int)time == 0) {

			if (currentScore >= 400) {
				// carrega a cena de que venceu
				SceneManager.LoadScene (3);
			} else {
				// carrega a cena que perdeu
				SceneManager.LoadScene (2);
			}
		}

	}

	public void UpdateScore(int score){

		currentScore += score;

		scoreText.text = "Score: " + currentScore; 
	}


}
