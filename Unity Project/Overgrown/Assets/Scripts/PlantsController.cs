using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantsController : MonoBehaviour {

    public string PlantType;
    private float numbersOfSeedsCarry;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    /// <summary>
    /// Controls the spawns for the seeds
    /// </summary>
    private void seedSpawner()
    {
        throw new System.NotImplementedException();
    }

    /// <summary>
    /// Controls the growing speed of the plants
    /// </summary>
    private void plantsGrowth()
    {
        throw new System.NotImplementedException();
    }

    internal void TypeOfPlant()
    {
       
            if (PlantType == "Tomato")
            {
                numbersOfSeedsCarry++;
                print("You picked up a tomato");
                puttingSeedsDown();
            }

            if (PlantType == "Potato")
            {
                numbersOfSeedsCarry++;
                print("You picked up a potato");
            }
    }

    private void puttingSeedsDown()
    {
      
    }
}
