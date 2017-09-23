using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerHealth : MonoBehaviour {
	public Image healthBar;
	public float maxHealth = 3f;
	float health;
    public bool playerDead = false;
    bool gasHealthDrop;
    float gasDamage;
    int gasDamageTimes;
    float gasDamageFrequency;
    float timer = 0f;
    public float damage;

    void Start()
    {
        health = maxHealth;
    }

    void Update()
    {
        if (gasHealthDrop == true)
        {
            if (gasDamageTimes != 0)
            {
                timer += Time.deltaTime;
                if (timer >= gasDamageFrequency)
                {
                    timer = 0f;
                    dropHealth(gasDamage);
                    gasDamageTimes--;
                }
            }
            else
            {
                gasHealthDrop = false;
            }
        }
    }

    public void dropHealth (float amount = 1.0f)
    {
        health -= amount;
        healthBar.fillAmount = health / maxHealth;
        if (health <= 0f)
        {
            playerDead = true;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 8)
        {
            dropHealth(damage);
            Destroy(collision.gameObject);
        }
    }

    public void dropHealthGas(float amount, int times, float frequency)
    {
        gasHealthDrop = true;
        gasDamage = amount;
        gasDamageTimes = times;
        gasDamageFrequency = frequency;
    }

}
