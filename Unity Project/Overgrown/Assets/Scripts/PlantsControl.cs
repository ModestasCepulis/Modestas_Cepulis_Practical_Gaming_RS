using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantsControl : MonoBehaviour {

    public enum PlantType { CarrotItem, TomatoeItem};
    public PlantType thisPlant;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    internal void YouAreA(PlantType plantType)
    {
        thisPlant = plantType;
    }
}
