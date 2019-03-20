using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantsController : MonoBehaviour
{
    public enum PlantType  {Carrot, Tomatoe };
    public PlantType thisPlant;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    /// <summary>
    /// Controls the spawns for the seeds
    /// </summary>
    private void seedSpawner()
    {
        throw new System.NotImplementedException();
    }

    internal void YouAreA(PlantType plantType)
    {
        thisPlant = plantType;
    }

    /// <summary>
    /// Controls the growing speed of the plants
    /// </summary>
    private void plantsGrowth()
    {
        throw new System.NotImplementedException();
    }

    internal void puttingSeedsDown()
    {
        //if (PlantType == "Dirt")
        //{
        //    if (ItemCurrentlyCarried == "Tomato")
        //    {
        //        print("You just planted a tomato seed");
        //        carryingAnItem = false;
        //    }
        //    if (ItemCurrentlyCarried == "Potato")
        //    {
        //        print("You just planted a potato seed");
        //        carryingAnItem = false;
        //    }
        //}

    }

    internal PlantType pickUp()
    {
        return thisPlant;
    }
}
