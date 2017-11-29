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

			Vector3 position = this.transform.position;
			position.x -= 0.1f;
			this.transform.position = position;

			animator.Play ("Running");
		}

		if (Input.GetKey(KeyCode.RightArrow))
		{
			GetComponent<SpriteRenderer> ().flipX = false;

			Vector3 position = this.transform.position;
			position.x += 0.1f;
			this.transform.position = position;

			animator.Play ("Running");
		}

		if (Input.GetKeyUp(KeyCode.RightArrow) || Input.GetKeyUp(KeyCode.LeftArrow)) {
			animator.Play ("Idle");
		
		}
	}
}
