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

    private float raycastRange = 2f;

    public string playerName;

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
	void Update () {

        if (playerName == "Player1")
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

                Interact();
            }

            //Iventory system 

            if (currently_Holding == InHand.Plucker)
            {
               Shovel_item_player_1.SetActive(true);
            }

            if(currently_Holding == InHand.Tomatoes)
            {
               tomatoes_item_player_1.SetActive(true);
            }

            if(currently_Holding == InHand.Tomatoe_Seeds)
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

        print(currently_Holding);

        if (playerName == "Player2")
        {
            if (Input.GetKey(KeyCode.UpArrow))
            {
                moveForward();
            }

            if (Input.GetKey(KeyCode.DownArrow))
            {
                moveBackwards();
            }

            if (Input.GetKey(KeyCode.LeftArrow))
            {
                moveLeft();
            }

            if (Input.GetKey(KeyCode.RightArrow))
            {
                moveRight();
            }

            if (Input.GetKeyDown(KeyCode.RightShift))
            {

                Interact();
            }
        }

      

    }

    private void Interact()
    {
   
            Ray lookAt = new Ray(transform.position, transform.forward);
            Debug.DrawRay(lookAt.origin, 10 * lookAt.direction);
            RaycastHit info;

            //the Array only works if it is in the range of 'raycastRange'
            if (Physics.Raycast(lookAt, raycastRange))
            {
                //if the raycast hits something.
                if (Physics.Raycast(lookAt, out info))
                {
                    PlantsController plant = info.collider.GetComponent<PlantsController>();
                    if (plant)//if it has the script 'PlantsController' do this
                    {
                    if (currently_Holding == InHand.Empty)
                    {
                        PlantsController.PlantType pickingUP = plant.pickUp();

                        switch (pickingUP)
                        {
                            case PlantsController.PlantType.Carrot:
                                currently_Holding = InHand.Carrot_Seeds;
                                break;
                            case PlantsController.PlantType.Tomatoe:
                                currently_Holding = InHand.Tomatoe_Seeds;
                                break;
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
                            currently_Holding = InHand.Empty;
                        }
                    }

                    //plucker for removing the rubbish (grass)
                    if(currently_Holding == InHand.Plucker)
                    {
                        if(plot.plotIs == plotControl.PlotState.Rubbish)
                        {
                            plot.Interact(currently_Holding);                        
                        }
                    }

                    //Once the plant is grown (tomato)
                    if (currently_Holding == InHand.Empty)
                    {
                        if (plot.plotIs == plotControl.PlotState.Tomatoe_Plant)
                        {
                            plot.Interact(currently_Holding);
                            currently_Holding = InHand.Tomatoes;
                        }
                    }

                    //Once the plant is grown (carrots) (so that the player could pick up the item)
                    if (currently_Holding == InHand.Empty)
                    {
                        if (plot.plotIs == plotControl.PlotState.Carrot_Plant)
                        {
                            plot.Interact(currently_Holding);
                            currently_Holding = InHand.Carrots;
                        }
                    }




                }

                TrashController trash = info.collider.GetComponent<TrashController>();
                if (trash)
                {
                    currently_Holding = InHand.Empty;
                }

                PluckerControl plucker = info.collider.GetComponent<PluckerControl>();
                if (plucker)
                {
                    if(currently_Holding == InHand.Empty)
                    {
                        currently_Holding = InHand.Plucker;
                    }

                }

                TableController table = info.collider.GetComponent<TableController>();
                if(table)
                {
                    if (currently_Holding == InHand.Empty)
                    {
                        table.InventoryItemTaken();                       
                    }

                    if (currently_Holding == InHand.Carrots)
                    {                       
                        currently_Holding = InHand.Empty;
                        table.putCarrotOn();
                    }

                    if (currently_Holding == InHand.Tomatoes)
                    {
                        currently_Holding = InHand.Empty;
                        table.putTomatoOn();
                    }
                  

                }
            }
            }

        
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

    /// <summary>
    /// Uses a selected item
    /// </summary>
    private void useItem()
    {
     
    }

    /// <summary>
    /// Picks up a selected item
    /// </summary>
    private void pickUpItem()
    {
      
    }

    /// <summary>
    /// Drops a selected item
    /// </summary>
    private void dropItem()
    {
       
    }


}
