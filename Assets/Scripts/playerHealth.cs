using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerHealth : MonoBehaviour {
	public Image healthBar;
	public float maxHealth = 3;
	public float health = 3;
	float minhealth = 0;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		float calcHealth = health / maxHealth;
		SetHealth (calcHealth);

		if (health <= minhealth)
		{
			Debug.Log("You Died");
		}
	}
	void SetHealth(float health)
	{
		healthBar.fillAmount = health;
	}

}
