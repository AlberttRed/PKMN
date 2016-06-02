using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
#if UNITY_EDITOR
using UnityEditor;
#endif 
using System.IO;

public class Battle_System : MonoBehaviour {
    private static GameObject Pantalla_batalla;
    private static GameObject Camera_Batalla;
    private static GameObject Main_Camera;
    public Button huir;
    private static bool Combate;
    void Awake()
    {
        
        huir = GameObject.Find("ButtonHuir").GetComponent<Button>();
        huir.onClick.RemoveAllListeners();
        huir.onClick.AddListener(SalirCombate);
        //     Pantalla_batalla = GetComponent<Canvas>();
        Pantalla_batalla = GameObject.Find("Fondo");
        Pantalla_batalla.gameObject.SetActive(false);
        Camera_Batalla = GameObject.Find("Camera Batalla");
        Camera_Batalla.gameObject.SetActive(false);
        Main_Camera = GameObject.Find("Main Camera");
        Debug.Log("LOLC");
    }

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void StartBattle(Pokemon my, Pokemon rival)
    {

        Pantalla_batalla.gameObject.SetActive(true);
        GameObject.Find("Rival_PKMN").GetComponent<Image>().sprite = Resources.Load<Sprite>("Battlers/" + string.Format("{0:000}", rival.id));
        GameObject.Find("My_PKMN").GetComponent<Image>().sprite = Resources.Load<Sprite>("Battlers/" + string.Format("{0:000}", my.id) + "b");
        Camera_Batalla.gameObject.SetActive(true);
        Main_Camera.SetActive(false);
        
        
    }

    public static void SalirCombate()
    {
        Combate = false;
        Pantalla_batalla.gameObject.SetActive(false);
        Camera_Batalla.SetActive(false);
        Main_Camera.SetActive(true);
    }
}
