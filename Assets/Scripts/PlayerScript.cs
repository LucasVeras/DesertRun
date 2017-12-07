﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour {

	public int health = 100;
	public int playerSpeed = 10;
	public int playerJumpPower = 1250;

	private float moveX;
	private float velocityY = 0;

	private bool isDead = false;
	private bool isOnGround = true;
	private bool wonScene = false;

	void Update(){
		if (!wonScene) {
			if (!isDead || wonScene){
				PlayerMove ();
			}
		}
	}

	void PlayerMove(){
		moveX = Input.GetAxis ("Horizontal");

		if (Input.GetKey (KeyCode.UpArrow)){
			if (isOnGround){
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
		GetComponent<Rigidbody2D> ().AddForce (Vector2.up * playerJumpPower);
		isOnGround = false;

	}

	void Die(){
		isDead = true;

		GetComponent<Animator> ().SetBool ("isDying", true);
	}
		
	void OnTriggerEnter2D(Collider2D obj) {
		switch (obj.gameObject.tag){
		case "Enemy":
			health -= 50;

			if (health <= 0) { 
				Die ();
			}

			break;
		case "Ground":
			GetComponent<Animator> ().SetBool ("isJumping", false);

			break;
		case "Life":
			Destroy (obj.gameObject);

			health += 50;
			break;
		case "WinScene":
			wonScene = true;

			break;
		}
	}
		
	void OnCollisionEnter2D(Collision2D collision){
		if(collision.contacts.Length > 0){
			ContactPoint2D contact = collision.contacts[0];
			if(Vector3.Dot(contact.normal, Vector3.up) > 0.5){
				isOnGround = true;
				Debug.Log("Collision on Bottom");
			}
		}
	}
}
