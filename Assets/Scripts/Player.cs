using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class Player : MonoBehaviour {
    Datos li = new Datos();
    private Battle_System batalla;
    //Partida partida = new Partida();
    string nombre;
    string sexo;
    int trainer_id;
    private int speed = 1;
    Vector3 pos;
    Transform tr;
    bool on = false;
    Animation animation;
    int limit_wild;
    int press=0;
    Map mapa;
    Rigidbody2D rbody;
    Animator anim;
    private bool canMove = true;
    Vector2 movement_vector;
    int actual_map_id;
    List<Pokemon> allpokemons;
    private List<Pokemon> pokemon;
    private List<Movimiento> movimiento;
    private List<Tipo> tipo;
    Datos ti = new Datos();
    //public Player(string Nombre, string Sexo, int Trainer_id)
    //{
    //    this.nombre = Nombre;
    //    this.sexo = Sexo;
    //    this.trainer_id = Trainer_id;
    //}
    #region
    public string Nombre
    {
        get
        {
            return Nombre1;
        }

        set
        {
            Nombre1 = value;
        }
    }

    public string Sexo
    {
        get
        {
            return Sexo1;
        }

        set
        {
            Sexo1 = value;
        }
    }

    public int Trainer_id
    {
        get
        {
            return Trainer_id1;
        }

        set
        {
            Trainer_id1 = value;
        }
    }

    public string Nombre1
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

    public string Sexo1
    {
        get
        {
            return sexo;
        }

        set
        {
            sexo = value;
        }
    }

    public int Trainer_id1
    {
        get
        {
            return trainer_id;
        }

        set
        {
            trainer_id = value;
        }
    }

    public int Speed
    {
        get
        {
            return speed;
        }

        set
        {
            speed = value;
        }
    }

    public Vector3 Pos
    {
        get
        {
            return pos;
        }

        set
        {
            pos = value;
        }
    }

    public Transform Tr
    {
        get
        {
            return tr;
        }

        set
        {
            tr = value;
        }
    }

    public bool On
    {
        get
        {
            return on;
        }

        set
        {
            on = value;
        }
    }

    public Animation Animation
    {
        get
        {
            return animation;
        }

        set
        {
            animation = value;
        }
    }

    public int Limit_wild
    {
        get
        {
            return limit_wild;
        }

        set
        {
            limit_wild = value;
        }
    }

    public int Press
    {
        get
        {
            return press;
        }

        set
        {
            press = value;
        }
    }

    public Map Mapa
    {
        get
        {
            return mapa;
        }

        set
        {
            mapa = value;
        }
    }

    public Rigidbody2D Rbody
    {
        get
        {
            return rbody;
        }

        set
        {
            rbody = value;
        }
    }

    public Animator Anim
    {
        get
        {
            return anim;
        }

        set
        {
            anim = value;
        }
    }

    public bool CanMove
    {
        get
        {
            return canMove;
        }

        set
        {
            canMove = value;
        }
    }

    public Vector2 Movement_vector
    {
        get
        {
            return movement_vector;
        }

        set
        {
            movement_vector = value;
        }
    }

    public int Actual_map_id
    {
        get
        {
            return actual_map_id;
        }

        set
        {
            actual_map_id = value;
        }
    }

    public List<Pokemon> Allpokemons
    {
        get
        {
            return allpokemons;
        }

        set
        {
            allpokemons = value;
        }
    }

    public List<Pokemon> Pokemon
    {
        get
        {
            return pokemon;
        }

        set
        {
            pokemon = value;
        }
    }

    public List<Movimiento> Movimiento
    {
        get
        {
            return movimiento;
        }

        set
        {
            movimiento = value;
        }
    }

    public List<Tipo> Tipo
    {
        get
        {
            return tipo;
        }

        set
        {
            tipo = value;
        }
    }
    #endregion

    // Use this for initialization
    void Start () {
        batalla = GameObject.Find("Batalla").GetComponent<Battle_System>();
       //SaveLoad.Load();
       // li.loadPokemons();
        Pos = transform.position;
        Tr = transform;
        Limit_wild = UnityEngine.Random.Range(3, 5);
        Partida.pasos_wild = 1;
       // Tipo = ti.loadTipos(18);
        Rbody = GetComponent<Rigidbody2D>();
        Anim = GetComponent<Animator>();
       // Allpokemons = ti.loadPokemons();
        
    }
    

    // Update is called once per frame
    void FixedUpdate()
    {
        string area = DetectaArea();



        //    Animation animation = GameObject.Find("Walk_Up")//.GetComponent<Animation>();


        if (!CanMove)
        {
            Debug.Log("No es pot moure");
            return;
        }

        if (Input.GetKey(KeyCode.D) && Tr.position == Pos)
            {
            On = true;
            Press++;
            if (Press == 1)
            {
                Anim.SetBool("iswalking_short", true);
                Anim.SetFloat("input_x", 1);
                Anim.SetFloat("input_y", 0);
                Pos += Vector3.right * (32 * 0.01f);
            }
            else
            {
                Anim.SetBool("iswalking_short", false);
                Anim.SetBool("iswalking", true);
                Anim.SetFloat("input_x", 1);
                Anim.SetFloat("input_y", 0);
                Pos += Vector3.right * (32 * 0.01f);
            }

            }
            else if (Input.GetKey(KeyCode.A) && Tr.position == Pos)
            {

            On = true;
            Press++;
            if (Press == 1)
            {
                Anim.SetBool("iswalking_short", true);
                Anim.SetFloat("input_x", -1);
                Anim.SetFloat("input_y", 0);
                Pos += Vector3.left * (32 * 0.01f);
            }
            else
            {
                Anim.SetBool("iswalking_short", false);
                Anim.SetBool("iswalking", true);
                Anim.SetFloat("input_x", -1);
                Anim.SetFloat("input_y", 0);
                Pos += Vector3.left * (32 * 0.01f);
            }

            }
            else if (Input.GetKey(KeyCode.W) && Tr.position == Pos)
            {
            On = true;
            Press++;
                if (Press == 1)
                {
                    Anim.SetBool("iswalking_short", true);
                    Anim.SetFloat("input_x", 0);
                    Anim.SetFloat("input_y", 1);
                    Pos += Vector3.up * (32 * 0.01f);
                }
                else
                {
                Anim.SetBool("iswalking_short", false);
                Anim.SetBool("iswalking", true);
                    Anim.SetFloat("input_x", 0);
                    Anim.SetFloat("input_y", 1);
                    Pos += Vector3.up * (32 * 0.01f);
                }



            }
            else if (Input.GetKey(KeyCode.S) && Tr.position == Pos)
            {
            On = true;
            Press++;
            if (Press == 1)
            {
                Anim.SetBool("iswalking_short", true);
                Anim.SetFloat("input_x", 0);
                Anim.SetFloat("input_y", -1);
                Pos += Vector3.down * (32 * 0.01f);
            }
            else
            {
                Anim.SetBool("iswalking_short", false);
                Anim.SetBool("iswalking", true);
                Anim.SetFloat("input_x", 0);
                Anim.SetFloat("input_y", -1);
                Pos += Vector3.down * (32 * 0.01f);
            }
            }
            else if (!Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.W))
            {
            On = false;
            Anim.SetBool("iswalking", false);
            Anim.SetBool("iswalking_short", false);
            Press = 0;

        }
        if (Input.GetKeyDown(KeyCode.M))
        {
            //FindObjectOfType<TextBoxManager>().TextBox_Write("TOT EL CAMP ES UN CLAM SOM LA GENT BLAUGRANA TAN SE VAL D'ON VENIM SI DEL SUD O DEL NORD ARA ESTEM D'ACORD UNA BANDERA ENS AGERMANA BLAUGRANA EL VENT UN CRIT VALENT TENIM UN NOM QUE EL SAP TOTHOM BARÇA BARÇA BARÇA");
            FindObjectOfType<TextBoxManager>().TextBox_Write("123456789123456789(1)123456789123456789(2)123456789123456789(3)123456789123456789(4)123456789123456789(5)123456789123456789(6)123456789123456789(7)123456789123456789(8)123456789123456789(9)123456789123456789(10)123456789123456789(11)123456789123456789(12)123456789123456789(13)123456789123456789(14)123456789123456789(15)123456789123456789(16)123456789123456789(17)");
        }

            transform.position = Vector3.MoveTowards(transform.position, Pos, Time.deltaTime * Speed);
        if (On)
        {
            Debug.Log(On + " " + area);
            area = DetectaArea();
            if (area != "Untagged" && area != "")
            {
                Debug.Log(area + "  ENTRA");
                Partida.pasos_wild++;
                Debug.Log(Partida.pasos_wild + " = " + limit_wild);
                if (Partida.pasos_wild == limit_wild)
                {
                    Debug.Log("GET WILD");
                    string[] pkmns = mapa.getWildPokemon("Water");
                    int pkmn_id = Convert.ToInt32(li.GetLabelNumber("InternalName", pkmns[0], "pokemon.txt"));
                   // int pkmn_id = UnityEngine.Random.Range(1, 14);
                    Debug.Log(Partida.actual.pokedex[pkmn_id].nombre);
                    batalla.StartBattle(Partida.actual.pokedex[18], Partida.actual.pokedex[pkmn_id]);
                     Partida.pasos_wild = 0;
                    limit_wild = UnityEngine.Random.Range(3, 5);
                }

            }
        }
        On = false;

        //movement_vector = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        ////}
        //////else
        //////{
        //////    movement_vector = Vector2.zero;
        //////}


        //if (movement_vector != Vector2.zero)
        //{
        //    anim.SetBool("iswalking", true);
        //    anim.SetFloat("input_x", movement_vector.x);
        //    anim.SetFloat("input_y", movement_vector.y);
        //    if (movement_vector.x != 0 || movement_vector.y != 0)
        //    {
        //        Partida.pasos_wild++;
        //        Debug.Log("Pasos: " + Partida.pasos_wild);
        //    }
        //    Debug.Log("x: " + movement_vector.x);
        //    Debug.Log("y: " + movement_vector.y);
        //}
        //else
        //{
        //    anim.SetBool("iswalking", false);

        //}
        ////   Debug.Log("canMove");

        //rbody.MovePosition(rbody.position + movement_vector * Time.deltaTime);
    }
    
    private IEnumerator MyCoroutine()
    {
        yield return new WaitForSeconds(1.0f);
    }

        string DetectaArea()
    {
        RaycastHit2D mec = Physics2D.Raycast(transform.position, Vector2.zero);

        if (mec.collider != null)
        {
            Actual_map_id = mec.transform.parent.gameObject.transform.parent.gameObject.GetComponent<Map>().map_id;
            Mapa = mec.transform.parent.gameObject.transform.parent.gameObject.GetComponent<Map>();
            //Debug.Log("Detecta: " + mec.collider.gameObject.name);
            //if (mec.collider.gameObject.tag == "Casa")
            //{
            //    Debug.Log("CASA");
            //}

            //if (mec.collider.gameObject.tag == "Terra")
            //{
            //    Debug.Log("zero: " + mec.collider.gameObject.tag);


            //}
            if (mec.collider.bounds.Contains(GameObject.Find("Player").transform.position))
            {
                
                //Debug.Log("Contains: " + mec.transform.parent.tag);
                // return mec.collider.gameObject.tag;
                return mec.transform.parent.tag;
            }
           
        }
       
            return "";
        
    }

  
    
} 
