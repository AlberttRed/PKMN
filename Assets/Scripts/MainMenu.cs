using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MainMenu : MonoBehaviour {

    Canvas canvas;
    ScreenFader sf;

    // Use this for initialization
    void Start () {
       

         
        canvas = GetComponent<Canvas>();
        sf = GameObject.FindGameObjectWithTag("Fader").GetComponent<ScreenFader>();
    }
	

	// Update is called once per frame
	void Update () {

       




    }
}
