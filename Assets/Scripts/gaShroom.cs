using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gaShroom : MonoBehaviour {

	public float minRange;
	public float maxRange;
	public GameObject player;
	Vector3 playerPos;

	public float speed = 10;
	public bool gassenings = false;
	public bool fleeing = false;
	public GameObject FunGasCloud;

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
		
		if (Vector2.Distance (transform.position, playerPos) >= minRange && fleeing == false) 
		{
			transform.position = Vector2.MoveTowards (transform.position, playerPos, speed * Time.deltaTime);
		}
		if (Vector2.Distance (transform.position, playerPos) <= minRange && fleeing == true) 
		{
			transform.position = Vector2.MoveTowards (transform.position, playerPos, -speed * Time.deltaTime);
		}
		if (Vector2.Distance (transform.position, playerPos) <= minRange || Vector2.Distance (transform.position, playerPos) == minRange) 
		{
			StartCoroutine(FunGas ());

		}
		if (Vector2.Distance (transform.position, playerPos) >= maxRange && fleeing == true) 
		{
			fleeing = false;
		}
		if (Vector2.Distance (transform.position, playerPos) >= minRange && fleeing == true) 
		{
			transform.position = Vector2.MoveTowards (transform.position, playerPos, -speed * Time.deltaTime);
		}
	}
	IEnumerator FunGas()
	{
		Instantiate (FunGasCloud);
		Destroy (FunGasCloud, 2f);
		yield return new WaitForSeconds (1);
		fleeing = true;
	}	

}
