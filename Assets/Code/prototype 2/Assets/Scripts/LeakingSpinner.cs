using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LeakingSpinner : MonoBehaviour {

	float filledAmt = 0;
	public GameObject drip;
	public GameObject dripSpawn;
	public Slider filledSlider;

	// Use this for initialization
	void Start () {
		InvokeRepeating("Leak", 0f, 1f);
		filledSlider.value = filledAmt;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void Leak(){
		if (filledAmt > 0 ) {
			filledAmt--;
			filledSlider.value = filledAmt;
			Instantiate (drip, dripSpawn.transform.position, Quaternion.identity);
		}
	}

	void OnCollisionEnter2D(Collision2D coll){

		if (coll.gameObject.tag == "Water" && filledAmt < 10){
			filledAmt++;
			filledSlider.value = filledAmt;
		    Destroy(coll.gameObject);
		}

	}

}
