
using UnityEngine;
using System.Collections;

public class CharacterController : MonoBehaviour {

	public float moveHorizontal;
	public float speed = 0.2f;
	public AudioSource walkingAudio;
	private int lastAnimationState = 0;
	private SpriteRenderer spriteRenderer;

	private Animator animator;

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator> ();
		spriteRenderer = GetComponent<SpriteRenderer> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		moveHorizontal = Input.GetAxis ("Horizontal");

		float move = moveHorizontal * speed;

		if (move < 0 || move > 0) {
			if (!walkingAudio.isPlaying) {
				walkingAudio.Play ();
			}

			if (move < 0) {
				spriteRenderer.flipX = true;
			} else {
				spriteRenderer.flipX = false;
			}

			if (lastAnimationState != 1) {
				lastAnimationState = 1;
				animator.SetInteger ("State", lastAnimationState);
			}


		} else {
			walkingAudio.Stop ();
			if (lastAnimationState != 0) {
				lastAnimationState = 0;
				animator.SetInteger ("State", lastAnimationState);
			}
		}

		transform.Translate (new Vector2 (move, 0));
	}
}
