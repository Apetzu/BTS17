using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shroomer : MonoBehaviour {

	public GameObject[] shrooms;
	public Transform[] shroomColonies;
	public float shroomTime = 1f;

	void Start () 
	{
		InvokeRepeating	("Spawn", shroomTime, shroomTime);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void Spawn ()
	{
		int shroomsIndex = Random.Range (0, shrooms.Length);
		int shroomColonyIndex = Random.Range(0,shroomColonies.Length);

		Instantiate (shrooms [shroomsIndex], shroomColonies [shroomColonyIndex].position, shroomColonies [shroomColonyIndex].rotation);
	}
}
