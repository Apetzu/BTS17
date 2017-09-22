using UnityEngine;
using System.Collections;

public class PlayerShoot : MonoBehaviour {

	float angle;
    Vector3 mousePos;
    Vector3 screenPoint;

    void Start ()
    {
		
	}
	
	void Update () 
	{
		mousePos = Input.mousePosition;
        screenPoint = Camera.main.WorldToScreenPoint(transform.localPosition);
        angle = Mathf.Atan2(mousePos.y - screenPoint.y, mousePos.x - screenPoint.x) * Mathf.Rad2Deg;

        if (angle < 0)
        {
            angle += 360;
        }

        Debug.Log(angle);
	}
}
