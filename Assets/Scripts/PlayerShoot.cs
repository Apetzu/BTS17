using UnityEngine;
using System.Collections;

public class PlayerShoot : MonoBehaviour {

    Vector3 mousePos;
    Vector3 screenPoint;
    public BoxCollider2D boxCol;
    RaycastHit2D[] hitArray;
    Vector2 vectorDir;
    public float maxRecoil = 1;
    public bool multiShot = false;
    public bool explosiveAmmo = false;


    void Start ()
    {

    }
	
	void Update () 
	{
        mousePos = Input.mousePosition;
        screenPoint = Camera.main.WorldToScreenPoint(transform.localPosition);
        vectorDir = new Vector2(mousePos.x - screenPoint.x, mousePos.y - screenPoint.y);
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
            Debug.Log("vittu 1");
        }
        else if (angle > 360 / 8 / 2 && angle < (360 / 8 / 2) + 360 / 8)
        {
            // 2 flip 3
			GetComponent<SpriteRenderer>().flipX = true;
			GetComponent<Animator> ().SetInteger ("direction",3);
            Debug.Log("vittu 2");
        }
        else if (angle > (360 / 8 / 2) + 360 / 8 && angle < (360 / 8 / 2) + 360 / 8 * 2)
        {
            // 3
			GetComponent<SpriteRenderer>().flipX = false;
			GetComponent<Animator> ().SetInteger ("direction",1);
            Debug.Log("vittu 3");
        }
        else if (angle > (360 / 8 / 2) + 360 / 8 * 2 && angle < (360 / 8 / 2) + 360 / 8 * 3)
        {
            // 4
			GetComponent<SpriteRenderer>().flipX = false;
			GetComponent<Animator> ().SetInteger ("direction",3);
            Debug.Log("vittu 4");
        }
        else if (angle > (360 / 8 / 2) + 360 / 8 * 3 && angle < (360 / 8 / 2) + 360 / 8 * 4)
        {
            // 5
			GetComponent<SpriteRenderer>().flipX = false;
			GetComponent<Animator> ().SetInteger ("direction",2);
            Debug.Log("vittu 5");
        }
        else if (angle > (360 / 8 / 2) + 360 / 8 * 4 && angle < (360 / 8 / 2) + 360 / 8 * 5)
        {
            // 6
			GetComponent<SpriteRenderer>().flipX = false;
			GetComponent<Animator> ().SetInteger ("direction",4);
            Debug.Log("vittu 6");
        }
        else if (angle > (360 / 8 / 2) + 360 / 8 * 5 && angle < (360 / 8 / 2) + 360 / 8 * 6)
        {
            // 7
			GetComponent<SpriteRenderer>().flipX = false;
			GetComponent<Animator> ().SetInteger ("direction",0);
            Debug.Log("vittu 7");
        }
        else if (angle > (360 / 8 / 2) + 360 / 8 * 6 && angle < (360 / 8 / 2) + 360 / 8 * 7)
        {
            // 8 flip
			GetComponent<SpriteRenderer>().flipX = true;
			GetComponent<Animator> ().SetInteger ("direction",4);
            Debug.Log("vittu 8");
        }

        if (Input.GetMouseButtonDown(0) == true)
        {
            hitArray = new RaycastHit2D[2];

            boxCol.Raycast(vectorDir, hitArray);
            if (multiShot == true)
            {
                Vector2 vectorDir2 = new Vector2(mousePos.x - screenPoint.x + Random.Range(-maxRecoil / 2, maxRecoil / 2), mousePos.y - screenPoint.y + Random.Range(-maxRecoil / 2, maxRecoil / 2));
                Vector2 vectorDir3 = new Vector2(mousePos.x - screenPoint.x + Random.Range(-maxRecoil / 2, maxRecoil / 2), mousePos.y - screenPoint.y + Random.Range(-maxRecoil / 2, maxRecoil / 2));
            }

            if (hitArray[0].collider != null)
            {
                if (hitArray[0].collider.gameObject.layer == 9)
                {
                    hitArray[0].collider.gameObject.GetComponent<EnemyHealth>().dropHealth(1);
                }
            }

            Debug.DrawRay(transform.position, vectorDir);
        }
    }
}
