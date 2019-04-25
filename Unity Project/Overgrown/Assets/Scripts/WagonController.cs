using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WagonController : MonoBehaviour
{
    public GameObject carrot;
    public GameObject tomatoe;

    List<GameObject> wagonInventory;

    GameObject CarrotSpot;
    GameObject TomatoSpot;

    PlayerController player = new PlayerController();

    int itemSpace;

    int tomatoesCount;
    int carrotsCount;




    // Use this for initialization
    void Start()
    {

        wagonInventory = new List<GameObject>();


    }

    // Update is called once per frame
    void Update()
    {

        print("Item Space: " + itemSpace);

        print("Tomatoe Count: " + tomatoesCount);

        print("Carrots Count: " + carrotsCount);

        //   print("are tomatoes on the table " + TomatoesOnTheTable());

        print("are carrots on the table " + SomethingOnTable()); ;




    }

    internal void putCarrotOn()
    {


        CarrotSpot = Instantiate(carrot, transform.position + Vector3.up * wagonInventory.Count, Quaternion.identity);
        wagonInventory.Add(CarrotSpot);

        carrotsCount++;


    }

    internal void putTomatoOn()
    {

        TomatoSpot = Instantiate(tomatoe, transform.position + Vector3.up * wagonInventory.Count, Quaternion.identity);
        wagonInventory.Add(TomatoSpot);

        tomatoesCount++;



    }

    public bool SomethingOnTable()
    {
        return wagonInventory.Count > 0;
    }


    internal GameObject removeTopItem()
    {
        carrotsCount--;
        GameObject item = wagonInventory[wagonInventory.Count - 1];

        wagonInventory.Remove(item);
        Destroy(item, 0.1f);
        return item;
    }
}
