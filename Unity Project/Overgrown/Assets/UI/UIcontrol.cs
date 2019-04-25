using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIcontrol : MonoBehaviour {


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void StartTheGame()
    {
        SceneManager.LoadScene("FirstScene");

    }

    public void ExitTheGame()
    {
        Application.Quit();
    }

}
