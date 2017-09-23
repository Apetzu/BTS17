using UnityEngine;
using System.Collections.Generic;

public class PlayerMovement : MonoBehaviour {

    public float speed = 10;
    float mX;
    float mY;
    Vector3 dVector;
    public float smoothSpeed = 1;
    Vector2 currentVelocity;

    void Start ()
    {

	}

	void FixedUpdate ()
    {
        if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
        {
            mX = Input.GetAxis("Horizontal");
		    mY = Input.GetAxis("Vertical");

            dVector = Vector3.Normalize(new Vector3(mX, mY, 0.0f)) * speed;
		    
        }
        else
        {
            dVector = Vector3.zero;
        }

        transform.position = Vector2.SmoothDamp(transform.position, transform.position + dVector, ref currentVelocity, smoothSpeed, Mathf.Infinity, Time.deltaTime);
    }

    float smootherstep(float edge0, float edge1, float x)
    {
        // Scale, and clamp x to 0..1 range
        x = Mathf.Clamp((x - edge0) / (edge1 - edge0), 0.0f, 1.0f);
        // Evaluate polynomial
        return x * x * (3 - 2 * x);
    }
}
