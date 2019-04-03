using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class plotControl : MonoBehaviour {


    internal enum PlotState {Soil, Rubbish, Carrot_Seedling, Tomatoe_Seedling, Carrot_Plant, Tomatoe_Plant, Unwatered_Carrot_Plant, Unwatered_Tomatoe_Plant}

    internal PlotState plotIs = PlotState.Rubbish;

    float growthTimer = 2.0f;
    float timerAfterGrowth = 2.0f;

    public GameObject rubbish;
    public GameObject Tomato_Seedling;
    public GameObject Tomato_Plant;
    public GameObject Carrot_Seedling;
    public GameObject Carrot_Plant;

    public GameObject Shovel;
    public GameObject tomato_seeds_item;
    public GameObject tomatoes_item;

    GameObject Rubbish1;
    GameObject Rubbish2;
    GameObject Rubbish3;

    GameObject TomatoSeedling1;
    GameObject TomatoSeedling2;
    GameObject TomatoSeedling3;

    GameObject TomatoPlant1;
    GameObject TomatoPlant2;
    GameObject TomatoPlant3;

    GameObject CarrotSeedling1;
    GameObject CarrotSeedling2;
    GameObject CarrotSeedling3;


    GameObject CarrotPlant1;
    GameObject CarrotPlant2;
    GameObject CarrotPlant3;

    GameObject Shovel_item_1;
    GameObject tomato_seeds_item_1;
    GameObject tomatoes_item_1;

    public string plotName;




    // Use this for initialization
    void Start () {

        //Plot system
        if (plotName == "PlotOne")
        {
            Rubbish1 = Instantiate(rubbish, new Vector3(12.83f, 5.092f, 4.69f), Quaternion.identity);

            TomatoSeedling1 = Instantiate(Tomato_Seedling, new Vector3(19.02f, -0.28f, 7.33f), Quaternion.identity);
            TomatoPlant1 = Instantiate(Tomato_Plant, new Vector3(17.84f, -0.28f, 3.86f), Quaternion.identity);

            CarrotSeedling1 = Instantiate(Carrot_Seedling, new Vector3(9.92f, 10.07f, 5.87f), Quaternion.identity);
            CarrotPlant1 = Instantiate(Carrot_Plant, new Vector3(17.65f, -0.28f, 3.93f), Quaternion.identity);
        
            TomatoSeedling1.SetActive(false);
            TomatoPlant1.SetActive(false);

            CarrotSeedling1.SetActive(false);
            CarrotPlant1.SetActive(false);
        }

        if (plotName == "PlotTwo")
        {
            Rubbish2 = Instantiate(rubbish, new Vector3(12.83f, 5.092f, -4.35f), Quaternion.identity);

            TomatoSeedling2 = Instantiate(Tomato_Seedling, new Vector3(19.02f, -0.28f, -1.71f), Quaternion.identity);
            TomatoPlant2 = Instantiate(Tomato_Plant, new Vector3(17.84f, -0.28f, -5.18f), Quaternion.identity);

            CarrotSeedling2 = Instantiate(Carrot_Seedling, new Vector3(9.92f, 10.07f, -3.17f), Quaternion.identity);
            CarrotPlant2 = Instantiate(Carrot_Plant, new Vector3(17.65f, -0.28f, -5.11f), Quaternion.identity);

            TomatoSeedling2.SetActive(false);
            TomatoPlant2.SetActive(false);

            CarrotSeedling2.SetActive(false);
            CarrotPlant2.SetActive(false);
        }

        if (plotName == "PlotThree")
        {
            Rubbish3 = Instantiate(rubbish, new Vector3(12.83f, 5.092f, -12.28f), Quaternion.identity);

            TomatoSeedling3 = Instantiate(Tomato_Seedling, new Vector3(19.02f, -0.28f, -9.64f), Quaternion.identity);
            TomatoPlant3 = Instantiate(Tomato_Plant, new Vector3(17.84f, -0.28f, -13.11f), Quaternion.identity);

            CarrotSeedling3 = Instantiate(Carrot_Seedling, new Vector3(9.92f, 10.07f, -11.1f), Quaternion.identity);
            CarrotPlant3 = Instantiate(Carrot_Plant, new Vector3(17.65f, -0.28f, -13.04f), Quaternion.identity);

            TomatoSeedling3.SetActive(false);
            TomatoPlant3.SetActive(false);

            CarrotSeedling3.SetActive(false);
            CarrotPlant3.SetActive(false);
        }
        
    }

    // Update is called once per frame
    void Update () {

        //Plants
        if (plotName == "PlotOne")
        {
            //Rubbish
            if (plotIs == PlotState.Rubbish)
            {
                TomatoPlant1.SetActive(false);
                CarrotPlant1.SetActive(false);
                Rubbish1.SetActive(true);
            }

            //Soil plot
            if (plotIs == PlotState.Soil)
            {
                Rubbish1.SetActive(false);
            }

            //Tomato
            if (plotIs == PlotState.Tomatoe_Seedling)
            {
                TomatoSeedling1.SetActive(true);

                growthTimer = growthTimer - Time.deltaTime;

                if (growthTimer <= 0)
                {
                    plotIs = PlotState.Tomatoe_Plant;
                    growthTimer = timerAfterGrowth;                    
                }
            }

            if (plotIs == PlotState.Tomatoe_Plant)
            {
                TomatoSeedling1.SetActive(false);
                TomatoPlant1.SetActive(true);

            }

            //Carrot
            if (plotIs == PlotState.Carrot_Seedling)
            {
                CarrotSeedling1.SetActive(true);

                growthTimer = growthTimer - Time.deltaTime;

                if (growthTimer <= 0)
                {                   
                    plotIs = PlotState.Carrot_Plant;
                    growthTimer = timerAfterGrowth;
                }
            }

            if (plotIs == PlotState.Carrot_Plant)
            {
                CarrotSeedling1.SetActive(false);
                CarrotPlant1.SetActive(true);

            }

        }


        if (plotName == "PlotTwo")
        {
            //Rubbish
            if (plotIs == PlotState.Rubbish)
            {
                TomatoPlant2.SetActive(false);
                CarrotPlant2.SetActive(false);
                Rubbish2.SetActive(true);
            }

            //Soil plot
            if (plotIs == PlotState.Soil)
            {
                Rubbish2.SetActive(false);
            }

            //Tomato
            if (plotIs == PlotState.Tomatoe_Seedling)
            {
                TomatoSeedling2.SetActive(true);

                growthTimer = growthTimer - Time.deltaTime;

                if (growthTimer <= 0)
                {
                    plotIs = PlotState.Tomatoe_Plant;
                    growthTimer = timerAfterGrowth;
                }
            }

            if (plotIs == PlotState.Tomatoe_Plant)
            {
                TomatoSeedling2.SetActive(false);
                TomatoPlant2.SetActive(true);

            }

            //Carrot
            if (plotIs == PlotState.Carrot_Seedling)
            {
                CarrotSeedling2.SetActive(true);

                growthTimer = growthTimer - Time.deltaTime;

                if (growthTimer <= 0)
                {
                    plotIs = PlotState.Carrot_Plant;
                    growthTimer = timerAfterGrowth;
                }
            }

            if (plotIs == PlotState.Carrot_Plant)
            {
                CarrotSeedling2.SetActive(false);
                CarrotPlant2.SetActive(true);

            }

        }

        if (plotName == "PlotThree")
        {
            //Rubbish
            if (plotIs == PlotState.Rubbish)
            {
                TomatoPlant3.SetActive(false);
                CarrotPlant3.SetActive(false);
                Rubbish3.SetActive(true);
            }

            //Soil plot
            if (plotIs == PlotState.Soil)
            {
                Rubbish3.SetActive(false);
            }

            //Tomato
            if (plotIs == PlotState.Tomatoe_Seedling)
            {
                TomatoSeedling3.SetActive(true);

                growthTimer = growthTimer - Time.deltaTime;

                if (growthTimer <= 0)
                {
                    plotIs = PlotState.Tomatoe_Plant;
                    growthTimer = timerAfterGrowth;
                }
            }

            if (plotIs == PlotState.Tomatoe_Plant)
            {
                TomatoSeedling3.SetActive(false);
                TomatoPlant3.SetActive(true);

            }

            //Carrot
            if (plotIs == PlotState.Carrot_Seedling)
            {
                CarrotSeedling3.SetActive(true);

                growthTimer = growthTimer - Time.deltaTime;

                if (growthTimer <= 0)
                {
                    plotIs = PlotState.Carrot_Plant;
                    growthTimer = timerAfterGrowth;
                }
            }

            if (plotIs == PlotState.Carrot_Plant)
            {
                CarrotSeedling3.SetActive(false);
                CarrotPlant3.SetActive(true);

            }

        }


    }

    internal void Interact(PlayerController.InHand currently_Holding)
    {
        switch (currently_Holding)
        {
            case PlayerController.InHand.Empty:
                // Check harvest etc.. (When the player harvests the plant)
                if (plotIs == PlotState.Tomatoe_Plant)
                {
                    plotIs = PlotState.Rubbish;
                }

                if (plotIs == PlotState.Carrot_Plant)
                {
                    plotIs = PlotState.Rubbish;
                }

                break;


            case PlayerController.InHand.Carrot_Seeds:

                if (plotIs == PlotState.Soil)
                {                 
                    plotIs = PlotState.Carrot_Seedling;
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
