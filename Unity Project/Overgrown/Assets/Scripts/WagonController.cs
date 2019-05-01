using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WagonController : MonoBehaviour
{

    [Header("Wagon Movement")]

    public GameObject[] waypoints;
    int current = 0;
    float rotSpeed;
    public float speed;
    float WPradius = 1;

    float wagonTimer = 6f;



    [Header("Veggie Controller")]
    public GameObject carrot;
    public GameObject tomatoe;

    List<GameObject> wagonInventory;

    GameObject CarrotSpot;
    GameObject TomatoSpot;

    PlayerController player = new PlayerController();

    int itemSpace;

    int tomatoesCount;
    int carrotsCount;

    int randomTomatoes;
    int randomCarrots;




    // Use this for initialization
    void Start()
    {

        wagonInventory = new List<GameObject>();


    }


    // Update is called once per frame
    void Update()
    {

        RequiredVeg();

        if(wagonTimer > 0)
        {
            WagonComingIn();
        }

        if (wagonTimer <= 0)
        {
            WagonLeaving();
        }

        TimerCountDown();

        RandomGeneratedNumbers();


        /*(  wagonTimer = wagonTimer - Time.deltaTime;

          if(wagonTimer > 0)
          {
              if (Vector3.Distance(waypoints[current].transform.position, transform.position) < WPradius)
              {
                  current++;
                  if (current >= waypoints.Length)
                  {
                      current = 0;
                  }
              }

              transform.position = Vector3.MoveTowards(transform.position, waypoints[current].transform.position, Time.deltaTime * speed);
          }
          else
          {
              wagonTimer = 5f;
          }*/



    }

    private void RandomGeneratedNumbers()
    {
        //
        UnityEngine.Random.Range(1, 20);

    }

    private void TimerCountDown()
    {


        TextMesh timerCount = GameObject.Find("Timer").GetComponent<TextMesh>();
        timerCount.text = wagonTimer.ToString("F2");

        if (transform.position == waypoints[0].transform.position)
        {
            wagonTimer = wagonTimer - Time.deltaTime;
        }

        if (transform.position == waypoints[1].transform.position)
        {
            wagonTimer = 5f;
        }
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



    private void WagonComingIn()
    {

     transform.position = Vector3.MoveTowards(transform.position, waypoints[0].transform.position, Time.deltaTime * speed);

    }

    private void RequiredVeg()
    {
        if (transform.position == waypoints[0].transform.position)
        {
            TextMesh TomatoeText = GameObject.Find("RequiredTomatoes").GetComponent<TextMesh>();
            TomatoeText.text = randomTomatoes.ToString("F2");

            TextMesh CarrotText = GameObject.Find("RequiredCarrots").GetComponent<TextMesh>();
            CarrotText.text = randomCarrots.ToString("F2");
        }



    }

    private void WagonLeaving()
    {
        transform.position = Vector3.MoveTowards(transform.position, waypoints[1].transform.position, Time.deltaTime * speed);
    }



}
