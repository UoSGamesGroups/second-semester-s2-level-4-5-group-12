using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class waterscript : MonoBehaviour {
    Rigidbody2D RB;
    Vector3 moveDir;
    CircleCollider2D Coll;
    public bool expanding;
    public float maximumRadius;
    public float expandSpeed;

	GameObject spawner1;
	GameObject spawner2;
    // Use this for initialization
    void Start () {
        RB = this.gameObject.GetComponent<Rigidbody2D>();
        RB.velocity = transform.rotation * (moveDir);
        Coll = this.GetComponent<CircleCollider2D>();
		spawner1 = GameObject.FindGameObjectWithTag ("Spawner1");
		spawner2 = GameObject.FindGameObjectWithTag ("Spawner2");
    }
	
	// Update is called once per frame
	void Update () {
        Expand();
	}

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    public void SetSpeed(float speed)
    {
        moveDir = new Vector3(speed, 0, 0);
    }
    public void SetColour(Color color)
    {
        this.GetComponent<SpriteRenderer>().color = color;
    }

    void Expand()
    {
        if (!expanding) { return; }
        if (Coll.radius < maximumRadius)
        {
            Coll.radius = Coll.radius + Time.deltaTime * expandSpeed;
        }
        
    }

	void OnCollisionEnter2D(Collision2D coll){
		if(coll.gameObject.tag == "Refill"){
			spawner1.GetComponent<spawner> ().AddWater(1);
			spawner2.GetComponent<spawner> ().AddWater(1);
			Destroy (this.gameObject);
		}

		if(coll.gameObject.tag == "Player1Refill"){
			spawner1.GetComponent<spawner> ().AddWater(2);
			Destroy (this.gameObject);
		}

		if(coll.gameObject.tag == "Player2Refill"){
			spawner2.GetComponent<spawner> ().AddWater(2);
			Destroy (this.gameObject);
		}
	}
}
