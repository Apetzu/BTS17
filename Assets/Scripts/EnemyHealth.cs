using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    float health;
    public float maxHealth = 3.0f;
    public bool healthShroom;

	void Start()
    {
        health = maxHealth;
    }

    public void dropHealth(int amount = 1)
    {
        health -= amount;
        if (health <= 0)
        {
            
            if (healthShroom == false)
            {
                Destroy(this.gameObject);
            }
        }
    }
}
