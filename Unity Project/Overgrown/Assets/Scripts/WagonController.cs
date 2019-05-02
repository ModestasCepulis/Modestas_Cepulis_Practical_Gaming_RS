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

    float wagonTimer;
    float defaultWagonTime = 100f;



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

    int sumOfRequiredVeg;

    [Header("Score controller")]

    int score;
    int totalScore;





    // Use this for initialization
    void Start()
    {

        wagonInventory = new List<GameObject>();

        randomTomatoes = UnityEngine.Random.Range(1, 30);

        randomCarrots = UnityEngine.Random.Range(1, 30);

        sumOfRequiredVeg = randomTomatoes + randomCarrots;



        if (sumOfRequiredVeg >= 20)
        {
            wagonTimer = 50f;
        }

        if (sumOfRequiredVeg >= 40)
        {
            wagonTimer = 120f;
        }

        if (sumOfRequiredVeg < 20)
        {
            wagonTimer = 45f;
        }

        if (sumOfRequiredVeg <= 10)
        {
            wagonTimer = 20f;
        }





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


        if (randomTomatoes <= tomatoesCount && randomCarrots <= carrotsCount)
        {
            WagonLeaving();
        }




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

        //if it goes to the front position(the actual game area)
        if (transform.position == waypoints[0].transform.position)
        {
            wagonTimer = wagonTimer - Time.deltaTime;
        }

        //if it goes to the back position (outside of game area)
        if (transform.position == waypoints[1].transform.position)
        {
            //RESET EVERYTHING
            wagonTimer = defaultWagonTime;
            score = tomatoesCount * carrotsCount;
            totalScore = totalScore + score;

            carrotsCount = 0;
            tomatoesCount = 0;


            TextMesh scoreCount = GameObject.Find("Score").GetComponent<TextMesh>();
            scoreCount.text = totalScore.ToString("F2");

            removingWagonItems();

        }
    }

    internal void putCarrotOn()
    {


        CarrotSpot = Instantiate(carrot, transform.position + Vector3.up * wagonInventory.Count, Quaternion.identity, transform);
        wagonInventory.Add(CarrotSpot);

        carrotsCount++;

        randomCarrots = randomCarrots - 1;


    }

    internal void putTomatoOn()
    {

        TomatoSpot = Instantiate(tomatoe, transform.position + Vector3.up * wagonInventory.Count, Quaternion.identity, transform);
        wagonInventory.Add(TomatoSpot);

        tomatoesCount++;

        randomTomatoes = randomTomatoes - 1;



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
            TomatoeText.text = randomTomatoes.ToString("F0");

            TextMesh CarrotText = GameObject.Find("RequiredCarrots").GetComponent<TextMesh>();
            CarrotText.text = randomCarrots.ToString("F0");

            //if the player adds more than the required amount the system gives the player more points for it
            if (randomCarrots <= 0)
            {
                CarrotText.text = "EXTRA";
            }

            if (randomTomatoes <= 0)
            {
                TomatoeText.text = "EXTRA";
            }

        }



    }

    private void WagonLeaving()
    {
        transform.position = Vector3.MoveTowards(transform.position, waypoints[1].transform.position, Time.deltaTime * speed);

    }

    private void removingWagonItems()
    {
        foreach (GameObject item in wagonInventory)
        {
            wagonInventory.Remove(item);
            Destroy(item);
        }

    }



}
