using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;
#if UNITY_EDITOR
using UnityEditor;
#endif 
using System.IO;

public class Battle_System : MonoBehaviour {
    private static GameObject Pantalla_batalla;
    private static GameObject Camera_Batalla;
    private static GameObject Main_Camera;
    private EventSystem es;
    TextBoxManager TBManager;
    public Button huir, luchar, mochila, pkmn;
    private static bool Combate;
    void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        huir = GameObject.Find("ButtonHuir").GetComponent<Button>();
        pkmn = GameObject.Find("ButtonPKMN").GetComponent<Button>();
        luchar = GameObject.Find("ButtonLuchar").GetComponent<Button>();
        mochila = GameObject.Find("ButtonMochila").GetComponent<Button>();
        huir.onClick.RemoveAllListeners();
        luchar.onClick.RemoveAllListeners();
        luchar.onClick.AddListener(SalirCombate);
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
        //es = GameObject.Find("EventSystem").GetComponent<EventSystem>();
        //Debug.Log(es.name);
        //es.SetSelectedGameObject(GameObject.Find("ButtonLuchar"));
        // GameObject.FindGameObjectWithTag("TextBattle").GetComponent<Text>();
       
        Pantalla_batalla.gameObject.SetActive(true);
        GameObject.Find("Rival_PKMN").GetComponent<Image>().sprite = Resources.Load<Sprite>("Battlers/" + string.Format("{0:000}", rival.id));
        GameObject.Find("My_PKMN").GetComponent<Image>().sprite = Resources.Load<Sprite>("Battlers/" + string.Format("{0:000}", my.id) + "b");
        Camera_Batalla.gameObject.SetActive(true);
        TBManager = FindObjectOfType<TextBoxManager>();
        TBManager.textBox = GameObject.FindGameObjectWithTag("TextBoxBattle");
        TBManager.theText = TBManager.textBox.GetComponentInChildren<Text>();
        TBManager.altura = 38;
        Main_Camera.SetActive(false);
        Button bt = GameObject.Find("ButtonLuchar").GetComponent<Button>();
        bt.Select();
        // TBManager.mensaje = "¡Un " + rival.nombre + " salvaje apareció!                   ¿Qué debería hacer " + my.nombre + "?";
        string mensajes = "¡Un " + rival.nombre + " salvaje apareció!;¿Qué debería hacer " + my.nombre + "?";
        TBManager.TextBox_Write(mensajes.Split(';'));
        
    }

    public static void SalirCombate()
    {
        Combate = false;
        Pantalla_batalla.gameObject.SetActive(false);
        Camera_Batalla.SetActive(false);
        Main_Camera.SetActive(true);
    }
}
