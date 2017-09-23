using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerHealth : MonoBehaviour {
	public Image healthBar;
	public float maxHealth = 3;
	float health;
    public bool playerDead = false;

    void Start()
    {
        health = maxHealth;
    }

    public void dropHealth (int amount = 1)
    {
        health -= amount;
        healthBar.fillAmount = health / maxHealth;
        if (health <= 0)
        {
            playerDead = true;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 8)
        {
            dropHealth(1);
            Destroy(collision.gameObject);
        }
    }

}
