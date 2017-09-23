using UnityEngine;
using System.Collections;

public class PlayerShoot : MonoBehaviour {

    Vector3 mousePos;
    Vector3 screenPoint;
    public BoxCollider2D boxCol;
    RaycastHit2D[] hitArray;
    Vector2 vectorDir;
    public float maxRecoil = 1;


    void Start ()
    {

    }
	
	void Update () 
	{
        if (Input.GetMouseButtonDown(0) == true)
        {
            mousePos = Input.mousePosition;
            screenPoint = Camera.main.WorldToScreenPoint(transform.localPosition);
            vectorDir = new Vector2(mousePos.x - screenPoint.x + Random.Range(-maxRecoil / 2, maxRecoil / 2), mousePos.y - screenPoint.y + Random.Range(-maxRecoil / 2, maxRecoil / 2));

            hitArray = new RaycastHit2D[2];

            boxCol.Raycast(vectorDir, hitArray);

            if (hitArray[0].collider != null)
            {
                if (hitArray[0].collider.gameObject.layer == 9)
                {
                    hitArray[0].collider.gameObject.GetComponent<EnemyHealth>().dropHealth(1);
                }
            }
        }

        Debug.DrawRay(transform.position, vectorDir);
    }
}
