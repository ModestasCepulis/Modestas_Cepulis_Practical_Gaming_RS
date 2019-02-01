﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour

{
    /// <summary>
    /// The walking speed of the character
    /// </summary>
    private float walkingSpeed = 20f;
    /// <summary>
    /// The turning speed of the character
    /// </summary>
    private float turningSpeed = 20f;

    private float raycastRange = 2f;

    // Use this for initialization
    void Start () {

		
	}
	
	// Update is called once per frame
	void Update () {

        isArrayHit();

        IsMoving();
		
	}

    private void isArrayHit()
    {
        if(Input.GetKeyDown(KeyCode.Space))
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
                        plant.TypeOfPlant();

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
        if(Input.GetKey(KeyCode.W))
        {
            transform.position += Vector3.forward * walkingSpeed * Time.deltaTime;
            transform.rotation = Quaternion.LookRotation(Vector3.forward);
        }
        
    }

    /// <summary>
    /// Moves backwards by a certain speed
    /// </summary>
    private void moveBackwards()
    {
        if (Input.GetKey(KeyCode.S))
        {
            transform.position += (Vector3.back * walkingSpeed * Time.deltaTime);
            transform.rotation = Quaternion.LookRotation(Vector3.back);
        }

    }

    /// <summary>
    /// Turns left by a certain turning speed
    /// </summary>
    private void turnLeft()
    {
        if(Input.GetKey(KeyCode.A))
        {
            transform.position+= (Vector3.left * turningSpeed * Time.deltaTime);
            transform.rotation = Quaternion.LookRotation(Vector3.left);
        }
    }

    /// <summary>
    /// Turns right by a certain turning speed
    /// </summary>
    private void turnRight()
    {
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += (Vector3.right * turningSpeed * Time.deltaTime);
            transform.rotation = Quaternion.LookRotation(Vector3.right);
        }
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

    //calls the movement methods in update method
    private void IsMoving()
    {
        moveForward();
        moveBackwards();
        turnLeft();
        turnRight();


    }

    void OnCollisionEnter(Collision other)
    {
        print("Here");
        if (other.gameObject.tag == "Seeds")
        {

                  
        }
    }

    //checks if the player colides with an object that has a specific gamer tag.


}
