using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableController : MonoBehaviour {

    public GameObject carrot;
    public GameObject tomatoe;



	// Use this for initialization
	void Start () {

        GameObject CarrotSpot1 = Instantiate(carrot, new Vector3(-24.27f, -0.28f, -6.51f), Quaternion.identity);
        GameObject CarrotSpot2 = Instantiate(carrot, new Vector3(-24.27f, -0.28f, -6.51f), Quaternion.identity);
        GameObject CarrotSpot3 = Instantiate(carrot, new Vector3(-24.27f, -0.28f, -6.51f), Quaternion.identity);
        GameObject CarrotSpot4 = Instantiate(carrot, new Vector3(-24.27f, -0.28f, -6.51f), Quaternion.identity);
        GameObject CarrotSpot5 = Instantiate(carrot, new Vector3(-24.27f, -0.28f, -6.51f), Quaternion.identity);

        GameObject TomatoeSpot1 = Instantiate(tomatoe, new Vector3(-24.27f, -0.28f, -6.51f), Quaternion.identity);
        GameObject TomatoeSpot2 = Instantiate(tomatoe, new Vector3(-24.27f, -0.28f, -6.51f), Quaternion.identity);
        GameObject TomatoeSpot3 = Instantiate(tomatoe, new Vector3(-24.27f, -0.28f, -6.51f), Quaternion.identity);
        GameObject TomatoeSpot4 = Instantiate(tomatoe, new Vector3(-24.27f, -0.28f, -6.51f), Quaternion.identity);
        GameObject TomatoeSpot5 = Instantiate(tomatoe, new Vector3(-24.27f, -0.28f, -6.51f), Quaternion.identity);



        ArrayList tableInventory = new ArrayList();

        tableInventory.Add(CarrotSpot1);
        tableInventory.Add(CarrotSpot2);
        tableInventory.Add(CarrotSpot3);
        tableInventory.Add(CarrotSpot4);
        tableInventory.Add(CarrotSpot5);

        tableInventory.Add(TomatoeSpot1);
        tableInventory.Add(TomatoeSpot2);
        tableInventory.Add(TomatoeSpot3);
        tableInventory.Add(TomatoeSpot4);
        tableInventory.Add(TomatoeSpot5);

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
