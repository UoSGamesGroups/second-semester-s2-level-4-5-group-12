using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BucketScript : MonoBehaviour {

    float filledAmt = 0;
    public float maxFilledAmt;
    public GameObject waterPrefab;
    public Slider filledSlider;
    public Transform waterSpawn1;
    public Transform waterSpawn2;
    public Transform waterSpawn3;
    Animator Anim;
    bool dumping;

    // Use this for initialization
    void Start () {
        filledSlider.maxValue = maxFilledAmt;
        Anim = this.GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
		if (filledAmt == maxFilledAmt && dumping ==false)
        {
            Dump();
        }
	}

    void Dump()
    {
        Anim.SetTrigger("Dump");
        dumping = true;
        StartCoroutine(DumpWater(0.2f));
        
    }


    private IEnumerator DumpWater(float timeToWait)
    {

        
        

        if (filledAmt > 0)
        {
            yield return new WaitForSeconds(timeToWait);
            Vector3 spawnAngle = new Vector3(0, 0, Random.Range(-1f, 1f)) + transform.rotation.eulerAngles;
            GameObject newWaterCircle1 = Instantiate(waterPrefab, waterSpawn1.transform.position, Quaternion.Euler(spawnAngle));
            newWaterCircle1.GetComponent<waterscript>().SetSpeed(1);

            spawnAngle = new Vector3(0, 0, Random.Range(-1f, 1f)) + transform.rotation.eulerAngles;
            GameObject newWaterCircle2 = Instantiate(waterPrefab, waterSpawn1.transform.position, Quaternion.Euler(spawnAngle));
            newWaterCircle2.GetComponent<waterscript>().SetSpeed(1);

            spawnAngle = new Vector3(0, 0, Random.Range(-1f, 1f)) + transform.rotation.eulerAngles;
            GameObject newWaterCircle3 = Instantiate(waterPrefab, waterSpawn1.transform.position, Quaternion.Euler(spawnAngle));
            newWaterCircle3.GetComponent<waterscript>().SetSpeed(1);
            Debug.Log("dumping");
            filledAmt-= 3;
            filledSlider.value = filledAmt;
            StartCoroutine(DumpWater(0.1f));
        }
        else
        {
            dumping = false;
        }

    }

    void OnCollisionEnter2D(Collision2D coll)
    {

        if (coll.gameObject.tag == "Water" && filledAmt < maxFilledAmt && dumping == false)
        {
            filledAmt++;
            filledSlider.value = filledAmt;
            Destroy(coll.gameObject);
        }

    }
}
