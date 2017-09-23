using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gaShroom : MonoBehaviour {

	public float minRange;
	public float maxRange;
	public GameObject player;
	Vector3 playerPos;
	Vector3 playerCurPos;
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
		if (fleeing == false) 
		{
			playerCurPos = playerPos;
		}
		if (Vector2.Distance (transform.position, playerPos) >= minRange && fleeing == false) 
		{
			transform.position = Vector2.MoveTowards (transform.position, playerPos, speed * Time.deltaTime);
		}
		if (Vector2.Distance (transform.position, playerPos) <= minRange) 
		{
			gassenings = true;
			fleeing = true;
		}
		if (Vector2.Distance (transform.position, playerCurPos) >= maxRange && fleeing == true) 
		{
			fleeing = false;
		}
		if (Vector2.Distance (transform.position, playerCurPos) >= minRange && fleeing == true) 
		{
			transform.position = Vector2.MoveTowards (transform.position, playerPos, -speed * Time.deltaTime);
		}
	}
	void FunGas()
	{
		Instantiate ();
	}	

}
