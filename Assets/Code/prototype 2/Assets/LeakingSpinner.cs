using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeakingSpinner : MonoBehaviour {

	float filledAmt =10;
	public GameObject drip;
	public GameObject dripSpawn;

	// Use this for initialization
	void Start () {
		InvokeRepeating("Leak", 0f, 1f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void Leak(){
		if (filledAmt > 0) {
			Instantiate (drip, dripSpawn.transform.position, Quaternion.identity);
		}
	}
}
