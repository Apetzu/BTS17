using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FunguyManagement : MonoBehaviour {

	public bool boomShroom = false;
	public bool quickShroom = false;
	public bool healthShroom = false;
	public bool multishotShroom = false;

	public GameObject shroomster;
	public Transform mushshroom;
	bool tobePicked = false;
	// Use this for initialization
	void Start () 
	{
		StartCoroutine (Shroomsterisation ());
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (boomShroom == true) 
		{
			//the effect applied by the shroom or the shroom itself added to player
			if(Input.GetKeyDown(KeyCode.Alpha1) && tobePicked == true)
			{
				//Place the shroom in slot 1	
				Destroy(gameObject);
			}
		}
		if (quickShroom == true) 
		{
			//the effect applied by the shroom or the shroom itself added to player
			if(Input.GetKeyDown(KeyCode.Alpha1) && tobePicked == true)
			{
				//Place the shroom in slot 1	
				Destroy(gameObject);
			}
		}
		if (healthShroom == true) 
		{
			//the effect applied by the shroom or the shroom itself added to player
			if(Input.GetKeyDown(KeyCode.Alpha1) && tobePicked == true)
			{
				//Place the shroom in slot 1	
				Destroy(gameObject);
			}
		}
		if (multishotShroom == true) 
		{
			//the effect applied by the shroom or the shroom itself added to player
			if(Input.GetKeyDown(KeyCode.Alpha1) && tobePicked == true)
			{
				//Place the shroom in slot 1	
				Destroy(gameObject);
			}
		}
	}
	void OnTriggerStay2D (Collider2D other)
	{
		if (other.tag == "Player") 
		{
			tobePicked = true;
		} 
		else 
		{
			tobePicked = false;
		}
	}
	IEnumerator Shroomsterisation ()
	{
		yield return new WaitForSeconds (7);
		var shroomsterThing = (GameObject)Instantiate(
			shroomster,
			mushshroom.position,
			mushshroom.rotation);
		Destroy(gameObject);
	}
}
