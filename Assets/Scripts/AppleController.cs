using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AppleController : MonoBehaviour {


	private Rigidbody2D rigidBody;

	public GameController gameControl;
	public AudioSource appleHittedAudio;
	public AudioSource playerGotAppleAudio;


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
			|| collision.collider.tag == "Apple") {

			appleHittedAudio.Play ();

			rigidBody.isKinematic = false;
			rigidBody.AddRelativeForce(-0.2f * collision.relativeVelocity);
		}

		if (collision.collider.tag == "Player") {

			playerGotAppleAudio.Play ();
			UpdateScore (100);
			Destroy (gameObject);

		} else if (collision.collider.tag == "Ground") {

			appleHittedAudio.Play ();
			Destroy (gameObject);

		}
	}

	void UpdateScore(int newScore){
		gameControl.UpdateScore (newScore);
	}



}
