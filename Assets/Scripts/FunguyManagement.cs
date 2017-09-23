using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FunguyManagement : MonoBehaviour {

	public bool boomShroom = false;
	public bool quickShroom = false;
	public bool healthShroom = false;
	public bool multishotShroom = false;
    public bool gasShroom = false;

	public GameObject shroomster;
	public Transform mushshroom;
	bool tobePicked = false;
    public float shoomsterTimer;
    public KeyCode slotButton;
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
			if(Input.GetKeyDown(slotButton) && tobePicked == true)
			{
                // 1
                GameObject.FindGameObjectWithTag("Player").gameObject.GetComponent<playerPowerup>().boomShroomPowerup();
				Destroy(gameObject);
			}
		}
		else if (quickShroom == true) 
		{
			//the effect applied by the shroom or the shroom itself added to player
			if(Input.GetKeyDown(slotButton) && tobePicked == true)
			{
                // 2
                GameObject.FindGameObjectWithTag("Player").gameObject.GetComponent<playerPowerup>().quickShroomPowerup();
                Destroy(gameObject);
			}
		}
		else if (multishotShroom == true) 
		{
			//the effect applied by the shroom or the shroom itself added to player
			if(Input.GetKeyDown(slotButton) && tobePicked == true)
			{
                // 3
                GameObject.FindGameObjectWithTag("Player").gameObject.GetComponent<playerPowerup>().multiShroomPowerup();
                Destroy(gameObject);
			}
		}
        else if (gasShroom == true)
        {
            //the effect applied by the shroom or the shroom itself added to player
            if (Input.GetKeyDown(slotButton) && tobePicked == true)
            {
                // 4
                GameObject.FindGameObjectWithTag("Player").gameObject.GetComponent<playerPowerup>().gasShroomPowerup();
                Destroy(gameObject);
            }
        }
        else if (healthShroom == true)
        {
            //the effect applied by the shroom or the shroom itself added to player
            if (Input.GetKeyDown(slotButton) && tobePicked == true)
            {
                // 5
                GameObject.FindGameObjectWithTag("Player").gameObject.GetComponent<playerPowerup>().healthShroomPowerup();
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
		yield return new WaitForSeconds (shoomsterTimer);
		var shroomsterThing = (GameObject)Instantiate(
			shroomster,
			mushshroom.position,
			mushshroom.rotation);
		Destroy(gameObject);
	}
}
