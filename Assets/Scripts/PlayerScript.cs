using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour {

	public int playerSpeed = 10;
	public int playerJumpPower = 1250;

	private float moveX;
	private bool isJumping = false;

	void Update(){
		PlayerMove ();
	}

	void PlayerMove(){
		moveX = Input.GetAxis ("Horizontal");

		if (Input.GetButtonDown ("Jump")){
			if (!isJumping){
				isJumping = true;

				Jump ();
			}

			GetComponent<Animator> ().SetBool ("isJumping", true);
			GetComponent<Animator> ().SetBool ("isRunning", false);
		}

		if (moveX != 0) {
			GetComponent<Animator> ().SetBool ("isRunning", true);
		} else {
			GetComponent<Animator> ().SetBool ("isRunning", false);
		}

		if (moveX < 0.0f) {
			GetComponent<SpriteRenderer> ().flipX = true;
		} else if (moveX > 0.0f){
			GetComponent<SpriteRenderer> ().flipX = false;
		}

		gameObject.GetComponent<Rigidbody2D> ().velocity = new Vector2 (moveX * playerSpeed, gameObject.GetComponent<Rigidbody2D> ().velocity.y);
	}

	void Jump() {
		GetComponent<Rigidbody2D> ().AddForce (Vector2.up * playerJumpPower);
	}


		
}
