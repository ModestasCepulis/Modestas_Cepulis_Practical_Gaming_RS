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

    int itemSpace = 0;
    int tomatoesCount = 0;
    int carrotsCount = 0;




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

    }

    internal void putCarrotOn()
    {

        if(itemSpace == 0)
        {
            CarrotSpot = Instantiate(carrot, transform.position + Vector3.up * tableInventory.Count, Quaternion.identity);
            tableInventory.Add(CarrotSpot);
            itemSpace++;
            tomatoesCount++;
        }
    }

    internal void putTomatoOn()
    {
        if(itemSpace == 0)
        {
            TomatoSpot = Instantiate(tomatoe, transform.position + Vector3.up * tableInventory.Count, Quaternion.identity);
            tableInventory.Add(TomatoSpot);
            itemSpace++;
            tomatoesCount++;
        }

    }

    public bool CarrotsOnTheTable()
    {
         if (carrotsCount > 0)
         {      
            CarrotSpot.SetActive(false);
            tableInventory.Remove(CarrotSpot);
            itemSpace = 0;
            carrotsCount = 0;

            return true;
        }

        return false;
    }   

    public bool TomatoesOnTheTable()
    {
        if (tomatoesCount > 0)
        {
            TomatoSpot.SetActive(false);
            tableInventory.Remove(TomatoSpot);
            itemSpace = 0;
            tomatoesCount = 0;

            return true;
        }

        return false;


    }


}
