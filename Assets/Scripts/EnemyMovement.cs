using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

	public GameObject player;
	Vector3 playerPos;
	public float speed = 10;

	void Start () 
	{
		
	}
	void Update ()
	{
		playerPos = player.transform.position;
	}

	void FixedUpdate () 
	{
		


		transform.position = Vector2.MoveTowards(transform.position, playerPos, speed * Time.deltaTime);

	}
}
