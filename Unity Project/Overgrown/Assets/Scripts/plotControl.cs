using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class plotControl : MonoBehaviour {


    internal enum PlotState {Soil, Rubbish, Potatoe_Seedling, Tomatoe_Seedling, Potatoe_Plant, Tomatoe_Plant, Unwatered_Potatoe_Plant, Unwatered_Tomatoe_Plant}

    internal PlotState plotIs = PlotState.Rubbish;

    float growthTimer = 10.0f;


	// Use this for initialization
	void Start () {
}
	
	// Update is called once per frame
	void Update () {

        print(plotIs);

        if(plotIs == PlotState.Tomatoe_Seedling)
        {
            growthTimer = growthTimer - Time.deltaTime;
        }

        if(growthTimer == 0)
        {
            print("Tomato seedling has grown");
            plotIs = PlotState.Tomatoe_Plant;
            growthTimer = 10.0f;
        }
		
	}

    internal void Interact(PlayerController.InHand currently_Holding)
    {
        switch (currently_Holding)
        {
            case PlayerController.InHand.Empty:
                // Check harvest etc..
                break;

            case PlayerController.InHand.Potatoe_Seeds:

                if (plotIs == PlotState.Soil)
                {
                    plotIs = PlotState.Potatoe_Seedling;
                }
                break;

            case PlayerController.InHand.Tomatoe_Seeds:

                if(plotIs == PlotState.Soil)
                {
                    plotIs = PlotState.Tomatoe_Seedling;
                }
                break;

            case PlayerController.InHand.Plucker:
                if(plotIs == PlotState.Rubbish)
                {
                    plotIs = PlotState.Soil;
                }                   
                break;
                
        }
    }
}
