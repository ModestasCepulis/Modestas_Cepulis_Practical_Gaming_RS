using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitchAfterTime : MonoBehaviour {

    public float timerToSwitch;
    public string sceneToChange;

	// Use this for initialization
	void Start () {

		
	}
	
	// Update is called once per frame
	void Update () {

        timerToSwitch = timerToSwitch - Time.deltaTime;

        if (timerToSwitch == 0)
        {
            SceneManager.LoadScene("Anim2");
            timerToSwitch = 0;
        }

    }
}
