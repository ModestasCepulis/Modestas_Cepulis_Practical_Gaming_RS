using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour

{   internal enum InHand { Empty, Potatoe_Seeds, Tomatoe_Seeds,Water, Potatoes, Tomatoes}

    InHand currently_Holding = InHand.Empty;
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

    // Use this for initialization
    void Start () {

		
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
                            case PlantsController.PlantType.Potatoe:
                                currently_Holding = InHand.Potatoe_Seeds;
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
                    if (currently_Holding == InHand.Potatoe_Seeds || currently_Holding == InHand.Tomatoe_Seeds)
                    {
                        if (plot.plotIs == plotControl.PlotState.Empty)
                        {
                            plot.Interact(currently_Holding);
                            currently_Holding = InHand.Empty;
                        }
                    }

                    
         
                }

                TrashController trash = info.collider.GetComponent<TrashController>();
                if (trash)
                {
                    currently_Holding = InHand.Empty;
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
