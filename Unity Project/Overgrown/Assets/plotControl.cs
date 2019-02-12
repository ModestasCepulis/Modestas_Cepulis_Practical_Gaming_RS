using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class plotControl : MonoBehaviour {


    enum PlotState { Empty, Potatoe_Seedling, Tomatoe_Seedling, etc}
    PlotState plotIs = PlotState.Empty;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    internal void Interact(PlayerController.InHand currently_Holding)
    {
        switch (currently_Holding)
        {
            case PlayerController.InHand.Empty:
                // Check harvest etc..
                break;

            case PlayerController.InHand.Potatoe_Seeds:

                if (plotIs == PlotState.Empty)
                {
                    plotIs = PlotState.Potatoe_Seedling;

                }
                break;
        }
    }
}
