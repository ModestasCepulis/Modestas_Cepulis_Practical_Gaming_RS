using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateObjects : MonoBehaviour {

    public GameObject barrel;
    public GameObject trashBarrel;


    public Transform tomatoePosition;
    public Transform potatoePosition;
    public Transform trashPosition;

    // Use this for initialization
    void Start () {

        //tomatoeBarrel = PlantsController.PlantType.Tomatoe;
        //potatoeBarrel = PlantsController.PlantType.Potatoe;

       GameObject newSeedBarrel =  Instantiate(barrel, potatoePosition.position, Quaternion.identity);
        PlantsController newSeeds = newSeedBarrel.GetComponent<PlantsController>();
        newSeeds.YouAreA(PlantsController.PlantType.Potatoe);

        GameObject newSeedBarrel2 = Instantiate(barrel, tomatoePosition.position, Quaternion.identity);
        PlantsController newSeeds2 = newSeedBarrel2.GetComponent<PlantsController>();
        newSeeds2.YouAreA(PlantsController.PlantType.Tomatoe);

        GameObject newtrashBarrel = Instantiate(trashBarrel, trashPosition.position, Quaternion.identity);

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
