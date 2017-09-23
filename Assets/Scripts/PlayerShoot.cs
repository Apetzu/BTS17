using UnityEngine;
using System.Collections;

public class PlayerShoot : MonoBehaviour {

    Vector3 mousePos;
    Vector3 screenPoint;
    public BoxCollider2D boxCol;
    RaycastHit2D[] hitArray;
    Vector2 vectorDir;

    void Start ()
    {

    }
	
	void Update () 
	{
		mousePos = Input.mousePosition;
        screenPoint = Camera.main.WorldToScreenPoint(transform.localPosition);
        vectorDir = new Vector2(mousePos.x - screenPoint.x, mousePos.y - screenPoint.y);

        hitArray = new RaycastHit2D[2];

        boxCol.Raycast(vectorDir, hitArray);

        if (hitArray[0] != null)
            {
            for (int i = 0; i < hitArray.Length; i++)
            {
                Debug.Log(i + " " + hitArray[i].collider);
            }
        }

        Debug.DrawRay(transform.position, vectorDir);
    }
}
