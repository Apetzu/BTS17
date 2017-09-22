using UnityEngine;
using System.Collections.Generic;

public class PlayerMovement : MonoBehaviour {

    public float speed = 10;
    float mX;
    float mY;
    Vector3 nVector;

    void Start ()
    {

	}

	void FixedUpdate ()
    {
		mX = Input.GetAxis("Horizontal");
		mY = Input.GetAxis("Vertical");

        nVector = Vector3.Normalize(new Vector3(mX, mY, 0.0f));



		transform.Translate(nVector * speed * Time.deltaTime);

	}
}
