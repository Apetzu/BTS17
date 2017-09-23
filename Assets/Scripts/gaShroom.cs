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
		if (Vector2.Distance (transform.position, playerPos) <= minRange && gassenings == false || Vector2.Distance (transform.position, playerPos) == minRange && gassenings == false) 
		{
			if (gassenings == false) 
			{
				StartCoroutine (FunGas ());
				gassenings = true;
			}
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
		Gassening ();
		yield return new WaitForSeconds (0.1F);
		fleeing = true;
		gassenings = false;
		yield return new WaitForSeconds (1);
	}
	void Gassening ()
	{
		var FunGasCloudy = Instantiate (FunGasCloud,transform.position,transform.rotation);
		Destroy (FunGasCloudy, 2f);
		gassenings = false;
	}

}
