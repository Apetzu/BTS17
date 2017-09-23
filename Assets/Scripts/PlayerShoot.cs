using UnityEngine;
using System.Collections;

public class PlayerShoot : MonoBehaviour {

	float angle;
    Vector3 mousePos;
    Vector3 screenPoint;
    public BoxCollider2D boxCol;
    RaycastHit2D[] hitArray;

    void Start ()
    {

    }
	
	void Update () 
	{
		mousePos = Input.mousePosition;
        screenPoint = Camera.main.WorldToScreenPoint(transform.localPosition);
        angle = Mathf.Atan2(mousePos.y - screenPoint.y, mousePos.x - screenPoint.x) * Mathf.Rad2Deg;

        /*if (angle < 0)
        {
            angle += 360;
        }*/

        boxCol.Raycast(new Vector2(mousePos.y - screenPoint.y, mousePos.x - screenPoint.x), hitArray);

        for (int i = 0; i < hitArray.Length; i++)
        {
            Debug.Log(hitArray[i]);
        }

        //Debug.Log(angle);
	}
}
