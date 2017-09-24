using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerPowerup : MonoBehaviour {

    int slottedPowerup = 0;

    /* slottedPowerup:
     * none =           0
     * boomShroom =     1
     * quickShroom =    2
     * multiShroom =    3
     * gasShroom =      4
     * healthShroom =   5
     */

	public float powerTime;
	public PlayerMovement PMove;
	public PlayerShoot PShoot;

	float realSpeed;
	public float speedboostAmount;
	public float healAmount;
	void Start()
	{
		realSpeed = this.GetComponent<PlayerMovement>().speed;
	}
    public void boomShroomPowerup()
    {
        // "Explosive ammo"
		StartCoroutine(boomShot());
    }

    public void quickShroomPowerup()
    {
        // Speed boost
		StartCoroutine(speedBoost());
    }

    public void multiShroomPowerup()
    {
        // Shotgun
		StartCoroutine(multiShot());
    }

    public void gasShroomPowerup()
    {
        // "Gas ammo"
		StartCoroutine(poisonShot());
    }

    public void healthShroomPowerup()
    {
        // More health, obviously
		this.GetComponent<playerHealth>().health += healAmount;
    }
	IEnumerator speedBoost()
	{
        this.GetComponent<PlayerMovement>().speed += speedboostAmount;
		yield return new WaitForSeconds (powerTime);
        this.GetComponent<PlayerMovement>().speed = realSpeed;
	}
	IEnumerator boomShot ()
	{
        // päälle
        this.gameObject.GetComponent<PlayerShoot>().explosiveAmmo = true;
        this.gameObject.GetComponent<PlayerShoot>().damage *= 2;
        yield return new WaitForSeconds (powerTime);
        // pois päältä
        this.gameObject.GetComponent<PlayerShoot>().damage = this.gameObject.GetComponent<PlayerShoot>().defaultDamage;
        this.gameObject.GetComponent<PlayerShoot>().multiShot = false;
    }
	IEnumerator multiShot ()
	{
        this.gameObject.GetComponent<PlayerShoot>().multiShot = true;
        yield return new WaitForSeconds (powerTime);
        this.gameObject.GetComponent<PlayerShoot>().multiShot = false;
    }
	IEnumerator poisonShot ()
	{
        this.gameObject.GetComponent<PlayerShoot>().poisonAmmo = true;
        yield return new WaitForSeconds (powerTime);
        this.gameObject.GetComponent<PlayerShoot>().poisonAmmo = false;
    }
}
