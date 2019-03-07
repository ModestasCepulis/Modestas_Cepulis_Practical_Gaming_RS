using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateObjects : MonoBehaviour {

    public GameObject barrel;
    public GameObject trashBarrel;
    public GameObject pluckerBarrel;

    // Use this for initialization
    void Start () {

        //tomatoeBarrel = PlantsController.PlantType.Tomatoe;
        //potatoeBarrel = PlantsController.PlantType.Potatoe;

      //potatoe barrel
        GameObject newSeedBarrel =  Instantiate(barrel, new Vector3(-24.27f, -0.28f, -6.51f), Quaternion.identity);
        PlantsController newSeeds = newSeedBarrel.GetComponent<PlantsController>();
        newSeeds.YouAreA(PlantsController.PlantType.Potatoe);

        //tomatoe barrell
        GameObject newSeedBarrel2 = Instantiate(barrel, new Vector3(-23.81f, -0.28f, 0.82f), Quaternion.identity);
        PlantsController newSeeds2 = newSeedBarrel2.GetComponent<PlantsController>();
        newSeeds2.YouAreA(PlantsController.PlantType.Tomatoe);

        //trash can 
        GameObject newtrashBarrel = Instantiate(trashBarrel, new Vector3(1.02f, -0.3f, 5.92f), Quaternion.identity);

        //plucker
        GameObject newPluckerBarrel = Instantiate(pluckerBarrel, new Vector3(-16.7f, -0.277f, 6.1f), Quaternion.identity);

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
