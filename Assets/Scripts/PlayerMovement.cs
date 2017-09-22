using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {


	public float speed = 10;
	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void FixedUpdate () {
		float mx = Input.GetAxis("Horizontal");
		float my = Input.GetAxis("Vertical");

		Vector3 movement = new Vector3(mx, my, 0.0f);
		transform.Translate(movement * speed * Time.deltaTime);

	}
}
