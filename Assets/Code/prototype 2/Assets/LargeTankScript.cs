using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class LargeTankScript : MonoBehaviour {

    float filledAmt = 0;
    public float maxFilledAmt;
    public Slider filledSlider;
    bool filled;
    public GameObject spinnerWithPoints;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (filledAmt == maxFilledAmt && filled == false) {
            filled = true;
            spinnerWithPoints.GetComponent<SpinnerScript>().AddPoints(100);
        }
	}

    void OnCollisionEnter2D(Collision2D coll)
    {

        if (coll.gameObject.tag == "Water" && filledAmt < maxFilledAmt)
        {
            filledAmt++;
            filledSlider.value = filledAmt;
            Destroy(coll.gameObject);
        }

    }
}
