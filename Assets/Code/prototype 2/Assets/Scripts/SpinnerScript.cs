using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinnerScript : MonoBehaviour {

    public float points;
    Vector2 TargetPos;
    Rigidbody2D RB;

	// Use this for initialization
	void Start () {
        TargetPos = transform.position;
        RB = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        CheckForAngle();
        transform.position = TargetPos;
	}

    void CheckForAngle() {
        float angledVel = RB.angularVelocity;
        if (angledVel != 0)
        {
            if (angledVel > 0)
            {
                AddPoints(angledVel / 5000);
            }
            else
            {
                AddPoints(-angledVel / 5000);
            }
        }
    }

    public void AddPoints(float amt)
    {
        points += amt;
    }

}
