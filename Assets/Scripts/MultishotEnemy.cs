using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultishotEnemy : MonoBehaviour {

	public GameObject player;
	Vector3 playerPos;
	public float speed = 20;
	public float minRange;
	public GameObject shotThingymabob;
	public Transform[] thingymabobSpawns;
	public bool hasShot = false;
	public bool shooting = false;

	void Start () 
	{
		player = GameObject.FindWithTag ("Player");
	}
	void Update ()
	{
		playerPos = player.transform.position;

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
			thingymabobSpawns[0].position,
			thingymabobSpawns[0].rotation);
		thingymabob.GetComponent<Rigidbody2D> ().velocity = thingymabob.transform.up * 6;
		Destroy (thingymabob, 2.0f);

		var thingymabob2 = (GameObject)Instantiate(
			shotThingymabob,
			thingymabobSpawns[1].position,
			thingymabobSpawns[1].rotation);
		thingymabob2.GetComponent<Rigidbody2D> ().velocity = thingymabob2.transform.up * 6;
		Destroy (thingymabob2, 2.0f);

		var thingymabob3 = (GameObject)Instantiate(
			shotThingymabob,
			thingymabobSpawns[2].position,
			thingymabobSpawns[2].rotation);
		thingymabob3.GetComponent<Rigidbody2D> ().velocity = thingymabob3.transform.up * 6;
		Destroy (thingymabob3, 2.0f);

		var thingymabob4 = (GameObject)Instantiate(
			shotThingymabob,
			thingymabobSpawns[3].position,
			thingymabobSpawns[3].rotation);
		thingymabob4.GetComponent<Rigidbody2D> ().velocity = thingymabob4.transform.up * 6;
		Destroy (thingymabob4, 2.0f);

		var thingymabob5 = (GameObject)Instantiate(
			shotThingymabob,
			thingymabobSpawns[4].position,
			thingymabobSpawns[4].rotation);
		thingymabob5.GetComponent<Rigidbody2D> ().velocity = thingymabob5.transform.up * 6;
		Destroy (thingymabob5, 2.0f);
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
