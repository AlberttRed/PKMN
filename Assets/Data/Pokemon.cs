using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;


public class Pokemon {

 //   TextImporter ti = new TextImporter();

    public string nombre; // FET
    public string internal_name;// FET
    //public Tipo tipo1, tipo2;// FET
    public int tipo1, tipo2;// FET
    public List<int> experiencia_nivells = new List<int>();// FET
    public int hp_total, ataque, defensa, ataqueS, defensaS, velocidad;// FET
    int hp_actual;// FET
    int precision, evasio;
    public int ratio_sexo;// FET
    public int generacion;// FET
    int id_evolucion_anterior;// FET
    public string ratio_nivel; //Puja de nivell rapid o lent etc. Fast, Fast/Medium, Medium, Medium/Slow, Slow, Erratic, Fluctuating 
    public int id_exp_base;// FET /id del tipus de creixement pokemon per saber quanta experiencia neceesita per pujar de nivell. Serveix per acrregar la List experiencia_nivells
    public int EVHP, EVAtaque, EVDefensa, EVvelocidad, EVAtaqueS, EVDefensaS; // FET//La quantitat d EVs que guanya el pokemon al derrotar a un altre(valor entre 1 i 3) Mirar més a wiki
    public int ratio_captura; // FET// Dificultat de captura. 0 = impossible, només amb Master Ball
    public int felicidad_base;// FET //La felicitat que té el pokemon quan l'acabes d atrapar. Normalment es 70
                              // public List<Movimiento> movimientos = new List<Movimiento>(); //1 Moviments que apren el pokemon Ex moviments(22) = moviment que apren al nivell 22
    public List<int> movimientos = new List<int>();
    public List<int> niveles_movimientos = new List<int>();
    /// public List<Movimiento> MTMOs = new List<Movimiento>(); // 4
     public List<int> MTMOs = new List<int>(); // 4
    public string grupo_huevo1, grupo_huevo2;
    public int pasos_huevo; //Pasos que tarda el huevo del pokemon en abrirse 
    public decimal peso, altura;// FET
    public string color;// FET
    public string especie; // FET // Ex bulbasaur: semilla
    public string desc_pokedex; // FET
    public string habilidad1, habilidad2, habilidad_oculta; // Ex bulbasaur: espesura, hab oculta: clorofila FET
  //  public List<Movimiento> movimientos_huevo = new List<Movimiento>(); //2
  //  public List<Movimiento> movimientos_tutor = new List<Movimiento>(); // 3
    public List<int> movimientos_huevo = new List<int>(); //2
    public List<int> movimientos_tutor = new List<int>(); // 
    public string habitat;// FET //localizaciones donde encontrar el pokemon, Ex: Cueva, bosque etc.

    // public Objeto objeto1, objeto2, objeto3; //quin tipus d'objecte sol tenir, quin pot set que tingui i quin es raro que tingui
    public int objeto1, objeto2, objeto3;
    public int rareza_obj1, rareza_obj2, rareza_obj3; //SELECT TAULA pokemon_items
    public int BattlerPlayerY, BattlerEnemyY; //posicio de l sprite en el combat, mirar wiki
    public int BattlerAltitude; //igual q abans, pero quan l sprite es el del rival;
    public int tipo_evolucion; //tipus  devolucio, per nivell, felicitat, objecte, etc.. // FET
    public bool tiene_formas;// FET
    public string[] nom_formas; //el nom de les formes del pokemon, si en té.
    string nickname, huella;
    AudioClip grito;
    public int pokedex_num;//FET
                           // public Objeto objeto_criar; //FET//Objecte que ha de tenir el pokemon al criar per tenir el pokemon bebé especial(ex. Chansey, Happiny necessitta incenso)
    public int objeto_criar;
    List<Movimiento> movimientos_aprendidos = new List<Movimiento>();
    int  sexo, nivel, experiencia;
    public int id;//FET
    Sprite imagen, imagen_back, imagen_front;
    //public Objeto evolucion_con_objeto;// FET
    public int evolucion_con_objeto;// FET
    public int evolucion_nivel_min;// FET
    public int evolucion_por_sexo;// FET
    public int evolucion_por_localizacion;// FET
    //public Objeto evolucion_objeto_equipado;// FET
    public int evolucion_objeto_equipado;// FET
    // int evolucion_objeto_equipado2;
    public string evolucion_dia;// FET
   // public Movimiento evolucion_movimiento;// FET
    public int evolucion_movimiento;// FET
    public int evolucion_tipo_movimiento;// FET
   // public Tipo evolucion_tipo_movimiento;// FET
    public int evolucion_felicidad_min;// FET
    public int evolucion_belleza_min;// FET
    public int evolucion_stats;// FET
    public int id_evolucion_pokemon_equipo;// FET
    public int evolucion_tipo_equipo;// FET
    //public Tipo evolucion_tipo_equipo;// FET
    public bool evolucion_lluvia;// FET
    public int id_evolucio_anterior;// FET

    // #region Getters i Setters

    //public string Nombre
    //{
    //    get
    //    {
    //        return nombre;
    //    }

    //    set
    //    {
    //        nombre = value;
    //    }
    //}

    //public string Internal_name
    //{
    //    get
    //    {
    //        return internal_name;
    //    }

    //    set
    //    {
    //        internal_name = value;
    //    }
    //}

    //public string Tipo1
    //{
    //    get
    //    {
    //        return tipo1;
    //    }

    //    set
    //    {
    //        tipo1 = value;
    //    }
    //}

    //public string Tipo2
    //{
    //    get
    //    {
    //        return tipo2;
    //    }

    //    set
    //    {
    //        tipo2 = value;
    //    }
    //}

    //public int Hp_total
    //{
    //    get
    //    {
    //        return hp_total;
    //    }

    //    set
    //    {
    //        hp_total = value;
    //    }
    //}

    //public int Hp_actual
    //{
    //    get
    //    {
    //        return hp_actual;
    //    }

    //    set
    //    {
    //        hp_actual = value;
    //    }
    //}

    //public int Ataque
    //{
    //    get
    //    {
    //        return ataque;
    //    }

    //    set
    //    {
    //        ataque = value;
    //    }
    //}

    //public int Defensa
    //{
    //    get
    //    {
    //        return defensa;
    //    }

    //    set
    //    {
    //        defensa = value;
    //    }
    //}

    //public int AtaqueS
    //{
    //    get
    //    {
    //        return ataqueS;
    //    }

    //    set
    //    {
    //        ataqueS = value;
    //    }
    //}

    //public int DefensaS
    //{
    //    get
    //    {
    //        return defensaS;
    //    }

    //    set
    //    {
    //        defensaS = value;
    //    }
    //}

    //public int Velocidad
    //{
    //    get
    //    {
    //        return velocidad;
    //    }

    //    set
    //    {
    //        velocidad = value;
    //    }
    //}

    //public string Ratio_sexo
    //{
    //    get
    //    {
    //        return ratio_sexo;
    //    }

    //    set
    //    {
    //        ratio_sexo = value;
    //    }
    //}

    //public string Ratio_nivel
    //{
    //    get
    //    {
    //        return ratio_nivel;
    //    }

    //    set
    //    {
    //        ratio_nivel = value;
    //    }
    //}

    //public string Exp_base
    //{
    //    get
    //    {
    //        return exp_base;
    //    }

    //    set
    //    {
    //        exp_base = value;
    //    }
    //}

    //public int EVHP1
    //{
    //    get
    //    {
    //        return EVHP;
    //    }

    //    set
    //    {
    //        EVHP = value;
    //    }
    //}

    //public int EVAtaque1
    //{
    //    get
    //    {
    //        return EVAtaque;
    //    }

    //    set
    //    {
    //        EVAtaque = value;
    //    }
    //}

    //public int EVDefensa1
    //{
    //    get
    //    {
    //        return EVDefensa;
    //    }

    //    set
    //    {
    //        EVDefensa = value;
    //    }
    //}

    //public int EVvelocidad1
    //{
    //    get
    //    {
    //        return EVvelocidad;
    //    }

    //    set
    //    {
    //        EVvelocidad = value;
    //    }
    //}

    //public int EVAtqueS1
    //{
    //    get
    //    {
    //        return EVAtqueS;
    //    }

    //    set
    //    {
    //        EVAtqueS = value;
    //    }
    //}

    //public int EVDefensaS1
    //{
    //    get
    //    {
    //        return EVDefensaS;
    //    }

    //    set
    //    {
    //        EVDefensaS = value;
    //    }
    //}

    //public int Ratio_captura
    //{
    //    get
    //    {
    //        return ratio_captura;
    //    }

    //    set
    //    {
    //        ratio_captura = value;
    //    }
    //}

    //public int Felicidad_base
    //{
    //    get
    //    {
    //        return felicidad_base;
    //    }

    //    set
    //    {
    //        felicidad_base = value;
    //    }
    //}

    //public string[] Moviments
    //{
    //    get
    //    {
    //        return moviments;
    //    }

    //    set
    //    {
    //        moviments = value;
    //    }
    //}

    //public string Gurpo_huevo1
    //{
    //    get
    //    {
    //        return gurpo_huevo1;
    //    }

    //    set
    //    {
    //        gurpo_huevo1 = value;
    //    }
    //}

    //public string Grupo_huevo2
    //{
    //    get
    //    {
    //        return grupo_huevo2;
    //    }

    //    set
    //    {
    //        grupo_huevo2 = value;
    //    }
    //}

    //public int Pasos_huevo
    //{
    //    get
    //    {
    //        return pasos_huevo;
    //    }

    //    set
    //    {
    //        pasos_huevo = value;
    //    }
    //}

    //public decimal Peso
    //{
    //    get
    //    {
    //        return peso;
    //    }

    //    set
    //    {
    //        peso = value;
    //    }
    //}

    //public decimal Altura
    //{
    //    get
    //    {
    //        return altura;
    //    }

    //    set
    //    {
    //        altura = value;
    //    }
    //}

    //public string Color
    //{
    //    get
    //    {
    //        return color;
    //    }

    //    set
    //    {
    //        color = value;
    //    }
    //}

    //public string Especie
    //{
    //    get
    //    {
    //        return especie;
    //    }

    //    set
    //    {
    //        especie = value;
    //    }
    //}

    //public string Habilidad
    //{
    //    get
    //    {
    //        return habilidad;
    //    }

    //    set
    //    {
    //        habilidad = value;
    //    }
    //}

    //public string Habilidad_oculta
    //{
    //    get
    //    {
    //        return habilidad_oculta;
    //    }

    //    set
    //    {
    //        habilidad_oculta = value;
    //    }
    //}

    //public string[] Movimientos_huevo
    //{
    //    get
    //    {
    //        return movimientos_huevo;
    //    }

    //    set
    //    {
    //        movimientos_huevo = value;
    //    }
    //}

    //public string Habitat
    //{
    //    get
    //    {
    //        return habitat;
    //    }

    //    set
    //    {
    //        habitat = value;
    //    }
    //}

    //public int Num_dex_nacional1
    //{
    //    get
    //    {
    //        return num_dex_nacional1;
    //    }

    //    set
    //    {
    //        num_dex_nacional1 = value;
    //    }
    //}

    //public int Num_dex_nacional2
    //{
    //    get
    //    {
    //        return num_dex_nacional2;
    //    }

    //    set
    //    {
    //        num_dex_nacional2 = value;
    //    }
    //}

    //public int Num_dex_nacional3
    //{
    //    get
    //    {
    //        return num_dex_nacional3;
    //    }

    //    set
    //    {
    //        num_dex_nacional3 = value;
    //    }
    //}

    //public int Num_dex_nacional4
    //{
    //    get
    //    {
    //        return num_dex_nacional4;
    //    }

    //    set
    //    {
    //        num_dex_nacional4 = value;
    //    }
    //}

    //public string Objeto_habitual
    //{
    //    get
    //    {
    //        return objeto_habitual;
    //    }

    //    set
    //    {
    //        objeto_habitual = value;
    //    }
    //}

    //public string Objeto_pocohab
    //{
    //    get
    //    {
    //        return objeto_pocohab;
    //    }

    //    set
    //    {
    //        objeto_pocohab = value;
    //    }
    //}

    //public string Objeto_raro
    //{
    //    get
    //    {
    //        return objeto_raro;
    //    }

    //    set
    //    {
    //        objeto_raro = value;
    //    }
    //}

    //public string[] Tipo_evolucion
    //{
    //    get
    //    {
    //        return tipo_evolucion;
    //    }

    //    set
    //    {
    //        tipo_evolucion = value;
    //    }
    //}

    //public string[] Nom_formas
    //{
    //    get
    //    {
    //        return nom_formas;
    //    }

    //    set
    //    {
    //        nom_formas = value;
    //    }
    //}

    //public string Nickname
    //{
    //    get
    //    {
    //        return nickname;
    //    }

    //    set
    //    {
    //        nickname = value;
    //    }
    //}

    //public string Huella
    //{
    //    get
    //    {
    //        return huella;
    //    }

    //    set
    //    {
    //        huella = value;
    //    }
    //}

    //public AudioClip Grito
    //{
    //    get
    //    {
    //        return grito;
    //    }

    //    set
    //    {
    //        grito = value;
    //    }
    //}

    //public bool Objeto
    //{
    //    get
    //    {
    //        return objeto;
    //    }

    //    set
    //    {
    //        objeto = value;
    //    }
    //}

    //public string[] Movimientos_aprendidos
    //{
    //    get
    //    {
    //        return movimientos_aprendidos;
    //    }

    //    set
    //    {
    //        movimientos_aprendidos = value;
    //    }
    //}

    //public int Num_pokedex
    //{
    //    get
    //    {
    //        return num_pokedex;
    //    }

    //    set
    //    {
    //        num_pokedex = value;
    //    }
    //}

    //public int Id
    //{
    //    get
    //    {
    //        return id;
    //    }

    //    set
    //    {
    //        id = value;
    //    }
    //}

    //public int Sexo
    //{
    //    get
    //    {
    //        return sexo;
    //    }

    //    set
    //    {
    //        sexo = value;
    //    }
    //}

    //public int Nivel
    //{
    //    get
    //    {
    //        return nivel;
    //    }

    //    set
    //    {
    //        nivel = value;
    //    }
    //}

    //public int Experiencia
    //{
    //    get
    //    {
    //        return experiencia;
    //    }

    //    set
    //    {
    //        experiencia = value;
    //    }
    //}

    //public Sprite Imagen
    //{
    //    get
    //    {
    //        return imagen;
    //    }

    //    set
    //    {
    //        imagen = value;
    //    }
    //}

    //public Sprite Imagen_back
    //{
    //    get
    //    {
    //        return imagen_back;
    //    }

    //    set
    //    {
    //        imagen_back = value;
    //    }
    //}

    //public Sprite Imagen_front
    //{
    //    get
    //    {
    //        return imagen_front;
    //    }

    //    set
    //    {
    //        imagen_front = value;
    //    }
    //}

    //public ArrayList MTs1
    //{
    //    get
    //    {
    //        return MTs;
    //    }

    //    set
    //    {
    //        MTs = value;
    //    }
    //}

    //public string Desc_pokedex
    //{
    //    get
    //    {
    //        return desc_pokedex;
    //    }

    //    set
    //    {
    //        desc_pokedex = value;
    //    }
    //}

    //public int BattlerPlayerY1
    //{
    //    get
    //    {
    //        return BattlerPlayerY;
    //    }

    //    set
    //    {
    //        BattlerPlayerY = value;
    //    }
    //}

    //public int BattlerEnemyY1
    //{
    //    get
    //    {
    //        return BattlerEnemyY;
    //    }

    //    set
    //    {
    //        BattlerEnemyY = value;
    //    }
    //}

    //public int BattlerAltitude1
    //{
    //    get
    //    {
    //        return BattlerAltitude;
    //    }

    //    set
    //    {
    //        BattlerAltitude = value;
    //    }
    //}
    //#endregion
    public Pokemon()
    {
      
        //string fileName = "pokemon.txt";
  
        //this.Nombre = ti.GetProperties2(i, "Name", fileName);
        //Debug.Log(i + " " + this.Nombre);
        //this.Internal_name = ti.GetProperties2(i, "InternalName", fileName);
        //this.Tipo1 = ti.GetProperties2(i, "Type1", fileName);
        //this.Tipo2 = ti.GetProperties2(i, "Type2", fileName);
        //this.SetStats(ti.GetProperties2(i, "BaseStats", fileName));
        ////Debug.Log("HP: " + pokemon.Hp_total);
        ////Debug.Log("AT: " + pokemon.Ataque);
        ////Debug.Log("DEF: " + pokemon.Defensa);
        ////Debug.Log("VEL: " + pokemon.Velocidad);
        ////Debug.Log("ATS: " + pokemon.AtaqueS);
        ////Debug.Log("DEFS: " + pokemon.DefensaS);
        //this.Ratio_sexo = ti.GetProperties2(i, "GenderRate", fileName);
        //this.Ratio_nivel = ti.GetProperties2(i, "GrowthRate", fileName);
        //this.Exp_base = ti.GetProperties2(i, "BaseEXP", fileName);
        //this.SetEVStats(ti.GetProperties2(i, "EffortPoints", fileName));
        //this.Ratio_captura = Convert.ToInt32(ti.GetProperties2(i, "Rareness", fileName));
        //this.Felicidad_base = Convert.ToInt32(ti.GetProperties2(i, "Happiness", fileName));
        //this.SetMoves(ti.GetProperties2(i, "Moves", fileName));
        //this.Pasos_huevo = Convert.ToInt32(ti.GetProperties2(i, "StepsToHatch", fileName));
        //this.Altura = Convert.ToDecimal(ti.GetProperties2(i, "Height", fileName));
        //this.Peso = Convert.ToDecimal(ti.GetProperties2(i, "Weight", fileName));
        //this.Color = ti.GetProperties2(i, "Color", fileName);
        //this.Especie = ti.GetProperties2(i, "Kind", fileName);
        //this.Desc_pokedex = ti.GetProperties2(i, "Pokedex", fileName);
        //this.Habilidad = ti.GetProperties2(i, "Abilities", fileName);
        //this.Habilidad_oculta = ti.GetProperties2(i, "HiddenAbility", fileName);
        //this.SetEGGMoves(ti.GetProperties2(i, "EggMoves", fileName));
        //this.Habitat = ti.GetProperties2(i, "Habitat", fileName);
        //this.SetPokedexNums(ti.GetProperties2(i, "RegionalNumbers", fileName));
        //this.Objeto_habitual = ti.GetProperties2(i, "WildItemCommon", fileName);
        //this.Objeto_pocohab = ti.GetProperties2(i, "WildItemUncommon", fileName);
        //this.Objeto_raro = ti.GetProperties2(i, "WildItemRare", fileName);

        //this.BattlerPlayerY1 = Convert.ToInt32(ti.GetProperties2(i, "BattlerPlayerY", fileName));
        //this.BattlerEnemyY1 = Convert.ToInt32(ti.GetProperties2(i, "BattlerEnemyY", fileName));
        //this.BattlerAltitude1 = Convert.ToInt32(ti.GetProperties2(i, "BattlerAltitude", fileName));
        //this.SetEvolutionForm(ti.GetProperties2(i, "Evolutions", fileName));
        //this.SetFormsPKMN(ti.GetProperties2(i, "FormNames", fileName));

    }
    //public void SetStats(string stats)
    //{
    //    string[] aStats = stats.Split(',');
    //    this.Hp_total = Convert.ToInt32(aStats[0]);
    //    this.Ataque = Convert.ToInt32(aStats[1]);
    //    this.Defensa = Convert.ToInt32(aStats[2]);
    //    this.Velocidad = Convert.ToInt32(aStats[3]);
    //    this.AtaqueS = Convert.ToInt32(aStats[4]);
    //    this.DefensaS = Convert.ToInt32(aStats[5]);
    //}

    //public void SetEVStats(string stats)
    //{
    //    string[] EVStats = stats.Split(',');
    //    this.EVHP = Convert.ToInt32(EVStats[0]);
    //    this.EVAtaque = Convert.ToInt32(EVStats[1]);
    //    this.EVDefensa = Convert.ToInt32(EVStats[2]);
    //    this.EVvelocidad = Convert.ToInt32(EVStats[3]);
    //    this.EVAtaque = Convert.ToInt32(EVStats[4]);
    //    this.EVDefensa = Convert.ToInt32(EVStats[5]);
    //}

    //public void SetMoves(string moves)
    //{
    //    string[] m = moves.Split(',');
    //    for(int i = 0; i < m.Length; i++)
    //    {
    //      //  Debug.Log("Fora: " + i);
    //        if (i == 0 || (i % 2 == 0))
    //        {
    //      //      Debug.Log("Dintre: " + i);
    //            this.moviments[Convert.ToInt32(m[i])] = m[i+1];
    //        }
    //    }      
    //}

    //public void SetEGGMoves(string moves)
    //{
       
    //    if (moves != "")
    //    {
    //        string[] m = moves.Split(',');
    //        movimientos_huevo = new string[m.Length];
    //        for (int i = 0; i < m.Length; i++)
    //        {
    //            this.movimientos_huevo[i] = (m[i]);
    //        }
    //    }
          
    //}
    //public void SetPokedexNums(string nums)
    //{
    //   // Debug.Log(nums);
    //    if (nums != "")
    //    {
    //        string[] n = nums.Split(',');
    //        if (n != null)
    //        {
    //            this.num_dex_nacional1 = Convert.ToInt32(n[0]);
    //            if (n.Length == 2)
    //            {
    //              //  Debug.Log("2");
    //                this.Num_dex_nacional2 = Convert.ToInt32(n[1]);
    //            }
    //            else if (n.Length == 3)
    //            {
    //               // Debug.Log("3");
    //                this.Num_dex_nacional2 = Convert.ToInt32(n[1]);
    //                this.num_dex_nacional3 = Convert.ToInt32(n[2]);
    //            }
    //            else if (n.Length == 4)
    //            {
    //                this.Num_dex_nacional2 = Convert.ToInt32(n[1]);
    //                this.num_dex_nacional3 = Convert.ToInt32(n[2]);
    //                this.num_dex_nacional4 = Convert.ToInt32(n[3]);
    //            }
    //        }
    //    }

    //}

    //public void SetEvolutionForm(string forms)
    //{
    //    if (forms != "")
    //    {
    //        string[] f = forms.Split(',');
    //        tipo_evolucion = new string[f.Length];
    //        for (int i = 0; i < f.Length; i++)
    //        {
    //            this.tipo_evolucion[i] = f[i];
    //        }
    //    }
    //}

    //public void SetFormsPKMN(string forms)
    //{
    //    if (forms != "")
    //    {
    //        string[] f = forms.Split(',');
    //        nom_formas = new string[f.Length];
    //        for (int i = 0; i < f.Length; i++)
    //        {
    //            this.nom_formas[i] = f[i];
    //        }
    //    }
    //}
}
