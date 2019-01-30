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

    // Use this for initialization
    void Start () {

		
	}
	
	// Update is called once per frame
	void Update () {

        IsMoving();
		
	}

    /// <summary>
    /// Moves forward by certain speed/units per second
    /// </summary>
    private void moveForward()
    {
        if(Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward * walkingSpeed * Time.deltaTime);
        }
        
    }

    /// <summary>
    /// Moves backwards by a certain speed
    /// </summary>
    private void moveBackwards()
    {
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.back * walkingSpeed * Time.deltaTime);
        }

    }

    /// <summary>
    /// Turns left by a certain turning speed
    /// </summary>
    private void turnLeft()
    {
        if(Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * turningSpeed * Time.deltaTime);
        }
    }

    /// <summary>
    /// Turns right by a certain turning speed
    /// </summary>
    private void turnRight()
    {
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * turningSpeed * Time.deltaTime);

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

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Seeds")
        {
           if(Input.GetKeyDown(KeyCode.Space))
            {
                print("You just picked up some seeds");
            }
                  
        }
    }

    //checks if the player colides with an object that has a specific gamer tag.


}
