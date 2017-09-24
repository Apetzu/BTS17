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
		realSpeed = PMove.speed;
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
		PMove.speed += speedboostAmount;
		yield return new WaitForSeconds (powerTime);
		PMove.speed = realSpeed;
	}
	IEnumerator boomShot ()
	{
		
		yield return new WaitForSeconds (powerTime);

	}
	IEnumerator multiShot ()
	{
		
		yield return new WaitForSeconds (powerTime);

	}
	IEnumerator poisonShot ()
	{
		
		yield return new WaitForSeconds (powerTime);

	}
}
