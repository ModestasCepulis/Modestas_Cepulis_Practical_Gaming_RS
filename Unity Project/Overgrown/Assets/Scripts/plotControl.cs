using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class plotControl : MonoBehaviour {


    internal enum PlotState {Soil, Rubbish, Potatoe_Seedling, Tomatoe_Seedling, Potatoe_Plant, Tomatoe_Plant, Unwatered_Potatoe_Plant, Unwatered_Tomatoe_Plant}

    internal PlotState plotIs = PlotState.Rubbish;

    float growthTimer = 10.0f;

    public GameObject rubbish;
    public GameObject Tomato_Seedling;

    GameObject Rubbish1;
    GameObject Rubbish2;
    GameObject Rubbish3;

    GameObject TomatoSeedling1;
    GameObject TomatoSeedling2;
    GameObject TomatoSeedling3;

    public string plotName;




    // Use this for initialization
    void Start () {

        if (plotName == "PlotOne")
        {
            Rubbish1 = Instantiate(rubbish, new Vector3(27.84f, -5.09727f, 4.28f), Quaternion.identity);
            TomatoSeedling1 = Instantiate(Tomato_Seedling, new Vector3(16.64f, -0.46f, 4.17f), Quaternion.identity);
            TomatoSeedling1.SetActive(false);
        }

        if (plotName == "PlotTwo")
        {
            Rubbish2 = Instantiate(rubbish, new Vector3(27.84f, -5.09727f, -5.5f), Quaternion.identity);
            TomatoSeedling2 = Instantiate(Tomato_Seedling, new Vector3(16.64f, -0.46f, -4.58f), Quaternion.identity);
            TomatoSeedling2.SetActive(false);
        }

        if (plotName == "PlotThree")
        {
            Rubbish3 = Instantiate(rubbish, new Vector3(27.84f, -5.09727f, -14.25f), Quaternion.identity);
            TomatoSeedling3 = Instantiate(Tomato_Seedling, new Vector3(16.64f, -0.46f, -13.79f), Quaternion.identity);
            TomatoSeedling3.SetActive(false);
        }

    }

    // Update is called once per frame
    void Update () {

        print(plotIs + " plot ");

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


        //Plants
        if (plotName == "PlotOne")
        {
            if (plotIs == PlotState.Soil)
            {
                Rubbish1.SetActive(false);
            }

            if (plotIs == PlotState.Tomatoe_Seedling)
            {
                TomatoSeedling1.SetActive(true);
            }

        }


        if (plotName == "PlotTwo")
        {
            if (plotIs == PlotState.Soil)
            {
                Rubbish2.SetActive(false);
            }

            if (plotIs == PlotState.Tomatoe_Seedling)
            {
                TomatoSeedling2.SetActive(true);
            }

        }

        if (plotName == "PlotThree")
        {
            if (plotIs == PlotState.Soil)
            {
                Rubbish3.SetActive(false);
            }

            if (plotIs == PlotState.Tomatoe_Seedling)
            {
                TomatoSeedling3.SetActive(true);
            }

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
