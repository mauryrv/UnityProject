using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CoinController : MonoBehaviour {


	private Rigidbody2D rigidBody;

	public GameController gameControl;
	public AudioSource coinHittedAudio;
	public AudioSource playerGotCoinAudio;

	// Use this for initialization
	void Start () {
		rigidBody = GetComponent <Rigidbody2D> ();

		GameObject gameControllerObject = GameObject.FindGameObjectWithTag ("GameController");

		if (gameControllerObject != null) {
			gameControl = gameControllerObject.GetComponent<GameController> ();
		}

	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown (KeyCode.Escape)) {
			Application.Quit ();
		}


	}


	void OnCollisionEnter2D (Collision2D collision) {

        if (collision.collider.tag == "Asteroid"
            || collision.collider.tag == "Coin") {

            coinHittedAudio.Play();

            rigidBody.isKinematic = false;
            rigidBody.AddRelativeForce(-0.2f * collision.relativeVelocity);
        }

        if (collision.collider.tag == "Player") {

            playerGotCoinAudio.Play();
            UpdateScore(100);
            Destroy(gameObject);

        }
        else if (collision.collider.tag == "Ground") {

            coinHittedAudio.Play();
            Destroy(gameObject);

        }
    }

	void UpdateScore(int newScore){
		gameControl.UpdateScore (newScore);
	}



}
