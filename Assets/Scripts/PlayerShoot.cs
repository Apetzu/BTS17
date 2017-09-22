using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour {

	Vector3 mouse_pos;
	Transform target; //Assign to the object you want to rotate
	Vector3 object_pos;
	float angle;

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		var mouse = Input.mousePosition;
		var screenPoint = Camera.main.WorldToScreenPoint(transform.localPosition);
		var offset = new Vector2(mouse.x - screenPoint.x, mouse.y - screenPoint.y);
		var angle = Mathf.Atan2(offset.y, offset.x) * Mathf.Rad2Deg;
	}
}
