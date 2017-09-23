using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gas : MonoBehaviour {

	public float maxSize;
	public float growFactor;
	public float waitTime;
    public float gasDamage;
    public float gasTicks;
    public int gasTimes;

	void Start()
	{
		StartCoroutine(Scale());
	}

	IEnumerator Scale()
	{
		float timer = 0;

		while(maxSize > transform.localScale.x)
		{
			timer += Time.deltaTime;
			transform.localScale += new Vector3(1, 1, 1) * Time.deltaTime * growFactor;
			yield return null;
		}
	
		yield return new WaitForSeconds(waitTime);

		timer = 0;
		while(1 < transform.localScale.x)
		{
			timer += Time.deltaTime;
			transform.localScale -= new Vector3(1, 1, 1) * Time.deltaTime * growFactor;
			yield return null;
		}
	
		timer = 0;
		yield return new WaitForSeconds(waitTime);
	}

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<playerHealth>().dropHealthGas(gasDamage, gasTimes, gasTicks);
        }
    }
}
