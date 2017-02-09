using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour {

    [Header("Turret Variables")]
    public float rotateSpeed;

    [Header ("Water Variables")]
    public GameObject waterCircle;
    public float waterPower;
    public Color waterColour;

    [Header("Key Binds")]
    public KeyCode upKey;
    public KeyCode downKey;
    public KeyCode shootKey;

    // Use this for initialization
    void Start () {
        
    }

    private void Update()
    {
        Move();
        Shoot();
    }

    void Move()
    {
        if (Input.GetKey(upKey))
        {
            this.transform.Rotate(new Vector3(0,0, rotateSpeed));
        }
        if (Input.GetKey(downKey))
        {
            this.transform.Rotate(new Vector3(0, 0, -rotateSpeed));
        }
    }

    void Shoot()
    {
        if (Input.GetKey(shootKey))
        {
            StartCoroutine(spawnWater());
        }
    }

    IEnumerator spawnWater()
    {
        yield return new WaitForSeconds(0.001f);
        Vector3 spawnAngle = new Vector3(0, 0, Random.Range(0, 2) - 1f) + transform.rotation.eulerAngles;
        GameObject newWaterCircle = Instantiate(waterCircle, transform.position, Quaternion.Euler(spawnAngle));
        newWaterCircle.GetComponent<waterscript>().SetSpeed(waterPower);
        newWaterCircle.GetComponent<waterscript>().SetColour(waterColour);

    }
}
