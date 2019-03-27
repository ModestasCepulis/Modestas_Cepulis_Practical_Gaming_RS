using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableController : MonoBehaviour
{

    public GameObject carrot;
    public GameObject tomatoe;

    List<GameObject> tableInventory;

    GameObject CarrotSpot;
    GameObject TomatoSpot;

    PlayerController player = new PlayerController();

    string currentItemForPlayer;




    // Use this for initialization
    void Start()
    {

        tableInventory = new List<GameObject>();


    }

    // Update is called once per frame
    void Update()
    {

    }

    internal void putCarrotOn()
    {
        CarrotSpot = Instantiate(carrot, transform.position + Vector3.up * tableInventory.Count, Quaternion.identity);

        tableInventory.Add(CarrotSpot);
    }

    internal void putTomatoOn()
    {
        TomatoSpot = Instantiate(tomatoe, transform.position + Vector3.up * tableInventory.Count, Quaternion.identity);
        tableInventory.Add(TomatoSpot);
    }

    internal void InventoryItemTaken(PlayerController.InHand currently_Holding)
    {

         if (tableInventory.Contains(CarrotSpot))
         {
            PlayerController.InHand.Carrots;

            tableInventory.Remove(CarrotSpot);
            CarrotSpot.SetActive(false);
        }

        if (tableInventory.Contains(TomatoSpot))
        {
            PlayerController.InHand.Tomatoes;

            tableInventory.Remove(TomatoSpot);
            TomatoSpot.SetActive(false);           
        }

    }   
}
