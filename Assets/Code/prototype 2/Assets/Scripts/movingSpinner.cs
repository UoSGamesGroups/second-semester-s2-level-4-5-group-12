using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class movingSpinner : MonoBehaviour {

	float filledAmt;
	public Slider filledSlider;
	public float maxAmt;
	public GameObject waterCircle;
	bool shoot;

	// Use this for initialization
	void Start () {
		filledSlider.value = filledAmt;
		filledSlider.maxValue = maxAmt;
		shoot = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (filledAmt == maxAmt && shoot == false){
			Release ();
		}
	}

	void OnCollisionEnter2D(Collision2D coll){

		if (coll.gameObject.tag == "Water"){
			if (coll.gameObject.GetComponent<Rigidbody2D> ().velocity.y <= 0) {
				filledAmt++;
				filledSlider.value = filledAmt;
				Destroy(coll.gameObject);
			}
		}

	}

	void Release(){
		shoot = true;
		StartCoroutine(spawnWater());
	}

	IEnumerator spawnWater()
	{
		if (filledAmt > 0 && shoot == true) {
			yield return new WaitForSeconds (0.05f);
			Vector3 spawnAngle = new Vector3 (0, 0, 90 + Random.Range (-1f, 1f)) + transform.rotation.eulerAngles;
			GameObject newWaterCircle = Instantiate (waterCircle, transform.position + new Vector3 (0, 0.5f, 0), Quaternion.Euler (spawnAngle));
			newWaterCircle.GetComponent<waterscript> ().SetSpeed (7);
			filledAmt -= 2;
			filledSlider.value = filledAmt;
			Release ();
		} else {
			shoot = false;
		}
	}
}
