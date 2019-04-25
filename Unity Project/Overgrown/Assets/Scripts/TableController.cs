using System;
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

    int itemSpace;

    int tomatoesCount;
    int carrotsCount;




    // Use this for initialization
    void Start()
    {

        tableInventory = new List<GameObject>();


    }

    // Update is called once per frame
    void Update()
    {

        print("Item Space: " +itemSpace);

        print("Tomatoe Count: " + tomatoesCount);

        print("Carrots Count: " + carrotsCount);

     //   print("are tomatoes on the table " + TomatoesOnTheTable());

        print("are carrots on the table " + SomethingOnTable()); ;




    }

    internal void putCarrotOn()
    {

     
            CarrotSpot = Instantiate(carrot, transform.position + Vector3.up * tableInventory.Count, Quaternion.identity);
            tableInventory.Add(CarrotSpot);
           
            carrotsCount++;
        

    }

    internal void putTomatoOn()
    {
    
            TomatoSpot = Instantiate(tomatoe, transform.position + Vector3.up * tableInventory.Count, Quaternion.identity);
            tableInventory.Add(TomatoSpot);

            tomatoesCount++;
        
 

    }

    public bool SomethingOnTable()
    {
        return tableInventory.Count > 0; 
    }


    internal GameObject removeTopItem()
    {
        carrotsCount--;
        GameObject item = tableInventory[tableInventory.Count - 1];

        tableInventory.Remove(item);
        Destroy(item, 0.1f);
        return item;
    }
}
