using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shroomcideMovement : MonoBehaviour {

	public float minRange;
	public GameObject player;
	Vector3 playerPos;
	public float speed = 10;
	public bool expshrooming = false;
	public bool kaschroom = false;
	bool gonGit;

	void Awake () 
	{
		player = GameObject.FindWithTag ("Player");
	}
	void Update ()
	{
		playerPos = player.transform.position;
	}

	void FixedUpdate () 
	{

		if (Vector2.Distance (transform.position, playerPos) >= minRange && expshrooming == false) 
		{
			transform.position = Vector2.MoveTowards (transform.position, playerPos, speed * Time.deltaTime);
		}
		if (Vector2.Distance (transform.position, playerPos) <= minRange) 
		{
			StartCoroutine(Mushroomcloud ());
		}
		if (gonGit == true && kaschroom == true) 
		{
			Debug.Log ("gon git");
		}
	}

	IEnumerator Mushroomcloud ()
	{
		expshrooming = true;
		Debug.Log ("tremble");
		yield return new WaitForSeconds (4);
		kaschroom = true;
		yield return new WaitForSeconds (0.5f);
		Destroy(this.gameObject);
	}
	void OnTriggerEnter2D(Collider2D other)
	{
		Debug.Log ("riggered?");
		if (other.tag == "Player") 
		{
			gonGit = true;
		}
	}
}
