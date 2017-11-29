using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour {

	public Animator animator;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey(KeyCode.LeftArrow))
		{
			GetComponent<SpriteRenderer> ().flipX = true;

			animator.SetBool("Running", true);

			Vector3 position = this.transform.position;
			position.x -= 0.1f;
			this.transform.position = position;


		}

		if (Input.GetKey(KeyCode.RightArrow))
		{
			GetComponent<SpriteRenderer> ().flipX = false;

			animator.SetBool("Running", true);

			Vector3 position = this.transform.position;
			position.x += 0.1f;
			this.transform.position = position;
		}

		if (Input.GetKeyUp(KeyCode.RightArrow) || Input.GetKeyUp(KeyCode.LeftArrow)) {
			animator.SetBool("Running", false);
		}

		if (Input.GetKey (KeyCode.UpArrow)) {
			animator.SetBool("Jumping", true);

			Vector3 position = this.transform.position;
			position.y += 0.1f;
			this.transform.position = position;


		}
	}
}
