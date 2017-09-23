using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthShroom : MonoBehaviour {

	public GameObject player;
	Vector3 playerPos;
	Vector3 playerCurPos;
	public float speed = 20;
	float animRange;
	public float minRange;
	public float maxRange;
	public bool fleeing;
	void Start () 
	{
		player = GameObject.FindWithTag ("Player");
		animRange = minRange + 1;
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

		if (Vector2.Distance (transform.position, playerPos) <= minRange) 
		{
			transform.position = Vector2.MoveTowards (transform.position, playerPos, -speed * Time.deltaTime);
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
}
