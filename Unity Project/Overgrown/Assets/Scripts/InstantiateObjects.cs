using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateObjects : MonoBehaviour {

    public GameObject barrel;
    public GameObject trashBarrel;
    public GameObject pluckerBarrel;
    public GameObject table;

    // Use this for initialization
    void Start () {

        //tomatoeBarrel = PlantsController.PlantType.Tomatoe;
        //potatoeBarrel = PlantsController.PlantType.Potatoe;

      //potatoe barrel
        GameObject newSeedBarrel =  Instantiate(barrel, new Vector3(-24.27f, -0.28f, -6.51f), Quaternion.identity);
        BarellController newSeeds = newSeedBarrel.GetComponent<BarellController>();
        newSeeds.YouAreA(BarellController.PlantType.Carrot);

        //tomatoe barrell
        GameObject newSeedBarrel2 = Instantiate(barrel, new Vector3(-23.81f, -0.28f, 0.82f), Quaternion.identity);
        BarellController newSeeds2 = newSeedBarrel2.GetComponent<BarellController>();
        newSeeds2.YouAreA(BarellController.PlantType.Tomatoe);

        //trash can 
        GameObject newtrashBarrel = Instantiate(trashBarrel, new Vector3(1.02f, -0.3f, 5.92f), Quaternion.identity);

        //plucker
        GameObject newPluckerBarrel = Instantiate(pluckerBarrel, new Vector3(-16.7f, -0.277f, 6.1f), Quaternion.identity);

        //table
        GameObject newTable = Instantiate(table, new Vector3(-0.73f, 1.27f, -20.58f), Quaternion.identity);
        PlantsControl newtables = newTable.GetComponent<PlantsControl>();
        newtables.YouAreA(PlantsControl.PlantType.CarrotItem);

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
