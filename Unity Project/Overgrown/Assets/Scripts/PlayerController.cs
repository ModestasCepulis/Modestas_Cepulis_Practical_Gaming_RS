using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour

{   internal enum InHand { Empty, Carrot_Seeds,Tomatoe_Seeds, Water, Carrots, Tomatoes, Plucker}

    internal InHand currently_Holding = InHand.Empty;
    /// <summary>
    /// The walking speed of the character
    /// </summary>
    private float walkingSpeed = 20f;
    /// <summary>
    /// The turning speed of the character
    /// </summary>
    private float turningSpeed = 20f;

    private float raycastRange = 4f;

    public GameObject Shovel;

    public GameObject tomato_seeds_item;
    public GameObject tomatoes_item;

    public GameObject carrot_seeds_item;
    public GameObject carrots_item;

    GameObject Shovel_item_player_1;

    GameObject tomato_seeds_item_player_1;
    GameObject tomatoes_item_player_1;

    GameObject carrots_seeds_item_player_1;
    GameObject carrots_item_player_1;

    // Use this for initialization
    void Start () {

        Shovel_item_player_1 = Shovel;
        tomatoes_item_player_1 = tomatoes_item;
        tomato_seeds_item_player_1 = tomato_seeds_item;

        carrots_item_player_1 = carrots_item;
        carrots_seeds_item_player_1 = carrot_seeds_item;

    }

    // Update is called once per frame
    void Update()
    {


        if (Input.GetKey(KeyCode.W))
        {
            moveForward();
        }

        if (Input.GetKey(KeyCode.S))
        {
            moveBackwards();
        }

        if (Input.GetKey(KeyCode.A))
        {
            moveLeft();
        }

        if (Input.GetKey(KeyCode.D))
        {
            moveRight();
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {

            currently_Holding = Interact();
        }

        //Iventory system 

        if (currently_Holding == InHand.Plucker)
        {
            Shovel_item_player_1.SetActive(true);
        }

        if (currently_Holding == InHand.Tomatoes)
        {
            tomatoes_item_player_1.SetActive(true);
        }

        if (currently_Holding == InHand.Tomatoe_Seeds)
        {
            tomato_seeds_item_player_1.SetActive(true);
        }

        if (currently_Holding == InHand.Carrot_Seeds)
        {
            carrots_seeds_item_player_1.SetActive(true);
        }

        if (currently_Holding == InHand.Carrots)
        {
            carrots_item_player_1.SetActive(true);
        }


        if (currently_Holding == InHand.Empty)
        {
            tomato_seeds_item_player_1.SetActive(false);
            tomatoes_item_player_1.SetActive(false);
            carrots_item_player_1.SetActive(false);
            carrots_seeds_item_player_1.SetActive(false);
            Shovel_item_player_1.SetActive(false);

        }
    }
 

    private InHand Interact()
    {
   
            Ray lookAt = new Ray(transform.position, transform.forward);
            Debug.DrawRay(lookAt.origin, 15 * lookAt.direction,Color.red,5);
            RaycastHit info;

            //the Array only works if it is in the range of 'raycastRange'
            if (Physics.Raycast(lookAt, out info, raycastRange))
            {
          
                BarellController barrell = info.collider.GetComponent<BarellController>();
            if (barrell)//if it has the script 'PlantsController' do this
            {
                if (currently_Holding == InHand.Empty)
                {
                    BarellController.PlantType pickingUP = barrell.pickUp();

                    switch (pickingUP)
                    {
                        case BarellController.PlantType.Carrot:
                            return InHand.Carrot_Seeds;
                          
                        case BarellController.PlantType.Tomatoe:
                            return InHand.Tomatoe_Seeds;
                           
                    }
                }
            }
       
                plotControl plot = info.collider.GetComponent<plotControl>();
                if (plot)
                {
                    //Seed planting
                    if (currently_Holding == InHand.Carrot_Seeds || currently_Holding == InHand.Tomatoe_Seeds)
                    {
                        if (plot.plotIs == plotControl.PlotState.Soil)
                        {
                            plot.Interact(currently_Holding);
                            return InHand.Empty;
                        }
                    }

                    //plucker for removing the rubbish (grass)
                    if(currently_Holding == InHand.Plucker)
                    {
                        if(plot.plotIs == plotControl.PlotState.Rubbish)
                        {
                            plot.Interact(currently_Holding);
                        return InHand.Plucker;
                        }
                    }

                    //Once the plant is grown (tomato)
                    if (currently_Holding == InHand.Empty)
                    {
                        if (plot.plotIs == plotControl.PlotState.Tomatoe_Plant)
                        {
                            plot.Interact(currently_Holding);
                            return InHand.Tomatoes;
                        }
                    }

                    //Once the plant is grown (carrots) (so that the player could pick up the item)
                    if (currently_Holding == InHand.Empty)
                    {
                        if (plot.plotIs == plotControl.PlotState.Carrot_Plant)
                        {
                            plot.Interact(currently_Holding);
                           return InHand.Carrots;
                        }
                    }




                }
             
                TrashController trash = info.collider.GetComponent<TrashController>();
                if (trash)
                {
                return InHand.Empty;
                }

                PluckerControl plucker = info.collider.GetComponent<PluckerControl>();
                if (plucker)
                {
                    if(currently_Holding == InHand.Empty)
                    {
                    return InHand.Plucker;
                    }

                }

                TableController table = info.collider.GetComponent<TableController>();
                if(table)
                {
                    if (currently_Holding == InHand.Empty)
                    {
                        if (table.SomethingOnTable())
                        {

                            GameObject item = table.removeTopItem();
                            //add the script to the tomato and carrots prefab and add it to the table, + delete an extra table
                            VegControl newplant = item.GetComponent<VegControl>();
                        if (newplant)
                        {
                            switch (newplant.thisIsA)
                            {
                                case VegControl.VegType.Carrot:


                                    return InHand.Carrots;

                                case VegControl.VegType.Tomatoe:


                                     return InHand.Tomatoes;
                            }
                        }


                      

                        }



                    }





                    else
                    {


                        if (currently_Holding == InHand.Carrots)
                        {

                            table.putCarrotOn();
                        return InHand.Empty;
                    }

                        if (currently_Holding == InHand.Tomatoes)
                        {
 
                            table.putTomatoOn();
                        return InHand.Empty;
                    }

                    }
                }




            WagonController wagon = info.collider.GetComponent<WagonController>();
            if (wagon)
            {
                if (currently_Holding == InHand.Empty)
                {
                    if (wagon.SomethingOnTable())
                    {

                        GameObject item = wagon.removeTopItem();
                        VegControl newplant = item.GetComponent<VegControl>();
                        if (newplant)
                        {
                            switch (newplant.thisIsA)
                            {
                                case VegControl.VegType.Carrot:


                                    return InHand.Carrots;

                                case VegControl.VegType.Tomatoe:


                                    return InHand.Tomatoes;
                            }
                        }




                    }



                }

                else
                {


                    if (currently_Holding == InHand.Carrots)
                    {

                        wagon.putCarrotOn();
                        return InHand.Empty;
                    }

                    if (currently_Holding == InHand.Tomatoes)
                    {

                        wagon.putTomatoOn();
                        return InHand.Empty;
                    }

                }
            }
        }

        return currently_Holding;
        
    }

    /// <summary>
    /// Moves forward by certain speed/units per second
    /// </summary>
    private void moveForward()
    {
  
            transform.position += Vector3.forward * walkingSpeed * Time.deltaTime;
            transform.rotation = Quaternion.LookRotation(Vector3.forward);
        
        
    }

    /// <summary>
    /// Moves backwards by a certain speed
    /// </summary>
    private void moveBackwards()
    {
            transform.position += (Vector3.back * walkingSpeed * Time.deltaTime);
            transform.rotation = Quaternion.LookRotation(Vector3.back);

    }

    /// <summary>
    /// Turns left by a certain turning speed
    /// </summary>
    private void moveLeft()
    {     
            transform.position+= (Vector3.left * turningSpeed * Time.deltaTime);
            transform.rotation = Quaternion.LookRotation(Vector3.left);
    }

    /// <summary>
    /// Turns right by a certain turning speed
    /// </summary>
    private void moveRight()
    {     
            transform.position += (Vector3.right * turningSpeed * Time.deltaTime);
            transform.rotation = Quaternion.LookRotation(Vector3.right);
    }

}
