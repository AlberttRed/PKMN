using UnityEngine;
using System.Collections;
using System;

public class Map : MonoBehaviour {

    Map mapa;
    Datos li;
    public int map_id;
    string id;
    string nombre;
    int[] coordenadas1;
    int[] coordenadas2;
    int[] coordenadas3;
    string punto_interes;
    int[] posicion_vuelo; // 3 numeros
    int[] probabilidad_pkmn = new int[3]; //3 numeros
    string[] land = new string[12];
    string[] landMorning = new string[12];
    string[] landDay = new string[12];
    string[] landNight = new string[12];
    string[] cave = new string[12];
    string[] bugContest = new string[4];
    string[] water = new string[5];
    string[] rockSmash = new string[5];
    string[] oldRod = new string[2];
    string[] goodRod = new string[3];
    string[] superRod = new string[5];
    string[] headbuttLow = new string[8];
    string[] headbuttHigh = new string[8];

    RaycastHit hit;

    #region Getters y Setters
    public string[] HeadbuttHigh
    {
        get
        {
            return HeadbuttHigh1;
        }

        set
        {
            HeadbuttHigh1 = value;
        }
    }

    public string Id
    {
        get
        {
            return id;
        }

        set
        {
            id = value;
        }
    }

    public string Nombre
    {
        get
        {
            return nombre;
        }

        set
        {
            nombre = value;
        }
    }

    public int[] Coordenadas1
    {
        get
        {
            return coordenadas1;
        }

        set
        {
            coordenadas1 = value;
        }
    }

    public int[] Coordenadas2
    {
        get
        {
            return coordenadas2;
        }

        set
        {
            coordenadas2 = value;
        }
    }

    public int[] Coordenadas3
    {
        get
        {
            return coordenadas3;
        }

        set
        {
            coordenadas3 = value;
        }
    }

    public string Punto_interes
    {
        get
        {
            return punto_interes;
        }

        set
        {
            punto_interes = value;
        }
    }

    public int[] Posicion_vuelo
    {
        get
        {
            return posicion_vuelo;
        }

        set
        {
            posicion_vuelo = value;
        }
    }

    public int[] Probabilidad_pkmn
    {
        get
        {
            return probabilidad_pkmn;
        }

        set
        {
            probabilidad_pkmn = value;
        }
    }

    public string[] Land
    {
        get
        {
            return land;
        }

        set
        {
            land = value;
        }
    }

    public string[] LandMorning
    {
        get
        {
            return landMorning;
        }

        set
        {
            landMorning = value;
        }
    }

    public string[] Cave
    {
        get
        {
            return cave;
        }

        set
        {
            cave = value;
        }
    }

    public string[] BugContest
    {
        get
        {
            return bugContest;
        }

        set
        {
            bugContest = value;
        }
    }

    public string[] Water
    {
        get
        {
            return water;
        }

        set
        {
            water = value;
        }
    }

    public string[] RockSmash
    {
        get
        {
            return rockSmash;
        }

        set
        {
            rockSmash = value;
        }
    }

    public string[] OldRod
    {
        get
        {
            return oldRod;
        }

        set
        {
            oldRod = value;
        }
    }

    public string[] GoodRod
    {
        get
        {
            return goodRod;
        }

        set
        {
            goodRod = value;
        }
    }

    public string[] SuperRod
    {
        get
        {
            return superRod;
        }

        set
        {
            superRod = value;
        }
    }

    public string[] HeadbuttLow
    {
        get
        {
            return headbuttLow;
        }

        set
        {
            headbuttLow = value;
        }
    }

    public string[] HeadbuttHigh1
    {
        get
        {
            return headbuttHigh;
        }

        set
        {
            headbuttHigh = value;
        }
    }

    public string[] LandDay
    {
        get
        {
            return landDay;
        }

        set
        {
            landDay = value;
        }
    }

    public string[] LandNight
    {
        get
        {
            return landNight;
        }

        set
        {
            landNight = value;
        }
    }
    #endregion
    void Awake()
    {
        Debug.Log("JUEJUE");

    }

    Map Mapa(int id)
    {
        mapa = GameObject.Find("mapa" + id).GetComponent<Map>();//.GetComponent<Animation>();

        return mapa;
    }

    // Use this for initialization
    void Start () {
        ScreenFader sf = GameObject.Find("HUD").GetComponentInChildren<ScreenFader>();
        Debug.Log("ahfsofsajf");
            StartCoroutine(sf.FadeToClear());
        
        
        //li = new Datos();
        //string fileName = "encounters.txt";
        //string[] probabilidad = li.GetProperties2(map_id, "Probabilidad", fileName).Split(',');

        //this.Probabilidad_pkmn[0] = Convert.ToInt32(probabilidad[0]);
        //this.Probabilidad_pkmn[1] = Convert.ToInt32(probabilidad[1]);
        //this.Probabilidad_pkmn[2] = Convert.ToInt32(probabilidad[2]);

        //this.Land[0] = li.GetProperties2(map_id, "PokemonLand1", fileName);
        //this.Land[1] = li.GetProperties2(map_id, "PokemonLand2", fileName);
        //this.Land[2] = li.GetProperties2(map_id, "PokemonLand3", fileName);
        //this.Land[3] = li.GetProperties2(map_id, "PokemonLand4", fileName);
        //this.Land[4] = li.GetProperties2(map_id, "PokemonLand5", fileName);
        //this.Land[5] = li.GetProperties2(map_id, "PokemonLand6", fileName);
        //this.Land[6] = li.GetProperties2(map_id, "PokemonLand7", fileName);
        //this.Land[7] = li.GetProperties2(map_id, "PokemonLand8", fileName);
        //this.Land[8] = li.GetProperties2(map_id, "PokemonLand9", fileName);
        //this.Land[9] = li.GetProperties2(map_id, "PokemonLand10", fileName);
        //this.Land[10] = li.GetProperties2(map_id, "PokemonLand11", fileName);
        //this.Land[11] = li.GetProperties2(map_id, "PokemonLand12", fileName);

        //this.LandMorning[0] = li.GetProperties2(map_id, "PokemonLandMorning1", fileName);
        //this.LandMorning[1] = li.GetProperties2(map_id, "PokemonLandMorning2", fileName);
        //this.LandMorning[2] = li.GetProperties2(map_id, "PokemonLandMorning3", fileName);
        //this.LandMorning[3] = li.GetProperties2(map_id, "PokemonLandMorning4", fileName);
        //this.LandMorning[4] = li.GetProperties2(map_id, "PokemonLandMorning5", fileName);
        //this.LandMorning[5] = li.GetProperties2(map_id, "PokemonLandMorning6", fileName);
        //this.LandMorning[6] = li.GetProperties2(map_id, "PokemonLandMorning7", fileName);
        //this.LandMorning[8] = li.GetProperties2(map_id, "PokemonLandMorning9", fileName);
        //this.LandMorning[9] = li.GetProperties2(map_id, "PokemonLandMorning10", fileName);
        //this.LandMorning[10] = li.GetProperties2(map_id, "PokemonLandMorning11", fileName);
        //this.LandMorning[11] = li.GetProperties2(map_id, "PokemonLandMorning12", fileName);

        //this.LandDay[0] = li.GetProperties2(map_id, "PokemonLandDay1", fileName);
        //this.LandDay[1] = li.GetProperties2(map_id, "PokemonLandDay2", fileName);
        //this.LandDay[2] = li.GetProperties2(map_id, "PokemonLandDay3", fileName);
        //this.LandDay[3] = li.GetProperties2(map_id, "PokemonLandDay4", fileName);
        //this.LandDay[4] = li.GetProperties2(map_id, "PokemonLandDay5", fileName);
        //this.LandDay[5] = li.GetProperties2(map_id, "PokemonLandDay6", fileName);
        //this.LandDay[6] = li.GetProperties2(map_id, "PokemonLandDay7", fileName);
        //this.LandDay[7] = li.GetProperties2(map_id, "PokemonLandDay8", fileName);
        //this.LandDay[8] = li.GetProperties2(map_id, "PokemonLandDay9", fileName);
        //this.LandDay[9] = li.GetProperties2(map_id, "PokemonLandDay10", fileName);
        //this.LandDay[10] = li.GetProperties2(map_id, "PokemonLandDay11", fileName);
        //this.LandDay[11] = li.GetProperties2(map_id, "PokemonLandDay12", fileName);

        //this.LandNight[0] = li.GetProperties2(map_id, "PokemonLandNight1", fileName);
        //this.LandNight[1] = li.GetProperties2(map_id, "PokemonLandNight2", fileName);
        //this.LandNight[2] = li.GetProperties2(map_id, "PokemonLandNight3", fileName);
        //this.LandNight[3] = li.GetProperties2(map_id, "PokemonLandNight4", fileName);
        //this.LandNight[4] = li.GetProperties2(map_id, "PokemonLandNight5", fileName);
        //this.LandNight[5] = li.GetProperties2(map_id, "PokemonLandNight6", fileName);
        //this.LandNight[6] = li.GetProperties2(map_id, "PokemonLandNight7", fileName);
        //this.LandNight[7] = li.GetProperties2(map_id, "PokemonLandNight8", fileName);
        //this.LandNight[8] = li.GetProperties2(map_id, "PokemonLandNight9", fileName);
        //this.LandNight[9] = li.GetProperties2(map_id, "PokemonLandNight10", fileName);
        //this.LandNight[10] = li.GetProperties2(map_id, "PokemonLandNight11", fileName);
        //this.LandNight[11] = li.GetProperties2(map_id, "PokemonLandNight12", fileName);

        //this.Cave[0] = li.GetProperties2(map_id, "PokemonCave1", fileName);
        //this.Cave[1] = li.GetProperties2(map_id, "PokemonCave2", fileName);
        //this.Cave[2] = li.GetProperties2(map_id, "PokemonCave3", fileName);
        //this.Cave[3] = li.GetProperties2(map_id, "PokemonCave4", fileName);
        //this.Cave[4] = li.GetProperties2(map_id, "PokemonCave5", fileName);
        //this.Cave[5] = li.GetProperties2(map_id, "PokemonCave6", fileName);
        //this.Cave[6] = li.GetProperties2(map_id, "PokemonCave7", fileName);
        //this.Cave[7] = li.GetProperties2(map_id, "PokemonCave8", fileName);
        //this.Cave[8] = li.GetProperties2(map_id, "PokemonCave9", fileName);
        //this.Cave[9] = li.GetProperties2(map_id, "PokemonCave10", fileName);
        //this.Cave[10] = li.GetProperties2(map_id, "PokemonCave11", fileName);
        //this.Cave[11] = li.GetProperties2(map_id, "PokemonCave12", fileName);

        //this.Water[0] = li.GetProperties2(map_id, "PokemonWater1", fileName);
        //this.Water[1] = li.GetProperties2(map_id, "PokemonWater2", fileName);
        //this.Water[2] = li.GetProperties2(map_id, "PokemonWater3", fileName);
        //this.Water[3] = li.GetProperties2(map_id, "PokemonWater4", fileName);
        //this.Water[4] = li.GetProperties2(map_id, "PokemonWater5", fileName);

        //this.RockSmash[0] = li.GetProperties2(map_id, "PokemonRockSmash1", fileName);
        //this.RockSmash[1] = li.GetProperties2(map_id, "PokemonRockSmash2", fileName);
        //this.RockSmash[2] = li.GetProperties2(map_id, "PokemonRockSmash3", fileName);
        //this.RockSmash[3] = li.GetProperties2(map_id, "PokemonRockSmash4", fileName);
        //this.RockSmash[4] = li.GetProperties2(map_id, "PokemonRockSmash5", fileName);

        //this.OldRod[0] = li.GetProperties2(map_id, "PokemonOldRod1", fileName);
        //this.OldRod[1] = li.GetProperties2(map_id, "PokemonOldRod2", fileName);

        //this.GoodRod[0] = li.GetProperties2(map_id, "PokemonGoodRod1", fileName);
        //this.GoodRod[1] = li.GetProperties2(map_id, "PokemonGoodRod2", fileName);
        //this.GoodRod[2] = li.GetProperties2(map_id, "PokemonGoodRod3", fileName);

        //this.SuperRod[0] = li.GetProperties2(map_id, "PokemonSuperRod1", fileName);
        //this.SuperRod[1] = li.GetProperties2(map_id, "PokemonSuperRod2", fileName);
        //this.SuperRod[2] = li.GetProperties2(map_id, "PokemonSuperRod3", fileName);
        //this.SuperRod[3] = li.GetProperties2(map_id, "PokemonSuperRod4", fileName);
        //this.SuperRod[4] = li.GetProperties2(map_id, "PokemonSuperRod5", fileName);

        //this.HeadbuttLow[0] = li.GetProperties2(map_id, "PokemonHeadbuttLow1", fileName);
        //this.HeadbuttLow[1] = li.GetProperties2(map_id, "PokemonHeadbuttLow2", fileName);
        //this.HeadbuttLow[2] = li.GetProperties2(map_id, "PokemonHeadbuttLow3", fileName);
        //this.HeadbuttLow[3] = li.GetProperties2(map_id, "PokemonHeadbuttLow4", fileName);
        //this.HeadbuttLow[4] = li.GetProperties2(map_id, "PokemonHeadbuttLow5", fileName);
        //this.HeadbuttLow[5] = li.GetProperties2(map_id, "PokemonHeadbuttLow6", fileName);
        //this.HeadbuttLow[6] = li.GetProperties2(map_id, "PokemonHeadbuttLow7", fileName);
        //this.HeadbuttLow[7] = li.GetProperties2(map_id, "PokemonHeadbuttLow8", fileName);

        //this.HeadbuttHigh[0] = li.GetProperties2(map_id, "PokemonHeadbuttHigh1", fileName);
        //this.HeadbuttHigh[1] = li.GetProperties2(map_id, "PokemonHeadbuttHigh2", fileName);
        //this.HeadbuttHigh[2] = li.GetProperties2(map_id, "PokemonHeadbuttHigh3", fileName);
        //this.HeadbuttHigh[3] = li.GetProperties2(map_id, "PokemonHeadbuttHigh4", fileName);
        //this.HeadbuttHigh[4] = li.GetProperties2(map_id, "PokemonHeadbuttHigh5", fileName);
        //this.HeadbuttHigh[5] = li.GetProperties2(map_id, "PokemonHeadbuttHigh6", fileName);
        //this.HeadbuttHigh[6] = li.GetProperties2(map_id, "PokemonHeadbuttHigh7", fileName);
        //this.HeadbuttHigh[7] = li.GetProperties2(map_id, "PokemonHeadbuttHigh8", fileName);
        //Debug.Log(Water[4]);

    }

    // Update is called once per frame
    void Update () {


        if (Input.GetKeyDown(KeyCode.Escape))
        {
              SaveLoad.Save();
          
            Debug.Log("SAVED " + Application.persistentDataPath);
        }

        if (Input.GetKeyDown(KeyCode.L))
        {
           
            SaveLoad.Load();
            Debug.Log("LOADED");
        }
      
    }



        //var mec = gameObject.GetComponentInChildren<BoxCollider>();
 
        //if (mec.bounds.Contains(GameObject.Find("Player").transform.position))
        //{
        //    Debug.Log(mec.gameObject.name);
        //    Debug.Log("LOOOOOOOOOOL");
        //}
	
      public string[] getWildPokemon(string area)
    {

        switch (area)
        {
            case "Water":
                Debug.Log("lol");
                return water[UnityEngine.Random.Range(0,4)].Split(',');
            case "Land":
                Debug.Log("lol");
                return land[UnityEngine.Random.Range(0, 11)].Split(',');
            case "LandMorning":
                Debug.Log("lol");
                return landMorning[UnityEngine.Random.Range(0, 11)].Split(',');
            case "LandDay":
                Debug.Log("lol");
                return landDay[UnityEngine.Random.Range(0, 11)].Split(',');
            case "LandNight":
                Debug.Log("lol");
                return landNight[UnityEngine.Random.Range(0, 11)].Split(',');
            case "Cave":
                Debug.Log("lol");
                return cave[UnityEngine.Random.Range(0, 11)].Split(',');
            case "BugContest":
                Debug.Log("lol");
                return bugContest[UnityEngine.Random.Range(0, 3)].Split(',');
            case "RockSmash":
                Debug.Log("lol");
                return rockSmash[UnityEngine.Random.Range(0, 4)].Split(',');
            case "OldRod":
                Debug.Log("lol");
                return oldRod[UnityEngine.Random.Range(0, 1)].Split(',');
            case "GoodRod":
                Debug.Log("lol");
                return goodRod[UnityEngine.Random.Range(0, 2)].Split(',');
            case "SuperRod":
                Debug.Log("lol");
                return superRod[UnityEngine.Random.Range(0, 4)].Split(',');
            case "HeadbuttLow":
                Debug.Log("lol");
                return headbuttLow[UnityEngine.Random.Range(0, 7)].Split(',');
            case "HeadbuttHigh":
                Debug.Log("lol");
                return headbuttHigh[UnityEngine.Random.Range(0, 7)].Split(',');


        }
        return null;
    }
  
}
