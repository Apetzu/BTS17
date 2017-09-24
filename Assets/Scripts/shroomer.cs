using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class shroomer : MonoBehaviour {

	public GameObject[] shrooms;
	public Transform[] shroomColonies;
	public float shroomTime = 5f;
	float timerlength = 7; 
	public bool timerStart = false;
	float time;
	public float score;
	public Text countText;
	public GameObject scorePanel;
	void Start () 
	{
		InvokeRepeating	("Spawn", shroomTime, shroomTime);
		timerStart = true;
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		score += Time.deltaTime;
		time += Time.deltaTime;
		Debug.Log (shroomTime);
		if (time >= timerlength && timerStart == true) 
		{
			shroomTime -= 0.1f;
			time = 0f;
		}

	}
	void Spawn ()
	{
		int shroomsIndex = Random.Range (0, shrooms.Length);
		int shroomColonyIndex = Random.Range(0,shroomColonies.Length);

		Instantiate (shrooms [shroomsIndex], shroomColonies [shroomColonyIndex].position, shroomColonies [shroomColonyIndex].rotation);
	}
	public void scoreText ()
	{
		scorePanel.SetActive (true);
		countText.text = score.ToString();
	}
}
