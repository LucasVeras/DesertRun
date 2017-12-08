using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {

	private int currentHealth;
	private Text currentTextHealth;

	// Use this for initialization
	void Start () {
		currentTextHealth = gameObject.GetComponentInChildren<Text>(); 
		currentTextHealth.text="2";
		currentHealth = 2;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void loseLife(){
		currentHealth -= 1;

		currentTextHealth.text=""+currentHealth;
	}

	public void gainLife(){
		currentHealth += 1;

		currentTextHealth.text=""+currentHealth;
	}
		
}
