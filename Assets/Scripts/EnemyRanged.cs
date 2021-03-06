﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRanged : MonoBehaviour {

	public GameObject player;
	Vector3 playerPos;
	public float speed = 20;
	public float minRange;
	public GameObject shotThingymabob;
	public Transform thingymabobSpawn;
	public bool hasShot = false;
	public bool shooting = false;
	void Start () 
	{
		player = GameObject.FindWithTag ("Player");
	}
	void Update ()
	{
		playerPos = player.transform.position;
		Vector3 diff = playerPos - transform.position;
		diff.Normalize();
		float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
		thingymabobSpawn.rotation = Quaternion.Euler(0f, 0f, rot_z - 90);
	}

	void FixedUpdate () 
	{


		if (Vector2.Distance (transform.position, playerPos) >= minRange) 
		{
			transform.position = Vector2.MoveTowards (transform.position, playerPos, speed * Time.deltaTime);
		}
		if (Vector2.Distance (transform.position, playerPos) <= minRange && hasShot == false && shooting == false) 
		{
			Shoot ();
		}
		if (hasShot == true && shooting == false) 
		{
			StartCoroutine (Reload());
		}
	}

	void Shoot()
	{
		hasShot = true;
		var thingymabob = (GameObject)Instantiate(
			shotThingymabob,
			thingymabobSpawn.position,
			thingymabobSpawn.rotation);
		thingymabob.GetComponent<Rigidbody2D> ().velocity = thingymabob.transform.up * 9;
		Destroy (thingymabob, 2.0f);
	}

	IEnumerator Reload ()
	{
		shooting = true;
		yield return new WaitForSeconds(2f);
		hasShot = false;
		shooting = false;
		Debug.Log ("shots fired");

	}
}
