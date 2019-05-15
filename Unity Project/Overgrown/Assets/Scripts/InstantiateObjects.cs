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
        GameObject carrotBarrelSpot = GameObject.FindGameObjectWithTag("CarrotBarrell");


        GameObject newSeedBarrel =  Instantiate(barrel, carrotBarrelSpot.transform.position, Quaternion.identity);
        BarellController newSeeds = newSeedBarrel.GetComponent<BarellController>();
        newSeeds.YouAreA(BarellController.PlantType.Carrot);

        //tomatoe barrell
        GameObject tomatoeBarrelSpot = GameObject.FindGameObjectWithTag("TomatoeBarrell");

        GameObject newSeedBarrel2 = Instantiate(barrel, tomatoeBarrelSpot.transform.position, Quaternion.identity);
        BarellController newSeeds2 = newSeedBarrel2.GetComponent<BarellController>();
        newSeeds2.YouAreA(BarellController.PlantType.Tomatoe);

        //trash can 
        GameObject newtrashBarrel = Instantiate(trashBarrel, new Vector3(1.02f, -0.3f, 5.92f), Quaternion.identity);

        //plucker
        GameObject shovelBarrelSpot = GameObject.FindGameObjectWithTag("ShovelBarrell");
        GameObject newPluckerBarrel = Instantiate(pluckerBarrel, shovelBarrelSpot.transform.position, Quaternion.identity);

        //table

        GameObject table1 = GameObject.FindGameObjectWithTag("Table1");
        GameObject table2 = GameObject.FindGameObjectWithTag("Table2");
        GameObject table3 = GameObject.FindGameObjectWithTag("Table3");
        GameObject table4 = GameObject.FindGameObjectWithTag("Table4");

        GameObject newTable = Instantiate(table, table1.transform.position, Quaternion.identity);
        GameObject newTable2 = Instantiate(table, table2.transform.position, Quaternion.identity);
        GameObject newTable3 = Instantiate(table, table3.transform.position, Quaternion.identity);
        GameObject newTable4 = Instantiate(table, table4.transform.position, Quaternion.identity);


    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
