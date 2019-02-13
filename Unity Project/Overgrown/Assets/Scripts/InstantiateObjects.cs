using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateObjects : MonoBehaviour {

    public GameObject tomatoeBarrel;
    public GameObject potatoeBarrel;

    public Transform tomatoePosition;
    public Transform potatoePosition;

    // Use this for initialization
    void Start () {

        //tomatoeBarrel = PlantsController.PlantType.Tomatoe;
        //potatoeBarrel = PlantsController.PlantType.Potatoe;

        Instantiate(tomatoeBarrel, tomatoePosition.position, Quaternion.identity);
        Instantiate(potatoeBarrel, potatoePosition.position, Quaternion.identity);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
