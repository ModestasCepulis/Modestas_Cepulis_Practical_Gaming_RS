using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeOut : MonoBehaviour {

    public GameObject FadeScreen;

	// Use this for initialization
	void Start () {

        FadeScreen.GetComponent<Animation>().Play("Fade Animation");

		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
