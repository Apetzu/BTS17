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

    public void dropHealth(float amount = 1)
    {
        health -= amount;
        if (health <= 0)
        {
            Debug.Log(this.gameObject.name + "is död");
            if (healthShroom == false)
            {
                Destroy(this.gameObject);
            }
        }
    }


}
