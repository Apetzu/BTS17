using UnityEngine;
using System.Collections;

public class PlayerShoot : MonoBehaviour {

    Vector3 mousePos;
    Vector3 screenPoint;
    public BoxCollider2D boxCol;
    RaycastHit2D[] hitArray;
    RaycastHit2D[] hitArray2;
    RaycastHit2D[] hitArray3;
    Vector2 vectorDir;
    Vector2 vectorDir2;
    Vector2 vectorDir3;
    public float maxRecoil = 1;
    public bool multiShot = false;
    public bool explosiveAmmo = false;
    public bool poisonAmmo = false;
    public float defaultDamage = 1f;
    public float damage;
    public GameObject explosionEffect;


    void Start ()
    {
        damage = defaultDamage;
    }
	
	void Update () 
	{
        mousePos = Input.mousePosition;
        screenPoint = Camera.main.WorldToScreenPoint(transform.localPosition);
        vectorDir = new Vector2(mousePos.x - screenPoint.x, mousePos.y - screenPoint.y);
        if (multiShot == true)
        {
            vectorDir2 = new Vector2(mousePos.x - screenPoint.x + Random.Range(-maxRecoil / 2, maxRecoil / 2), mousePos.y - screenPoint.y + Random.Range(-maxRecoil / 2, maxRecoil / 2));
            vectorDir3 = new Vector2(mousePos.x - screenPoint.x + Random.Range(-maxRecoil / 2, maxRecoil / 2), mousePos.y - screenPoint.y + Random.Range(-maxRecoil / 2, maxRecoil / 2));
        }
        float angle = Mathf.Atan2(vectorDir.y, vectorDir.x) * Mathf.Rad2Deg;

        if (angle < 0)
        {
            angle += 360;
        }

        if (angle >= -(360/8/2) && angle <= 360/8/2)
        {
            // 1 flip 2
			GetComponent<SpriteRenderer>().flipX = true;
			GetComponent<Animator> ().SetInteger ("direction",2);
        }
        else if (angle > 360 / 8 / 2 && angle < (360 / 8 / 2) + 360 / 8)
        {
            // 2 flip 3
			GetComponent<SpriteRenderer>().flipX = true;
			GetComponent<Animator> ().SetInteger ("direction",3);
        }
        else if (angle > (360 / 8 / 2) + 360 / 8 && angle < (360 / 8 / 2) + 360 / 8 * 2)
        {
            // 3
			GetComponent<SpriteRenderer>().flipX = false;
			GetComponent<Animator> ().SetInteger ("direction",1);
        }
        else if (angle > (360 / 8 / 2) + 360 / 8 * 2 && angle < (360 / 8 / 2) + 360 / 8 * 3)
        {
            // 4
			GetComponent<SpriteRenderer>().flipX = false;
			GetComponent<Animator> ().SetInteger ("direction",3);
        }
        else if (angle > (360 / 8 / 2) + 360 / 8 * 3 && angle < (360 / 8 / 2) + 360 / 8 * 4)
        {
            // 5
			GetComponent<SpriteRenderer>().flipX = false;
			GetComponent<Animator> ().SetInteger ("direction",2);
        }
        else if (angle > (360 / 8 / 2) + 360 / 8 * 4 && angle < (360 / 8 / 2) + 360 / 8 * 5)
        {
            // 6
			GetComponent<SpriteRenderer>().flipX = false;
			GetComponent<Animator> ().SetInteger ("direction",4);
        }
        else if (angle > (360 / 8 / 2) + 360 / 8 * 5 && angle < (360 / 8 / 2) + 360 / 8 * 6)
        {
            // 7
			GetComponent<SpriteRenderer>().flipX = false;
			GetComponent<Animator> ().SetInteger ("direction",0);
        }
        else if (angle > (360 / 8 / 2) + 360 / 8 * 6 && angle < (360 / 8 / 2) + 360 / 8 * 7)
        {
            // 8 flip
			GetComponent<SpriteRenderer>().flipX = true;
			GetComponent<Animator> ().SetInteger ("direction",4);
        }

        if (Input.GetMouseButtonDown(0) == true)
        {
            

            hitArray = new RaycastHit2D[2];

            boxCol.Raycast(vectorDir, hitArray);

            if (hitArray[0].collider != null)
            {
                if (hitArray[0].collider.gameObject.layer == 9)
                {
                    hitArray[0].collider.gameObject.GetComponent<EnemyHealth>().dropHealth(damage);
                    if (explosiveAmmo == true)
                    {
                        var explosion = (GameObject)Instantiate(explosionEffect, hitArray[0].collider.gameObject.transform.position, hitArray[0].collider.gameObject.transform.rotation);
                        Destroy(explosion, 2f);
                    }
                }
            }

            if (multiShot == true)
            {
                hitArray2 = new RaycastHit2D[2];
                hitArray3 = new RaycastHit2D[2];
                boxCol.Raycast(vectorDir2, hitArray2);
                boxCol.Raycast(vectorDir3, hitArray3);

                if (hitArray2[0].collider != null)
                {
                    if (hitArray2[0].collider.gameObject.layer == 9)
                    {
                        hitArray2[0].collider.gameObject.GetComponent<EnemyHealth>().dropHealth(damage);
                        if (explosiveAmmo == true)
                        {
                            var explosion = (GameObject)Instantiate(explosionEffect, hitArray2[0].collider.gameObject.transform.position, hitArray2[0].collider.gameObject.transform.rotation);
                            Destroy(explosion, 2f);
                        }
                    }
                }

                if (hitArray3[0].collider != null)
                {
                    if (hitArray3[0].collider.gameObject.layer == 9)
                    {
                        hitArray3[0].collider.gameObject.GetComponent<EnemyHealth>().dropHealth(damage);
                        if (explosiveAmmo == true)
                        {
                            var explosion = (GameObject)Instantiate(explosionEffect, hitArray3[0].collider.gameObject.transform.position, hitArray3[0].collider.gameObject.transform.rotation);
                            Destroy(explosion, 2f);
                        }
                    }
                }
            }

            Debug.DrawRay(transform.position, vectorDir);
            if (multiShot == true)
            {
                Debug.DrawRay(transform.position, vectorDir2);
                Debug.DrawRay(transform.position, vectorDir3);
            }
        }
    }
}
