using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour {

	public int health = 100;

	public int playerSpeed = 10;
	public int playerJumpPower = 1250;

	private float moveX;
	private bool isJumping = false;
	private bool isDead = false;
	private bool isOnGround = true;
	private float velocityY = 0;

	void Update(){
		if (!isDead){
			velocityY = gameObject.GetComponent<Rigidbody2D> ().velocity.y;

			if (velocityY == 0) {
				GetComponent<Animator> ().SetBool ("isJumping", false);

				isJumping = false;
			}

			PlayerMove ();
		}
	}

	void PlayerMove(){
		moveX = Input.GetAxis ("Horizontal");

		if (Input.GetKey (KeyCode.UpArrow)){
			if (!isJumping){
				isJumping = true;

				Jump ();
			}

			GetComponent<Animator> ().SetBool ("isJumping", true);
		}

		if (moveX != 0 && velocityY == 0) {
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
		if (isOnGround == true) {
			GetComponent<Rigidbody2D> ().AddForce (Vector2.up * playerJumpPower);
			isOnGround = false;
		}
	}

	void Die(){
		isDead = true;

		GetComponent<Animator> ().SetBool ("isDying", true);
	}
		
	void OnTriggerEnter2D(Collider2D obj) {
		Debug.Log(obj.gameObject.tag);

		if (obj.gameObject.tag == "Enemy") {
			health -= 50;

			if (health <= 0) { 
				Die ();
			}
		} else if (obj.gameObject.tag == "Ground") {
			isOnGround = true;
		}
	}
		
}
