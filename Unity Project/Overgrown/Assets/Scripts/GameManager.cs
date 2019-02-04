    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public GameObject seedsTest;
    private float counting = 1;

	// Use this for initialization
	void Start () {



        seedsTest = GameObject.Find("Seeds");

 


    }

    // Update is called once per frame
    void Update () {

        if (counting == 1)
        {
            var newPosition = new Vector3(7, 1, 1);
            var newRotation = Quaternion.identity;
            var newObject = Instantiate(seedsTest, newPosition, newRotation);
            counting = 2;
        }

    }
}
