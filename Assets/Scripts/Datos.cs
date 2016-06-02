using UnityEngine;
using System.Collections;
using System.IO;
using System.Text;
using System;
using System.Collections.Generic;
using LitJson;
using Mono.Data.Sqlite;
using System.Data;

public class Datos {

    String[] naturalezas = { "Activa", "Huraña", "Afable ", "Agitada", "Mansa", "Alegre", "Miedosa","Alocada", "Modesta", "Amable", "Osada", "Audaz", "Pícara", "Cauta", "Plácida", "Dócil", "Rara", "Firme", "Serena", "Floja", "Seria", "Fuerte", "Tímida", "Grosera" };
    public TextAsset textFile;
    string fileName, line;
    string[] pokeInfo;
    public string[] textLines;
    public static List<CategoriaMovimiento> categorias;
    public static List<Movimiento> movimientos;
    public static List<Tipo> tipos;
    public static List<Objeto> objetos;
    public static List<Pokemon> pokemons;
    private SqliteConnection sql_con;
    private SqliteCommand sql_cmd;
    private SqliteDataAdapter DB;
    private DataSet DS = new DataSet();
    private DataTable DT = new DataTable();
    string conn;
    public Datos() { }
	// Use this for initialization
	void Start () {
	
        
        

    }
    private void SetConnection()
    {
        Debug.Log("LOL1");
        conn = "URI=file:" + Application.persistentDataPath + "/database.sqlite"; //Path to database.
       
        sql_con = new SqliteConnection
            (conn);
        Debug.Log("LOL2");
    }
    private void ExecuteQuery(string txtQuery)
    {
        Debug.Log("MOOOOOOOOOOOOOOC");
        SetConnection();
        sql_con.Open();
        sql_cmd = sql_con.CreateCommand();
        sql_cmd.CommandText = txtQuery;
        sql_cmd.ExecuteNonQuery();
        sql_con.Close();
    }

    private DataSet LoadData(DataSet ds, string comand)
    {
        SetConnection();
        sql_con.Open();
        sql_cmd = sql_con.CreateCommand();
        Debug.Log("LOL");
        DB = new SqliteDataAdapter(comand, sql_con);
        ds.Reset();
        DB.Fill(ds);
        sql_con.Close();
        return ds;
    }
    //public List<Pokemon> loadPokemon(int index_pkmn)
    //{
    //    string fileName = "pokemon.txt";
    //    List<Pokemon> Pokemons = new List<Pokemon>();

    //    for (int i = 1; i <= index_pkmn; i++)
    //    {
    //        //int i = index_pkmn;
    //        pokemon = new Pokemon();



    //        pokemon.Nombre = GetProperties2(i, "Name", fileName);
    //        Debug.Log(i + " " + pokemon.Nombre);
    //        //  Debug.Log("POKEKMOOOOOOOOOOOOOOOOOOOON");
    //        pokemon.Internal_name = GetProperties2(i, "InternalName", fileName);
    //        pokemon.Tipo1 = GetProperties2(i, "Type1", fileName);
    //        pokemon.Tipo2 = GetProperties2(i, "Type2", fileName);
    //        pokemon.SetStats(GetProperties2(i, "BaseStats", fileName));
    //        //Debug.Log("HP: " + pokemon.Hp_total);
    //        //Debug.Log("AT: " + pokemon.Ataque);
    //        //Debug.Log("DEF: " + pokemon.Defensa);
    //        //Debug.Log("VEL: " + pokemon.Velocidad);
    //        //Debug.Log("ATS: " + pokemon.AtaqueS);
    //        //Debug.Log("DEFS: " + pokemon.DefensaS);
    //        pokemon.Ratio_sexo = GetProperties2(i, "GenderRate", fileName);
    //        pokemon.Ratio_nivel = GetProperties2(i, "GrowthRate", fileName);
    //        pokemon.Exp_base = GetProperties2(i, "BaseEXP", fileName);
    //        pokemon.SetEVStats(GetProperties2(i, "EffortPoints", fileName));
    //        pokemon.Ratio_captura = Convert.ToInt32(GetProperties2(i, "Rareness", fileName));
    //        pokemon.Felicidad_base = Convert.ToInt32(GetProperties2(i, "Happiness", fileName));
    //        pokemon.SetMoves(GetProperties2(i, "Moves", fileName));
    //        pokemon.Pasos_huevo = Convert.ToInt32(GetProperties2(i, "StepsToHatch", fileName));
    //        pokemon.Altura = Convert.ToDecimal(GetProperties2(i, "Height", fileName));
    //        pokemon.Peso = Convert.ToDecimal(GetProperties2(i, "Weight", fileName));
    //        pokemon.Color = GetProperties2(i, "Color", fileName);
    //        pokemon.Especie = GetProperties2(i, "Kind", fileName);
    //        pokemon.Desc_pokedex = GetProperties2(i, "Pokedex", fileName);
    //        pokemon.Habilidad = GetProperties2(i, "Abilities", fileName);
    //        pokemon.Habilidad_oculta = GetProperties2(i, "HiddenAbility", fileName);
    //        pokemon.SetEGGMoves(GetProperties2(i, "EggMoves", fileName));
    //        pokemon.Habitat = GetProperties2(i, "Habitat", fileName);
    //        pokemon.SetPokedexNums(GetProperties2(i, "RegionalNumbers", fileName));
    //        pokemon.Objeto_habitual = GetProperties2(i, "WildItemCommon", fileName);
    //        pokemon.Objeto_pocohab = GetProperties2(i, "WildItemUncommon", fileName);
    //        pokemon.Objeto_raro = GetProperties2(i, "WildItemRare", fileName);

    //        pokemon.BattlerPlayerY1 = Convert.ToInt32(GetProperties2(i, "BattlerPlayerY", fileName));
    //        pokemon.BattlerEnemyY1 = Convert.ToInt32(GetProperties2(i, "BattlerEnemyY", fileName));
    //        pokemon.BattlerAltitude1 = Convert.ToInt32(GetProperties2(i, "BattlerAltitude", fileName));
    //        pokemon.SetEvolutionForm(GetProperties2(i, "Evolutions", fileName));
    //        pokemon.SetFormsPKMN(GetProperties2(i, "FormNames", fileName));
    //        Pokemons.Add(pokemon);

    //    }

    //    return Pokemons;

    //}
    public string GetProperties2(int num, string prop, string fileName) {
        Debug.Log("MOOOOOOOOOOOOOOC");
        StreamReader theReader = new StreamReader(Application.dataPath + "/Data/" + fileName, Encoding.Default);
        
        try
        {
            using (theReader)
        {
            do
            {
                line = theReader.ReadLine();
                   
                if (line != null && line.StartsWith("[" + num + "]"))
                {
                    line = theReader.ReadLine();
                        
                        do
                    {
                           // Debug.Log(prop + ": " + line + "; " + line.IndexOf(prop));
                            if (line.IndexOf(prop) != -1)
                            {
                                // Debug.Log("substring= : " + line.Substring(line.IndexOf("=") + 1, line.Length - (line.IndexOf("=") + 1)));
                                //Debug.Log(line.Substring(line.IndexOf("=") + 1, line.Length - (line.IndexOf("=") + 1)));
                               
                                return line.Substring(line.IndexOf("=") + 1, line.Length - (line.IndexOf("=") + 1));
                            }
                            else
                            {
                                line = theReader.ReadLine();
                            }
                                                                                
                     } while (!line.StartsWith("["));
                       
                    // Do whatever you need to do with the text line, it's a string now
                    // In this example, I split it into arguments based on comma
                    // deliniators, then send that array to DoStuff()
                                        
                }
            }
            while (line != null);
            // Done reading, close the reader and return true to broadcast success    
            theReader.Close();
            return "";
        }
    }
        catch (Exception e)
        {
            Console.WriteLine("{0}\n", e.Message);
            return null;
        }
        finally
        {
             theReader.Close();
        }
       
    }


    public int GetLabelNumber(string label, string nom, string fileName)
    {
        Debug.Log("MOOOOOOOOOOOOOOC");
        StreamReader theReader = new StreamReader(Application.dataPath + "/Data/" + fileName, Encoding.Default);
        int pkmn_id = 999;
        try
        {
            using (theReader)
            {
                do
                {
                    line = theReader.ReadLine();
                    if (line.StartsWith("[")){
                        pkmn_id = Convert.ToInt32(line.Substring(1, line.Length - 2)) - 1;
                    }
                    if (line != null && line.StartsWith(label+"="+nom))
                    {
                        Debug.Log(pkmn_id);
                        return pkmn_id;
                    }
                }
                while (line != null);
                // Done reading, close the reader and return true to broadcast success    
                theReader.Close();
                return 999;
            }
        }
        catch (Exception e)
        {
            Console.WriteLine("{0}\n", e.Message);
            return 999;
        }
        finally
        {
            theReader.Close();
        }

    }
    public string[] GetProperties1(string fileName)
    {
        StreamReader theReader = new StreamReader(Application.dataPath + "/Data/" + fileName, Encoding.Default);
        Debug.Log("MOOOOOOOOOOOOOOC");
        try
        {
            using (theReader)
            {
              
                textLines = theReader.ReadToEnd().Split('\n');
                return textLines;
            }
            
        }
        catch (Exception e)
        {
            Console.WriteLine("{0}\n", e.Message);
            return null;
        }
        finally
        {
            theReader.Close();
        }


        

    }


    public IEnumerator loadPKMNs()
    {
        Debug.Log("MOOOOOOOOOOOOOOC");
        DataSet dsPokemons = new DataSet();
     //   dsPokemons = LoadData(dsPokemons,"SELECT A.id, A.identifier 'Internal_name', B.name'Nombre', A.weight'peso', (SELECT evolution_trigger_id FROM pokemon_evolution where evolved_species_id = A.species_id)'tipo_evolucion', (SELECT trigger_item_id FROM pokemon_evolution where evolved_species_id = A.species_id)'evolucion_con_objeto', (SELECT minimum_level FROM pokemon_evolution where evolved_species_id = A.species_id)'evolucion_nivel_min', (SELECT gender_id FROM pokemon_evolution where evolved_species_id = A.species_id)'evolucion_por_sexo',(SELECT location_id FROM pokemon_evolution where evolved_species_id = A.species_id)'evolucion_por_localizacion',(SELECT held_item_id FROM pokemon_evolution where evolved_species_id = A.species_id)'evolucion_objeto_equipado', (SELECT time_of_day FROM pokemon_evolution where evolved_species_id = A.species_id)'evolucion_dia',(SELECT known_move_id FROM pokemon_evolution where evolved_species_id = A.species_id)'evolucion_movimiento', (SELECT known_move_type_id FROM pokemon_evolution where evolved_species_id = A.species_id)'evolucion_tipo_movimiento', (SELECT minimum_happiness FROM pokemon_evolution where evolved_species_id = A.species_id)'evolucion_felicidad_min',(SELECT minimum_beauty FROM pokemon_evolution where evolved_species_id = A.species_id)'evolucion_belleza_min',(SELECT relative_physical_stats FROM pokemon_evolution where evolved_species_id = A.species_id)'evolucion_stats',(SELECT party_species_id FROM pokemon_evolution where evolved_species_id = A.species_id)'evolucion_pokemon_equipo', (SELECT party_type_id FROM pokemon_evolution where evolved_species_id = A.species_id)'evolucion_tipo_equipo',(SELECT needs_overworld_rain FROM pokemon_evolution where evolved_species_id = A.species_id)'evolucion_lluvia', A.height'altura', C.has_gender_differences'tiene_formas', I.baby_trigger_item_id'objeto_criar', G.pokedex_number'pokedex_numero', E.flavor_text'Decripcion', B.genus'especie', C.generation_id'Generacion', C.evolves_from_species_id'evolucio_anterior', C.gender_rate'ratio_sexo', C.growth_rate_id'exp_base', (SELECT name FROM pokemon_habitat_names WHERE pokemon_habitat_id = C.habitat_id AND local_language_id = 7)'Habitat', C.capture_rate'ratio_captura', C.base_happiness'felicidad_base', (SELECT type_id FROM pokemon_types WHERE pokemon_id = A.id AND slot = 1 LIMIT 1)'tipo1', (SELECT type_id FROM pokemon_types WHERE pokemon_id = A.id AND slot = 2 LIMIT 1)'tipo2', (SELECT base_stat FROM pokemon_stats WHERE pokemon_id = A.id AND stat_id = 1 LIMIT 1)'hp', (SELECT base_stat FROM pokemon_stats WHERE pokemon_id = A.id AND stat_id = 2 LIMIT 1)'ataque', (SELECT base_stat FROM pokemon_stats WHERE pokemon_id = A.id AND stat_id = 3 LIMIT 1)'defensa', (SELECT base_stat FROM pokemon_stats WHERE pokemon_id = A.id AND stat_id = 4 LIMIT 1)'ataqueS', (SELECT base_stat FROM pokemon_stats WHERE pokemon_id = A.id AND stat_id = 5 LIMIT 1)'defensaS', (SELECT base_stat FROM pokemon_stats WHERE pokemon_id = A.id AND stat_id = 6 LIMIT 1)'velocidad', (SELECT effort FROM pokemon_stats WHERE pokemon_id = A.id AND stat_id = 1 LIMIT 1)'hpEV', (SELECT effort FROM pokemon_stats WHERE pokemon_id = A.id AND stat_id = 2 LIMIT 1)'ataqueEV', (SELECT effort FROM pokemon_stats WHERE pokemon_id = A.id AND stat_id = 3 LIMIT 1)'defensaEV', (SELECT effort FROM pokemon_stats WHERE pokemon_id = A.id AND stat_id = 4 LIMIT 1)'ataqueSEV', (SELECT effort FROM pokemon_stats WHERE pokemon_id = A.id AND stat_id = 5 LIMIT 1)'defensaSEV', (SELECT effort FROM pokemon_stats WHERE pokemon_id = A.id AND stat_id = 6 LIMIT 1)'velocidadEV' from pokemon A INNER JOIN pokemon_species_names B ON A.species_id = B.pokemon_species_id AND B.local_language_id = 7 INNER JOIN pokemon_species C ON A.species_id = C.id INNER JOIN pokemon_species_flavor_text E ON A.species_id = E.species_id AND E.version_id = 24 AND E.language_id = 7 INNER JOIN pokemon_dex_numbers G ON C.id = G.species_id AND G.pokedex_id = 1 INNER JOIN evolution_chains I ON C.evolution_chain_id = I.id");
       dsPokemons = LoadData(dsPokemons, "SELECT A.id, A.identifier 'Internal_name', A.species_id, B.name'Nombre', A.weight'peso', (SELECT name FROM pokemon_color_names WHERE pokemon_color_id = C.color_id AND local_language_id = 7)'Color', (SELECT evolution_trigger_id FROM pokemon_evolution where evolved_species_id = A.species_id)'tipo_evolucion', (SELECT trigger_item_id FROM pokemon_evolution where evolved_species_id = A.species_id)'evolucion_con_objeto', (SELECT minimum_level FROM pokemon_evolution where evolved_species_id = A.species_id)'evolucion_nivel_min', (SELECT gender_id FROM pokemon_evolution where evolved_species_id = A.species_id)'evolucion_por_sexo',(SELECT location_id FROM pokemon_evolution where evolved_species_id = A.species_id)'evolucion_por_localizacion',(SELECT held_item_id FROM pokemon_evolution where evolved_species_id = A.species_id)'evolucion_objeto_equipado', (SELECT time_of_day FROM pokemon_evolution where evolved_species_id = A.species_id)'evolucion_dia',(SELECT known_move_id FROM pokemon_evolution where evolved_species_id = A.species_id)'evolucion_movimiento', (SELECT known_move_type_id FROM pokemon_evolution where evolved_species_id = A.species_id)'evolucion_tipo_movimiento', (SELECT minimum_happiness FROM pokemon_evolution where evolved_species_id = A.species_id)'evolucion_felicidad_min',(SELECT minimum_beauty FROM pokemon_evolution where evolved_species_id = A.species_id)'evolucion_belleza_min',(SELECT relative_physical_stats FROM pokemon_evolution where evolved_species_id = A.species_id)'evolucion_stats',(SELECT party_species_id FROM pokemon_evolution where evolved_species_id = A.species_id)'evolucion_pokemon_equipo', (SELECT party_type_id FROM pokemon_evolution where evolved_species_id = A.species_id)'evolucion_tipo_equipo',(SELECT needs_overworld_rain FROM pokemon_evolution where evolved_species_id = A.species_id)'evolucion_lluvia', A.height'altura', C.has_gender_differences'tiene_formas', I.baby_trigger_item_id'objeto_criar', G.pokedex_number'pokedex_numero', E.flavor_text'Decripcion', B.genus'especie', C.generation_id'Generacion', C.evolves_from_species_id'evolucio_anterior', C.gender_rate'ratio_sexo', C.growth_rate_id'exp_base', (SELECT name FROM pokemon_habitat_names WHERE pokemon_habitat_id = C.habitat_id AND local_language_id = 7)'Habitat', C.capture_rate'ratio_captura', C.base_happiness'felicidad_base', (SELECT type_id FROM pokemon_types WHERE pokemon_id = A.id AND slot = 1 LIMIT 1)'tipo1', (SELECT type_id FROM pokemon_types WHERE pokemon_id = A.id AND slot = 2 LIMIT 1)'tipo2', (SELECT base_stat FROM pokemon_stats WHERE pokemon_id = A.id AND stat_id = 1 LIMIT 1)'hp', (SELECT base_stat FROM pokemon_stats WHERE pokemon_id = A.id AND stat_id = 2 LIMIT 1)'ataque', (SELECT base_stat FROM pokemon_stats WHERE pokemon_id = A.id AND stat_id = 3 LIMIT 1)'defensa', (SELECT base_stat FROM pokemon_stats WHERE pokemon_id = A.id AND stat_id = 4 LIMIT 1)'ataqueS', (SELECT base_stat FROM pokemon_stats WHERE pokemon_id = A.id AND stat_id = 5 LIMIT 1)'defensaS', (SELECT base_stat FROM pokemon_stats WHERE pokemon_id = A.id AND stat_id = 6 LIMIT 1)'velocidad', (SELECT effort FROM pokemon_stats WHERE pokemon_id = A.id AND stat_id = 1 LIMIT 1)'hpEV', (SELECT effort FROM pokemon_stats WHERE pokemon_id = A.id AND stat_id = 2 LIMIT 1)'ataqueEV', (SELECT effort FROM pokemon_stats WHERE pokemon_id = A.id AND stat_id = 3 LIMIT 1)'defensaEV', (SELECT effort FROM pokemon_stats WHERE pokemon_id = A.id AND stat_id = 4 LIMIT 1)'ataqueSEV', (SELECT effort FROM pokemon_stats WHERE pokemon_id = A.id AND stat_id = 5 LIMIT 1)'defensaSEV', (SELECT effort FROM pokemon_stats WHERE pokemon_id = A.id AND stat_id = 6 LIMIT 1)'velocidadEV' from pokemon A INNER JOIN pokemon_species_names B ON A.species_id = B.pokemon_species_id AND B.local_language_id = 7 INNER JOIN pokemon_species C ON A.species_id = C.id INNER JOIN pokemon_species_flavor_text E ON A.species_id = E.species_id AND E.version_id = 24 AND E.language_id = 7 INNER JOIN pokemon_dex_numbers G ON C.id = G.species_id AND G.pokedex_id = 1 INNER JOIN evolution_chains I ON C.evolution_chain_id = I.id");
        //        dsPokemons = LoadData(dsPokemons, "SELECT A.id, A.identifier 'Internal_name', B.name'Nombre', A.weight'peso', (SELECT name FROM pokemon_color_names WHERE pokemon_color_id = C.color_id AND local_language_id = 7)'Color', (SELECT evolution_trigger_id FROM pokemon_evolution where evolved_species_id = A.species_id)'tipo_evolucion', (SELECT trigger_item_id FROM pokemon_evolution where evolved_species_id = A.species_id)'evolucion_con_objeto', (SELECT minimum_level FROM pokemon_evolution where evolved_species_id = A.species_id)'evolucion_nivel_min', (SELECT gender_id FROM pokemon_evolution where evolved_species_id = A.species_id)'evolucion_por_sexo',(SELECT location_id FROM pokemon_evolution where evolved_species_id = A.species_id)'evolucion_por_localizacion',(SELECT held_item_id FROM pokemon_evolution where evolved_species_id = A.species_id)'evolucion_objeto_equipado', (SELECT time_of_day FROM pokemon_evolution where evolved_species_id = A.species_id)'evolucion_dia',(SELECT known_move_id FROM pokemon_evolution where evolved_species_id = A.species_id)'evolucion_movimiento', (SELECT known_move_type_id FROM pokemon_evolution where evolved_species_id = A.species_id)'evolucion_tipo_movimiento', (SELECT minimum_happiness FROM pokemon_evolution where evolved_species_id = A.species_id)'evolucion_felicidad_min',(SELECT minimum_beauty FROM pokemon_evolution where evolved_species_id = A.species_id)'evolucion_belleza_min',(SELECT relative_physical_stats FROM pokemon_evolution where evolved_species_id = A.species_id)'evolucion_stats',(SELECT party_species_id FROM pokemon_evolution where evolved_species_id = A.species_id)'evolucion_pokemon_equipo', (SELECT party_type_id FROM pokemon_evolution where evolved_species_id = A.species_id)'evolucion_tipo_equipo',(SELECT needs_overworld_rain FROM pokemon_evolution where evolved_species_id = A.species_id)'evolucion_lluvia', A.height'altura', C.has_gender_differences'tiene_formas', I.baby_trigger_item_id'objeto_criar', G.pokedex_number'pokedex_numero', E.flavor_text'Decripcion', B.genus'especie', C.generation_id'Generacion', C.evolves_from_species_id'evolucio_anterior', C.gender_rate'ratio_sexo', C.growth_rate_id'exp_base', (SELECT name FROM pokemon_habitat_names WHERE pokemon_habitat_id = C.habitat_id AND local_language_id = 7)'Habitat', C.capture_rate'ratio_captura', C.base_happiness'felicidad_base', (SELECT type_id FROM pokemon_types WHERE pokemon_id = A.id AND slot = 1 LIMIT 1)'tipo1', (SELECT type_id FROM pokemon_types WHERE pokemon_id = A.id AND slot = 2 LIMIT 1)'tipo2', (SELECT base_stat FROM pokemon_stats WHERE pokemon_id = A.id AND stat_id = 1 LIMIT 1)'hp', (SELECT base_stat FROM pokemon_stats WHERE pokemon_id = A.id AND stat_id = 2 LIMIT 1)'ataque', (SELECT base_stat FROM pokemon_stats WHERE pokemon_id = A.id AND stat_id = 3 LIMIT 1)'defensa', (SELECT base_stat FROM pokemon_stats WHERE pokemon_id = A.id AND stat_id = 4 LIMIT 1)'ataqueS', (SELECT base_stat FROM pokemon_stats WHERE pokemon_id = A.id AND stat_id = 5 LIMIT 1)'defensaS', (SELECT base_stat FROM pokemon_stats WHERE pokemon_id = A.id AND stat_id = 6 LIMIT 1)'velocidad', (SELECT effort FROM pokemon_stats WHERE pokemon_id = A.id AND stat_id = 1 LIMIT 1)'hpEV', (SELECT effort FROM pokemon_stats WHERE pokemon_id = A.id AND stat_id = 2 LIMIT 1)'ataqueEV', (SELECT effort FROM pokemon_stats WHERE pokemon_id = A.id AND stat_id = 3 LIMIT 1)'defensaEV', (SELECT effort FROM pokemon_stats WHERE pokemon_id = A.id AND stat_id = 4 LIMIT 1)'ataqueSEV', (SELECT effort FROM pokemon_stats WHERE pokemon_id = A.id AND stat_id = 5 LIMIT 1)'defensaSEV', (SELECT effort FROM pokemon_stats WHERE pokemon_id = A.id AND stat_id = 6 LIMIT 1)'velocidadEV' from pokemon A INNER JOIN pokemon_species_names B ON A.species_id = B.pokemon_species_id AND B.local_language_id = 7 INNER JOIN pokemon_species C ON A.species_id = C.id INNER JOIN pokemon_species_flavor_text E ON A.species_id = E.species_id AND E.version_id = 24 AND E.language_id = 7 INNER JOIN pokemon_dex_numbers G ON C.id = G.species_id AND G.pokedex_id = 1 INNER JOIN evolution_chains I ON C.evolution_chain_id = I.id");
        pokemons = new List<Pokemon>();

        new WaitForSeconds(5);
        Partida.actual.pokedex = new List<Pokemon>();
        Debug.Log(dsPokemons.Tables[0].Rows[0].ToString());
        Debug.Log("mic");
        for (int i = 0; i < 721; i++)
        {
            

           Pokemon pokemon = new Pokemon();
            //WWW www = new WWW("http://pokeapi.co/api/v2/pokemon/" + i + "/");
           
            //Debug.Log(www.text);
            //JsonData data = JsonMapper.ToObject(www.text);
            pokemon.nombre = dsPokemons.Tables[0].Rows[i]["Nombre"].ToString();
            pokemon.id = Convert.ToInt32(dsPokemons.Tables[0].Rows[i]["id"]);
            pokemon.pokedex_num = Convert.ToInt32(dsPokemons.Tables[0].Rows[i]["pokedex_numero"]);
            pokemon.internal_name = dsPokemons.Tables[0].Rows[i]["Internal_name"].ToString();
            pokemon.peso = Convert.ToInt32(dsPokemons.Tables[0].Rows[i]["peso"])/10;
            pokemon.altura = Convert.ToInt32(dsPokemons.Tables[0].Rows[i]["altura"])/10;
            pokemon.tipo_evolucion = (dsPokemons.Tables[0].Rows[i]["tipo_evolucion"] != null)? 0 :Convert.ToInt32(dsPokemons.Tables[0].Rows[i]["tipo_evolucion"]);
            //  pokemon.evolucion_con_objeto = (dsPokemons.Tables[0].Rows[i]["evolucion_con_objeto"] != null) ? null : Datos.objetos[Convert.ToInt32(dsPokemons.Tables[0].Rows[i]["evolucion__con_objeto"]) - 1];
            pokemon.evolucion_con_objeto = (dsPokemons.Tables[0].Rows[i]["evolucion_con_objeto"] != null) ? 0 : Convert.ToInt32(dsPokemons.Tables[0].Rows[i]["evolucion__con_objeto"]);
            pokemon.evolucion_nivel_min = (dsPokemons.Tables[0].Rows[i]["evolucion_nivel_min"] != null) ? 0 : Convert.ToInt32(dsPokemons.Tables[0].Rows[i]["evolucion_nivel_min"]);
            pokemon.evolucion_por_sexo = (dsPokemons.Tables[0].Rows[i]["evolucion_por_sexo"] != null) ? 0 : Convert.ToInt32(dsPokemons.Tables[0].Rows[i]["evolucion_por_sexo"]);
            pokemon.evolucion_por_localizacion = (dsPokemons.Tables[0].Rows[i]["evolucion_por_localizacion"] != null) ? 0 : Convert.ToInt32(dsPokemons.Tables[0].Rows[i]["evolucion_por_localizacion"]);
            //pokemon.evolucion_objeto_equipado = (dsPokemons.Tables[0].Rows[i]["evolucion_objeto_equipado"] != null) ? null : Datos.objetos[Convert.ToInt32(dsPokemons.Tables[0].Rows[i]["evolucion_objeto_equipado"]) - 1];
            pokemon.evolucion_objeto_equipado = (dsPokemons.Tables[0].Rows[i]["evolucion_objeto_equipado"] != null) ? 0 : Convert.ToInt32(dsPokemons.Tables[0].Rows[i]["evolucion_objeto_equipado"]);
            pokemon.evolucion_dia = (dsPokemons.Tables[0].Rows[i]["evolucion_dia"] != null) ? null : dsPokemons.Tables[0].Rows[i]["evolucion_dia"].ToString();
            //pokemon.evolucion_movimiento = (dsPokemons.Tables[0].Rows[i]["evolucion_movimiento"] != null) ? null : Datos.movimientos[Convert.ToInt32(dsPokemons.Tables[0].Rows[i]["evolucion_movimiento"]) - 1]; 
            pokemon.evolucion_movimiento = (dsPokemons.Tables[0].Rows[i]["evolucion_movimiento"] != null) ? 0 : Convert.ToInt32(dsPokemons.Tables[0].Rows[i]["evolucion_movimiento"]);
            pokemon.evolucion_tipo_movimiento = (dsPokemons.Tables[0].Rows[i]["evolucion_tipo_movimiento"] != null) ? 0 : Convert.ToInt32(dsPokemons.Tables[0].Rows[i]["evolucion__tipo_movimiento"]);
            //pokemon.evolucion_tipo_movimiento = (dsPokemons.Tables[0].Rows[i]["evolucion_tipo_movimiento"] != null) ? null : Datos.tipos[Convert.ToInt32(dsPokemons.Tables[0].Rows[i]["evolucion__tipo_movimiento"]) - 1];
            pokemon.evolucion_felicidad_min = (dsPokemons.Tables[0].Rows[i]["evolucion_felicidad_min"] != null) ? 0 : Convert.ToInt32(dsPokemons.Tables[0].Rows[i]["evolucion_felicidad_min"]);
            pokemon.evolucion_belleza_min = (dsPokemons.Tables[0].Rows[i]["evolucion_belleza_min"] != null) ? 0 : Convert.ToInt32(dsPokemons.Tables[0].Rows[i]["evolucion_belleza_min"]);
            pokemon.evolucion_stats = (dsPokemons.Tables[0].Rows[i]["evolucion_stats"] != null) ? 0 : Convert.ToInt32(dsPokemons.Tables[0].Rows[i]["evolucion_stats"]);
            pokemon.id_evolucion_pokemon_equipo = (dsPokemons.Tables[0].Rows[i]["evolucion_pokemon_equipo"] != null) ? 0 : Convert.ToInt32(dsPokemons.Tables[0].Rows[i]["evolucion_pokemon_equipo"]);
            // pokemon.evolucion_tipo_movimiento = (dsPokemons.Tables[0].Rows[i]["evolucion_tipo_movimiento"] != null) ? null : Datos.tipos[Convert.ToInt32(dsPokemons.Tables[0].Rows[i]["evolucion__tipo_movimiento"]) - 1];
            pokemon.evolucion_tipo_movimiento = (dsPokemons.Tables[0].Rows[i]["evolucion_tipo_movimiento"] != null) ? 0 : Convert.ToInt32(dsPokemons.Tables[0].Rows[i]["evolucion__tipo_movimiento"]);
            pokemon.evolucion_lluvia = (dsPokemons.Tables[0].Rows[i]["evolucion_lluvia"] != null) ? false : Convert.ToBoolean(dsPokemons.Tables[0].Rows[i]["evolucion__lluvia"]);
            pokemon.tiene_formas = (dsPokemons.Tables[0].Rows[i]["tiene_formas"] != null) ? false : Convert.ToBoolean(dsPokemons.Tables[0].Rows[i]["tiene_formas"]);
            //pokemon.objeto_criar = (dsPokemons.Tables[0].Rows[i]["objeto_criar"] != null) ? null : Datos.objetos[Convert.ToInt32(dsPokemons.Tables[0].Rows[i]["objeto_criar"]) - 1];
            pokemon.objeto_criar = (dsPokemons.Tables[0].Rows[i]["objeto_criar"] != null) ? 0 : Convert.ToInt32(dsPokemons.Tables[0].Rows[i]["objeto_criar"]);
            pokemon.desc_pokedex = dsPokemons.Tables[0].Rows[i]["Decripcion"].ToString();
            pokemon.especie = dsPokemons.Tables[0].Rows[i]["especie"].ToString();
            pokemon.generacion = Convert.ToInt32(dsPokemons.Tables[0].Rows[i]["Generacion"]);
            pokemon.id_evolucio_anterior = (dsPokemons.Tables[0].Rows[i]["evolucio_anterior"] != null) ? 0 : Convert.ToInt32(dsPokemons.Tables[0].Rows[i]["evolucio_anterior"]);
            pokemon.ratio_sexo = Convert.ToInt32(dsPokemons.Tables[0].Rows[i]["Generacion"]);
            pokemon.id_exp_base = Convert.ToInt32(dsPokemons.Tables[0].Rows[i]["exp_base"]);
            pokemon.habitat = (dsPokemons.Tables[0].Rows[i]["Habitat"] != null) ? null : dsPokemons.Tables[0].Rows[i]["Habitat"].ToString();
            pokemon.ratio_captura = Convert.ToInt32(dsPokemons.Tables[0].Rows[i]["ratio_captura"]);
            pokemon.felicidad_base = Convert.ToInt32(dsPokemons.Tables[0].Rows[i]["felicidad_base"]);
            //pokemon.tipo1 = (dsPokemons.Tables[0].Rows[i]["tipo1"] != null) ? null : Datos.tipos[Convert.ToInt32(dsPokemons.Tables[0].Rows[i]["tipo1"]) - 1];
            pokemon.tipo1 = (dsPokemons.Tables[0].Rows[i]["tipo1"] != null) ? 0 : Convert.ToInt32(dsPokemons.Tables[0].Rows[i]["tipo1"]);
            //pokemon.tipo2 = (dsPokemons.Tables[0].Rows[i]["tipo2"] != null) ? null : Datos.tipos[Convert.ToInt32(dsPokemons.Tables[0].Rows[i]["tipo2"]) - 1];
            pokemon.tipo2 = (dsPokemons.Tables[0].Rows[i]["tipo2"] != null) ? 0 : Convert.ToInt32(dsPokemons.Tables[0].Rows[i]["tipo2"]);
            pokemon.hp_total = Convert.ToInt32(dsPokemons.Tables[0].Rows[i]["hp"]);
            pokemon.ataque = Convert.ToInt32(dsPokemons.Tables[0].Rows[i]["ataque"]);
            pokemon.defensa = Convert.ToInt32(dsPokemons.Tables[0].Rows[i]["defensa"]);
            pokemon.ataqueS = Convert.ToInt32(dsPokemons.Tables[0].Rows[i]["ataqueS"]);
            pokemon.defensaS = Convert.ToInt32(dsPokemons.Tables[0].Rows[i]["defensaS"]);
            pokemon.velocidad = Convert.ToInt32(dsPokemons.Tables[0].Rows[i]["velocidad"]);
            pokemon.EVHP = Convert.ToInt32(dsPokemons.Tables[0].Rows[i]["hpEV"]);
            pokemon.EVAtaque = Convert.ToInt32(dsPokemons.Tables[0].Rows[i]["ataqueEV"]);
            pokemon.EVDefensa = Convert.ToInt32(dsPokemons.Tables[0].Rows[i]["defensaEV"]);
            pokemon.EVDefensaS = Convert.ToInt32(dsPokemons.Tables[0].Rows[i]["defensaSEV"]);
            pokemon.EVAtaqueS = Convert.ToInt32(dsPokemons.Tables[0].Rows[i]["ataqueSEV"]);
            pokemon.EVvelocidad = Convert.ToInt32(dsPokemons.Tables[0].Rows[i]["velocidadEV"]);

            //SELECT * FROM experience WHERE growth_rate_id =
            DataSet dsExp = new DataSet();

            dsExp = LoadData(dsExp, "SELECT experience FROM experience WHERE growth_rate_id = " + pokemon.id_exp_base);
            for (int e = 0; e <100; e++)
            {
                pokemon.experiencia_nivells.Add(Convert.ToInt32(dsExp.Tables[0].Rows[e]["experience"]));
            }

            DataSet movesLevel = new DataSet();

            movesLevel = LoadData(movesLevel, "SELECT move_id, level FROM pokemon_moves WHERE pokemon_id = " + pokemon.id + " AND pokemon_Move_method_id = 1 AND version_group_id = 15 ORDER BY level");
            for (int e = 0; e < movesLevel.Tables[0].Rows.Count ; e++)
            {
                //pokemon.movimientos.Add(Datos.movimientos[Convert.ToInt32(movesLevel.Tables[0].Rows[e]["move_id"]) - 1]);
                pokemon.movimientos.Add(Convert.ToInt32(movesLevel.Tables[0].Rows[e]["move_id"]));
                pokemon.niveles_movimientos.Add(Convert.ToInt32(movesLevel.Tables[0].Rows[e]["level"]));

            }
            Debug.Log("egg");
            DataSet movesEgg = new DataSet();

            movesEgg = LoadData(movesEgg, "SELECT move_id FROM pokemon_moves WHERE pokemon_id = " + pokemon.id + " AND pokemon_Move_method_id = 2 AND version_group_id = 15");

            for (int e = 0; e < movesEgg.Tables[0].Rows.Count; e++)
            {
                //pokemon.movimientos_huevo.Add(Datos.movimientos[Convert.ToInt32(movesEgg.Tables[0].Rows[e]["move_id"]) - 1]);
                pokemon.movimientos_huevo.Add(Convert.ToInt32(movesEgg.Tables[0].Rows[e]["move_id"]));
            }

            DataSet movesTutor = new DataSet();
            Debug.Log("tutor");
            movesTutor = LoadData(movesTutor, "SELECT move_id FROM pokemon_moves WHERE pokemon_id = " + pokemon.id + " AND pokemon_Move_method_id = 3 AND version_group_id = 15");

            for (int e = 0; e < movesTutor.Tables[0].Rows.Count; e++)
            {
                //pokemon.movimientos_tutor.Add(Datos.movimientos[Convert.ToInt32(movesTutor.Tables[0].Rows[e]["move_id"]) - 1]);
                pokemon.movimientos_tutor.Add(Convert.ToInt32(movesTutor.Tables[0].Rows[e]["move_id"]));
            }
            Debug.Log("MT");
            DataSet movesMTMO = new DataSet();

            movesMTMO = LoadData(movesMTMO, "SELECT move_id FROM pokemon_moves WHERE pokemon_id = " + pokemon.id + " AND pokemon_Move_method_id = 4 AND version_group_id = 15");

            for (int e = 0; e < movesMTMO.Tables[0].Rows.Count; e++)
            {
                // pokemon.MTMOs.Add(Datos.movimientos[Convert.ToInt32(movesMTMO.Tables[0].Rows[e]["move_id"]) - 1]);
                pokemon.MTMOs.Add(Convert.ToInt32(movesMTMO.Tables[0].Rows[e]["move_id"]));
            }

            DataSet EggGroups = new DataSet();
            Debug.Log("EGGGROUP");

            EggGroups = LoadData(EggGroups, "SELECT B.name FROM pokemon_egg_groups A INNER JOIN egg_group_prose B ON A.egg_group_id = B.egg_group_id AND B.local_language_id = 7 WHERE species_id = " + Convert.ToInt32(dsPokemons.Tables[0].Rows[i]["species_id"]));

            if(EggGroups.Tables[0].Rows.Count == 2)
            {
                pokemon.grupo_huevo1 = EggGroups.Tables[0].Rows[0]["name"].ToString();
                pokemon.grupo_huevo2 = EggGroups.Tables[0].Rows[1]["name"].ToString();
            }
            else
            {
                pokemon.grupo_huevo1 = EggGroups.Tables[0].Rows[0]["name"].ToString();
                pokemon.grupo_huevo2 = null;
            }

            DataSet Habilidades = new DataSet();
            Debug.Log("HABILIDAD");
            Habilidades = LoadData(Habilidades, "SELECT B.name FROM pokemon_abilities A INNER JOIN ability_names B ON A.ability_id = B.ability_id AND b.local_language_id = 7 WHERE A.pokemon_id = " + pokemon.id + " AND A.slot <> 3");

            if (Habilidades.Tables[0].Rows.Count == 2)
            {
                pokemon.habilidad1 = Habilidades.Tables[0].Rows[0]["name"].ToString();
                pokemon.habilidad2 = Habilidades.Tables[0].Rows[1]["name"].ToString();
            }
            else
            {
                pokemon.habilidad1 = Habilidades.Tables[0].Rows[0]["name"].ToString();
                pokemon.habilidad2 = null;
            }

            DataSet HabOculta = new DataSet();
            Debug.Log("HABOCULTA");
            HabOculta = LoadData(HabOculta, "SELECT B.name FROM pokemon_abilities A INNER JOIN ability_names B ON A.ability_id = B.ability_id AND b.local_language_id = 7 WHERE A.pokemon_id = " + pokemon.id + " AND A.slot = 3");

            if (HabOculta.Tables[0].Rows.Count == 1)
            {
                pokemon.habilidad_oculta = HabOculta.Tables[0].Rows[0]["name"].ToString();
            }else
            {
                pokemon.habilidad_oculta = null;
            }

            DataSet ObjetosPKMN = new DataSet();
            Debug.Log("OBJETOS");
            ObjetosPKMN = LoadData(ObjetosPKMN, "SELECT item_id, rarity FROM pokemon_items WHERE pokemon_id =" + pokemon.id + " AND version_id = 24");

            if (ObjetosPKMN.Tables[0].Rows.Count == 3)
            {
              //  pokemon.objeto1 = Datos.objetos[Convert.ToInt32(ObjetosPKMN.Tables[0].Rows[0]["item_id"]) - 1];
               // pokemon.objeto2 = Datos.objetos[Convert.ToInt32(ObjetosPKMN.Tables[0].Rows[1]["item_id"]) - 1];
                //pokemon.objeto3 = Datos.objetos[Convert.ToInt32(ObjetosPKMN.Tables[0].Rows[2]["item_id"]) - 1];
                pokemon.objeto1 = Convert.ToInt32(ObjetosPKMN.Tables[0].Rows[0]["item_id"]);
                pokemon.objeto2 = Convert.ToInt32(ObjetosPKMN.Tables[0].Rows[1]["item_id"]);
                pokemon.objeto3 = Convert.ToInt32(ObjetosPKMN.Tables[0].Rows[2]["item_id"]);

                pokemon.rareza_obj1 = Convert.ToInt32(ObjetosPKMN.Tables[0].Rows[0]["rarity"]);
                pokemon.rareza_obj2 = Convert.ToInt32(ObjetosPKMN.Tables[0].Rows[1]["rarity"]);
                pokemon.rareza_obj3 = Convert.ToInt32(ObjetosPKMN.Tables[0].Rows[2]["rarity"]);
            }
            else if(ObjetosPKMN.Tables[0].Rows.Count == 2)
            {
                //pokemon.objeto1 = Datos.objetos[Convert.ToInt32(ObjetosPKMN.Tables[0].Rows[0]["item_id"]) - 1];
                //pokemon.objeto2 = Datos.objetos[Convert.ToInt32(ObjetosPKMN.Tables[0].Rows[1]["item_id"]) - 1];
                //pokemon.objeto3 = null;
                pokemon.objeto1 = Convert.ToInt32(ObjetosPKMN.Tables[0].Rows[0]["item_id"]);
                pokemon.objeto2 = Convert.ToInt32(ObjetosPKMN.Tables[0].Rows[1]["item_id"]);
                pokemon.objeto3 = 0;

                pokemon.rareza_obj1 = Convert.ToInt32(ObjetosPKMN.Tables[0].Rows[0]["rarity"]);
                pokemon.rareza_obj2 = Convert.ToInt32(ObjetosPKMN.Tables[0].Rows[1]["rarity"]);
                pokemon.rareza_obj3 = 0;
            }else if (ObjetosPKMN.Tables[0].Rows.Count == 1)
            {
                //pokemon.objeto1 = Datos.objetos[Convert.ToInt32(ObjetosPKMN.Tables[0].Rows[0]["item_id"]) - 1];
                //pokemon.objeto2 = null;
                //pokemon.objeto3 = null;
                pokemon.objeto1 = Convert.ToInt32(ObjetosPKMN.Tables[0].Rows[0]["item_id"]);
                pokemon.objeto2 = 0;
                pokemon.objeto3 = 0;


                pokemon.rareza_obj1 = Convert.ToInt32(ObjetosPKMN.Tables[0].Rows[0]["rarity"]);
                pokemon.rareza_obj2 = 0;
                pokemon.rareza_obj3 = 0;
            }
            else
            {
                //pokemon.objeto1 = null;
                //pokemon.objeto2 = null;
                //pokemon.objeto3 = null;
                pokemon.objeto1 = 0;
                pokemon.objeto2 = 0;
                pokemon.objeto3 = 0;

                pokemon.rareza_obj1 = 0;
                pokemon.rareza_obj2 = 0;
                pokemon.rareza_obj3 = 0;
            }

            Debug.Log(pokemon.nombre);
            pokemons.Add(pokemon);
        }
        File.WriteAllText(Application.persistentDataPath + "/pokemon.txt", JsonMapper.ToJson(pokemons).ToString());
        yield return null;
    }

    public IEnumerator loadObjetos()
    {
        DataSet dsObjetos = new DataSet();
        Datos.objetos = new List<Objeto>();
        dsObjetos = LoadData(dsObjetos, "SELECT A.id, A.identifier'Internal_name', (SELECT name FROM item_names WHERE A.id = item_id AND local_language_id = 7)'Nombre', A.cost'Precio', A.fling_power'daño_fling', B.identifier'Categoria', A.fling_effect_id'efecto_fling', (SELECT name FROM item_pocket_names WHERE B.pocket_id = item_pocket_id AND local_language_id = 7)'zona_mochila', (SELECT flavor_text FROM item_flavor_text WHERE a.id = item_id AND language_id = 7 AND version_group_id = 15)'Descripcion' FROM items A INNER JOIN item_categories B ON A.category_id = B.id");//"SELECT A.id, A.identifier'Internal_name', A.cost'Precio', A.fling_power'daño_fling', B.identifier'Categoria', A.fling_effect_id'efecto_fling', C.name'zona_mochila', D.flavor_text'Descripcion' FROM items A INNER JOIN item_categories B ON A.category_id = B.id INNER JOIN item_pocket_names C ON B.pocket_id = C.item_pocket_id AND C.local_language_id = 7 INNER JOIN item_flavor_text D ON a.id = D.item_id AND D.language_id = 7 AND D.version_group_id = 15");
        Debug.Log("mic");

        for (int i = 0; i < 746; i++)
        {
            Objeto objeto = new Objeto();

            objeto.id = Convert.ToInt32(dsObjetos.Tables[0].Rows[i]["id"]);
            objeto.internal_name = dsObjetos.Tables[0].Rows[i]["Internal_name"].ToString();
            objeto.nombre = dsObjetos.Tables[0].Rows[i]["Internal_name"].ToString();
            objeto.precio = Convert.ToInt32(dsObjetos.Tables[0].Rows[i]["Precio"]);
            objeto.daño_fling = (dsObjetos.Tables[0].Rows[i]["daño_fling"] != null) ? 0 : Convert.ToInt32(dsObjetos.Tables[0].Rows[i]["daño_fling"]);
            objeto.categoria = dsObjetos.Tables[0].Rows[i]["Categoria"].ToString();
            objeto.efecto_fling = (dsObjetos.Tables[0].Rows[i]["efecto_fling"] != null) ? 0 : Convert.ToInt32(dsObjetos.Tables[0].Rows[i]["efecto_fling"]);
            objeto.zona_mochila = dsObjetos.Tables[0].Rows[i]["zona_mochila"].ToString();
            objeto.descripcion = dsObjetos.Tables[0].Rows[i]["Descripcion"].ToString();
            Debug.Log(objeto.nombre);
            objetos.Add(objeto);
        }

        File.WriteAllText(Application.persistentDataPath + "/objetos.txt", JsonMapper.ToJson(objetos).ToString());
        yield return null;
    }

    public void loadMovimientos()
    {
        DataSet dsmovimientos = new DataSet();
        Datos.movimientos = new List<Movimiento>();
        dsmovimientos = LoadData(dsmovimientos,"SELECT A.id, A.identifier'Internal_name', B.name'Nombre', A.power'Potencia', A.type_id'idTipo', A.damage_class_id'idCategoria', A.accuracy'Precision', A.pp,A.effect_chance'probabilidad_efecto',A.target_id,A.priority'Prioridad',A.effect_id'efecto'  FROM moves A INNER JOIN move_names B ON A.id = B.move_id AND B.local_language_id = 7");
        Debug.Log("mic");
        for (int i = 0; i < 617; i++)
        {
            //Debug.Log("mec");
            //dsmovimientos.Tables[0].Columns[""].ToString();
            Movimiento movimiento = new Movimiento();
            //WWW www = new WWW("http://pokeapi.co/api/v2/move/" + i + "/");
            //yield return www;
            //Debug.Log(www.text);
            //JsonData data = JsonMapper.ToObject(www.text);
            //movimiento.id = Convert.ToInt32(data["id"].ToString());
            //movimiento.internal_name = data["name"].ToString();
            //movimiento.nombre = data["names"][2]["name"].ToString();
            //movimiento.potencia = Convert.ToInt32(data["power"].ToString());
            //movimiento.tipo = tipos[Convert.ToInt32(data["type"]["url"].ToString().Substring(30, (data["type"]["url"].ToString().Length - 1) - 30)) - 1];
            //movimiento.categoria = categorias[Convert.ToInt32(data["damage_class"]["url"].ToString().Substring(43, (data["move_damage_class"]["url"].ToString().Length - 1) - 43)) - 1];
            //movimiento.precision = Convert.ToInt32(data["accuracy"].ToString());
            //movimiento.PP = Convert.ToInt32(data["pp"].ToString());
            //movimiento.probabilidad_efecto = Convert.ToInt32(data["effect_chance"].ToString());
            //movimiento.target = Convert.ToInt32(data["target"]["url"].ToString().Substring(42, (data["move_damage_class"]["url"].ToString().Length - 1) - 42));
            //movimiento.prioridad = movimiento.probabilidad_efecto = Convert.ToInt32(data["priority"].ToString());

            movimiento.id = Convert.ToInt32(dsmovimientos.Tables[0].Rows[i]["id"]);
            movimiento.internal_name = dsmovimientos.Tables[0].Rows[i]["Internal_name"].ToString();
            movimiento.nombre = dsmovimientos.Tables[0].Rows[i]["Nombre"].ToString();
            movimiento.potencia = (dsmovimientos.Tables[0].Rows[i]["Potencia"] != null)?0:Convert.ToInt32(dsmovimientos.Tables[0].Rows[i]["Potencia"]);
            movimiento.tipo = tipos[Convert.ToInt32(dsmovimientos.Tables[0].Rows[i]["idTipo"])-1];
            movimiento.categoria = categorias[Convert.ToInt32(dsmovimientos.Tables[0].Rows[i]["idCategoria"])-1];
            movimiento.precision = (dsmovimientos.Tables[0].Rows[i]["Precision"] != null) ? 0 :Convert.ToInt32(dsmovimientos.Tables[0].Rows[i]["Precision"]);
            movimiento.PP = (dsmovimientos.Tables[0].Rows[i]["pp"] != null) ? 0 : Convert.ToInt32(dsmovimientos.Tables[0].Rows[i]["pp"]);
            Debug.Log(dsmovimientos.Tables[0].Rows[i]["probabilidad_efecto"]);
            movimiento.probabilidad_efecto = (dsmovimientos.Tables[0].Rows[i]["probabilidad_efecto"] != null) ? 0 : Convert.ToInt32(dsmovimientos.Tables[0].Rows[i]["probabilidad_efecto"]);
            movimiento.target = (dsmovimientos.Tables[0].Rows[i]["target_id"] != null) ? 0 : Convert.ToInt32(dsmovimientos.Tables[0].Rows[i]["target_id"]);
            movimiento.prioridad = (dsmovimientos.Tables[0].Rows[i]["Prioridad"] != null) ? 0 : Convert.ToInt32(dsmovimientos.Tables[0].Rows[i]["Prioridad"]);
            movimiento.efecto = (dsmovimientos.Tables[0].Rows[i]["efecto"] != null) ? 0 : Convert.ToInt32(dsmovimientos.Tables[0].Rows[i]["efecto"]);


            //if (data["types"].Count > 1)
            //{
            //    pokemon.tipo1 = data["types"][1]["type"]["name"].ToString();
            //    pokemon.tipo2 = data["types"][0]["type"]["name"].ToString();
            //}
            //else
            //{
            //    pokemon.tipo1 = data["types"][0]["type"]["name"].ToString();
            //    pokemon.tipo2 = "NONE";
            //}
            Debug.Log(movimiento.nombre);
            movimientos.Add(movimiento);

        }
        File.WriteAllText(Application.persistentDataPath + "/movimientos.txt", JsonMapper.ToJson(movimientos).ToString());
    


    //string[] listaPropiedadesMovimientos = GetProperties1("moves.txt");
    //String[] PropiedadesMovimiento;
    //movimiento = new Movimiento();
    //List<Movimiento> Movimientos = new List<Movimiento>();
    //for (int i = 0; i < listaPropiedadesMovimientos.Length; i++)
    //{
    //    movimiento = new Movimiento();
    //    PropiedadesMovimiento = listaPropiedadesMovimientos[i].Split(',');
    //    movimiento.Id = Convert.ToInt32(PropiedadesMovimiento[0]);
    //    movimiento.Internal_name = PropiedadesMovimiento[1];
    //    movimiento.Nombre = PropiedadesMovimiento[2];
    //    Debug.Log(movimiento.Nombre);
    //    movimiento.Function_code = PropiedadesMovimiento[3];
    //    movimiento.Potencia = Convert.ToInt32(PropiedadesMovimiento[4]);
    //    movimiento.Tipo = PropiedadesMovimiento[5];
    //    movimiento.Categoria = PropiedadesMovimiento[6];
    //    movimiento.Precision = Convert.ToInt32(PropiedadesMovimiento[7]);
    //    movimiento.PP1 = Convert.ToInt32(PropiedadesMovimiento[8]);
    //    movimiento.Probabilidad_efecto = Convert.ToInt32(PropiedadesMovimiento[9]);
    //    movimiento.Target = PropiedadesMovimiento[10];
    //    movimiento.Prioridad = Convert.ToInt32(PropiedadesMovimiento[11]);
    //    movimiento.Flags = PropiedadesMovimiento[12];
    //    movimiento.Descripcion = PropiedadesMovimiento[13];
    //    Movimientos.Add(movimiento);

}

           
    

    public IEnumerator loadTipos()
    {
        Datos.tipos = new List<Tipo>();
        Debug.Log("mic");
        for (int i = 1; i < 19; i++)
        {
            Debug.Log("mec");

            Tipo tipo = new Tipo();
            WWW www = new WWW("http://pokeapi.co/api/v2/type/" + i + "/");
            yield return www;
            Debug.Log(www.text);
            JsonData data = JsonMapper.ToObject(www.text);
            tipo.id = Convert.ToInt32(data["id"].ToString());
            tipo.internal_name = data["name"].ToString();
            tipo.nombre = data["names"][4]["name"].ToString();
          //  Debug.Log(data["move_damage_class"]["url"].ToString().Substring(43, (data["move_damage_class"]["url"].ToString().Length - 1) - 43));
            if (i == 18)
            {
                tipo.categoria = categorias[2];
            }
            else
            {
                tipo.categoria = Datos.categorias[Convert.ToInt32(data["move_damage_class"]["url"].ToString().Substring(43, (data["move_damage_class"]["url"].ToString().Length - 1) - 43))-1];
            }
            for (int e = 0; e < data["pokemon"].Count; e++)
            {
                Debug.Log(data["pokemon"][e]["pokemon"]["url"].ToString().Substring(33, (data["pokemon"][e]["pokemon"]["url"].ToString().Length - 1) - 33));
                
                
                tipo.pokemons.Add(Convert.ToInt32(data["pokemon"][e]["pokemon"]["url"].ToString().Substring(33, (data["pokemon"][e]["pokemon"]["url"].ToString().Length - 1) - 33)));

                
            }

            for (int f = 0; f < data["moves"].Count; f++)
            {
                Debug.Log(data["moves"][f]["url"].ToString().Substring(30, (data["moves"][f]["url"].ToString().Length - 1) - 30));
                tipo.movimientos.Add(Convert.ToInt32(data["moves"][f]["url"].ToString().Substring(30, (data["moves"][f]["url"].ToString().Length - 1) - 30)));
            }


            if(data["damage_relations"]["no_damage_from"].Count > 0)
            {

                for (int m = 0; m < data["damage_relations"]["no_damage_from"].Count; m++)
                {
                    Debug.Log(data["damage_relations"]["no_damage_from"][m]["url"].ToString().Substring(30, (data["damage_relations"]["no_damage_from"][m]["url"].ToString().Length - 1) - 30));
                    tipo.immunities.Add(Convert.ToInt32(data["damage_relations"]["no_damage_from"][m]["url"].ToString().Substring(30, (data["damage_relations"]["no_damage_from"][m]["url"].ToString().Length - 1) - 30)));
                }
            }
            if (data["damage_relations"]["half_damage_from"].Count > 0)
            {
                for (int m = 0; m < data["damage_relations"]["half_damage_from"].Count; m++)
                {
                    tipo.resistances.Add(Convert.ToInt32(data["damage_relations"]["half_damage_from"][m]["url"].ToString().Substring(30, (data["damage_relations"]["half_damage_from"][m]["url"].ToString().Length - 1) - 30)));
                }
            }
            if (data["damage_relations"]["double_damage_from"].Count > 0)
            {
                for (int m = 0; m < data["damage_relations"]["double_damage_from"].Count; m++)
                {
                    tipo.weakness.Add(Convert.ToInt32(data["damage_relations"]["double_damage_from"][m]["url"].ToString().Substring(30, (data["damage_relations"]["double_damage_from"][m]["url"].ToString().Length - 1) - 30)));
                }
            }

            //  movimiento.tipo =


            //if (data["types"].Count > 1)
            //{
            //    pokemon.tipo1 = data["types"][1]["type"]["name"].ToString();
            //    pokemon.tipo2 = data["types"][0]["type"]["name"].ToString();
            //}
            //else
            //{
            //    pokemon.tipo1 = data["types"][0]["type"]["name"].ToString();
            //    pokemon.tipo2 = "NONE";
            //}
            //Partida.actual.pokedex.Add(pokemon);
            Datos.tipos.Add(tipo);
            Debug.Log(tipo.nombre + " " + tipo.movimientos[10]);
        }
 
        File.WriteAllText(Application.persistentDataPath + "/types.txt", JsonMapper.ToJson(Datos.tipos).ToString());




        //string fileName = "types.txt";

        //List<Tipo> Tipos = new List<Tipo>();
        //for (int i = 0; i <= index_tipo; i++)
        //{
        //    tipo = new Tipo();
        //    tipo.Nombre = GetProperties2(i, "Name", fileName);
        //    Debug.Log(tipo.Nombre);
        //    tipo.Internal_name = GetProperties2(i, "InternalName", fileName);
        //    tipo.SetIsPseudoType(GetProperties2(i, "IsPseudoType", fileName));
        //    tipo.SetIsSpecialType(GetProperties2(i, "IsSpecialType", fileName));
        //    tipo.SetWeaknesses(GetProperties2(i, "Weaknesses", fileName));
        //    tipo.SetResistances(GetProperties2(i, "Resistances", fileName));
        //    tipo.SetImmunities(GetProperties2(i, "Immunities", fileName));

        //    Tipos.Add(tipo);

        //}

        //return Tipos;
    }

    public IEnumerator loadCategoriaMovimiento()
    {
        Datos.categorias = new List<CategoriaMovimiento>();
        Debug.Log("mic");
        for (int i = 1; i < 4; i++)
        {
            Debug.Log("mec");

            CategoriaMovimiento categoria = new CategoriaMovimiento();
            WWW www = new WWW("http://pokeapi.co/api/v2/move-damage-class/" + i + "/");
            yield return www;
            Debug.Log(www.text);
            JsonData data = JsonMapper.ToObject(www.text);
            categoria.id = Convert.ToInt32(data["id"].ToString());
            categoria.internal_name = data["name"].ToString();
            categoria.nombre = data["names"][3]["name"].ToString();
            categoria.descripcion = data["descriptions"][0]["description"].ToString();
            for (int e = 0; e < data["moves"].Count; e++)
            {
                Debug.Log(data["moves"][e]["url"].ToString().Substring(30, (data["moves"][e]["url"].ToString().Length - 1) - 30));
                categoria.movimientos.Add(Convert.ToInt32(data["moves"][e]["url"].ToString().Substring(30, (data["moves"][e]["url"].ToString().Length-1) - 30)));
            }

            Debug.Log(categoria.nombre + " " + categoria.movimientos[21]);


            //if (data["types"].Count > 1)
            //{
            //    pokemon.tipo1 = data["types"][1]["type"]["name"].ToString();
            //    pokemon.tipo2 = data["types"][0]["type"]["name"].ToString();
            //}
            //else
            //{
            //    pokemon.tipo1 = data["types"][0]["type"]["name"].ToString();
            //    pokemon.tipo2 = "NONE";
            //}
            Datos.categorias.Add(categoria);
        }
        File.WriteAllText(Application.persistentDataPath + "/CategoriasMovimientos.txt", JsonMapper.ToJson(Datos.categorias).ToString());
    }
    //public void loadMap(Map mapa, int id)
    //{
    //    string fileName = "encounters.txt";


    //    string[] probabilidad = GetProperties2(id, "Probabilidad", fileName).Split(',');
    //    Debug.Log(GetProperties2(id, "Probabilidad", fileName));  
    //    mapa.Probabilidad_pkmn[0] = Convert.ToInt32(probabilidad[0]);
    //    mapa.Probabilidad_pkmn[1] = Convert.ToInt32(probabilidad[1]);
    //    mapa.Probabilidad_pkmn[0] = Convert.ToInt32(probabilidad[2]);

    //    mapa.Land[0] = GetProperties2(id, "PokemonLand1", fileName);
    //    mapa.Land[1] = GetProperties2(id, "PokemonLand2", fileName);
    //    mapa.Land[2] = GetProperties2(id, "PokemonLand3", fileName);
    //    mapa.Land[3] = GetProperties2(id, "PokemonLand4", fileName);
    //    mapa.Land[4] = GetProperties2(id, "PokemonLand5", fileName);
    //    mapa.Land[5] = GetProperties2(id, "PokemonLand6", fileName);
    //    mapa.Land[6] = GetProperties2(id, "PokemonLand7", fileName);
    //    mapa.Land[7] = GetProperties2(id, "PokemonLand8", fileName);
    //    mapa.Land[8] = GetProperties2(id, "PokemonLand9", fileName);
    //    mapa.Land[9] = GetProperties2(id, "PokemonLand10", fileName);
    //    mapa.Land[10] = GetProperties2(id, "PokemonLand11", fileName);
    //    mapa.Land[11] = GetProperties2(id, "PokemonLand12", fileName);

    //    mapa.LandMorning[0] = GetProperties2(id, "PokemonLandMorning1", fileName);
    //    mapa.LandMorning[1] = GetProperties2(id, "PokemonLandMorning2", fileName);
    //    mapa.LandMorning[2] = GetProperties2(id, "PokemonLandMorning3", fileName);
    //    mapa.LandMorning[3] = GetProperties2(id, "PokemonLandMorning4", fileName);
    //    mapa.LandMorning[4] = GetProperties2(id, "PokemonLandMorning5", fileName);
    //    mapa.LandMorning[5] = GetProperties2(id, "PokemonLandMorning6", fileName);
    //    mapa.LandMorning[6] = GetProperties2(id, "PokemonLandMorning7", fileName);
    //    mapa.LandMorning[7] = GetProperties2(id, "PokemonLandMorning8", fileName);
    //    mapa.LandMorning[8] = GetProperties2(id, "PokemonLandMorning9", fileName);
    //    mapa.LandMorning[9] = GetProperties2(id, "PokemonLandMorning10", fileName);
    //    mapa.LandMorning[10] = GetProperties2(id, "PokemonLandMorning11", fileName);
    //    mapa.LandMorning[11] = GetProperties2(id, "PokemonLandMorning12", fileName);

    //    mapa.LandDay[0] = GetProperties2(id, "PokemonLandDay1", fileName);
    //    mapa.LandDay[1] = GetProperties2(id, "PokemonLandDay2", fileName);
    //    mapa.LandDay[2] = GetProperties2(id, "PokemonLandDay3", fileName);
    //    mapa.LandDay[3] = GetProperties2(id, "PokemonLandDay4", fileName);
    //    mapa.LandDay[4] = GetProperties2(id, "PokemonLandDay5", fileName);
    //    mapa.LandDay[5] = GetProperties2(id, "PokemonLandDay6", fileName);
    //    mapa.LandDay[6] = GetProperties2(id, "PokemonLandDay7", fileName);
    //    mapa.LandDay[7] = GetProperties2(id, "PokemonLandDay8", fileName);
    //    mapa.LandDay[8] = GetProperties2(id, "PokemonLandDay9", fileName);
    //    mapa.LandDay[9] = GetProperties2(id, "PokemonLandDay10", fileName);
    //    mapa.LandDay[10] = GetProperties2(id, "PokemonLandDay11", fileName);
    //    mapa.LandDay[11] = GetProperties2(id, "PokemonLandDay12", fileName);

    //    mapa.LandNight[0] = GetProperties2(id, "PokemonLandNight1", fileName);
    //    mapa.LandNight[1] = GetProperties2(id, "PokemonLandNight2", fileName);
    //    mapa.LandNight[2] = GetProperties2(id, "PokemonLandNight3", fileName);
    //    mapa.LandNight[3] = GetProperties2(id, "PokemonLandNight4", fileName);
    //    mapa.LandNight[4] = GetProperties2(id, "PokemonLandNight5", fileName);
    //    mapa.LandNight[5] = GetProperties2(id, "PokemonLandNight6", fileName);
    //    mapa.LandNight[6] = GetProperties2(id, "PokemonLandNight7", fileName);
    //    mapa.LandNight[7] = GetProperties2(id, "PokemonLandNight8", fileName);
    //    mapa.LandNight[8] = GetProperties2(id, "PokemonLandNight9", fileName);
    //    mapa.LandNight[9] = GetProperties2(id, "PokemonLandNight10", fileName);
    //    mapa.LandNight[10] = GetProperties2(id, "PokemonLandNight11", fileName);
    //    mapa.LandNight[11] = GetProperties2(id, "PokemonLandNight12", fileName);

    //    mapa.Cave[0] = GetProperties2(id, "PokemonCave1", fileName);
    //    mapa.Cave[1] = GetProperties2(id, "PokemonCave2", fileName);
    //    mapa.Cave[2] = GetProperties2(id, "PokemonCave3", fileName);
    //    mapa.Cave[3] = GetProperties2(id, "PokemonCave4", fileName);
    //    mapa.Cave[4] = GetProperties2(id, "PokemonCave5", fileName);
    //    mapa.Cave[5] = GetProperties2(id, "PokemonCave6", fileName);
    //    mapa.Cave[6] = GetProperties2(id, "PokemonCave7", fileName);
    //    mapa.Cave[7] = GetProperties2(id, "PokemonCave8", fileName);
    //    mapa.Cave[8] = GetProperties2(id, "PokemonCave9", fileName);
    //    mapa.Cave[9] = GetProperties2(id, "PokemonCave10", fileName);
    //    mapa.Cave[10] = GetProperties2(id, "PokemonCave11", fileName);
    //    mapa.Cave[11] = GetProperties2(id, "PokemonCave12", fileName);

    //    mapa.Water[0] = GetProperties2(id, "PokemonWater1", fileName);
    //    mapa.Water[1] = GetProperties2(id, "PokemonWater2", fileName);
    //    mapa.Water[2] = GetProperties2(id, "PokemonWater3", fileName);
    //    mapa.Water[3] = GetProperties2(id, "PokemonWater4", fileName);
    //    mapa.Water[4] = GetProperties2(id, "PokemonWater5", fileName);

    //    mapa.RockSmash[0] = GetProperties2(id, "PokemonRockSmash1", fileName);
    //    mapa.RockSmash[1] = GetProperties2(id, "PokemonRockSmash2", fileName);
    //    mapa.RockSmash[2] = GetProperties2(id, "PokemonRockSmash3", fileName);
    //    mapa.RockSmash[3] = GetProperties2(id, "PokemonRockSmash4", fileName);
    //    mapa.RockSmash[4] = GetProperties2(id, "PokemonRockSmash5", fileName);

    //    mapa.OldRod[0] = GetProperties2(id, "PokemonOldRod1", fileName);
    //    mapa.OldRod[1] = GetProperties2(id, "PokemonOldRod2", fileName);

    //    mapa.GoodRod[0] = GetProperties2(id, "PokemonGoodRod1", fileName);
    //    mapa.GoodRod[1] = GetProperties2(id, "PokemonGoodRod2", fileName);
    //    mapa.GoodRod[2] = GetProperties2(id, "PokemonGoodRod3", fileName);

    //    mapa.SuperRod[0] = GetProperties2(id, "PokemonSuperRod1", fileName);
    //    mapa.SuperRod[1] = GetProperties2(id, "PokemonSuperRod2", fileName);
    //    mapa.SuperRod[2] = GetProperties2(id, "PokemonSuperRod3", fileName);
    //    mapa.SuperRod[3] = GetProperties2(id, "PokemonSuperRod4", fileName);
    //    mapa.SuperRod[4] = GetProperties2(id, "PokemonSuperRod5", fileName);

    //    mapa.HeadbuttLow[0] = GetProperties2(id, "PokemonHeadbuttLow1", fileName);
    //    mapa.HeadbuttLow[1] = GetProperties2(id, "PokemonHeadbuttLow2", fileName);
    //    mapa.HeadbuttLow[2] = GetProperties2(id, "PokemonHeadbuttLow3", fileName);
    //    mapa.HeadbuttLow[3] = GetProperties2(id, "PokemonHeadbuttLow4", fileName);
    //    mapa.HeadbuttLow[4] = GetProperties2(id, "PokemonHeadbuttLow5", fileName);
    //    mapa.HeadbuttLow[5] = GetProperties2(id, "PokemonHeadbuttLow6", fileName);
    //    mapa.HeadbuttLow[6] = GetProperties2(id, "PokemonHeadbuttLow7", fileName);
    //    mapa.HeadbuttLow[7] = GetProperties2(id, "PokemonHeadbuttLow8", fileName);

    //    mapa.HeadbuttHigh[0] = GetProperties2(id, "PokemonHeadbuttHigh1", fileName);
    //    mapa.HeadbuttHigh[1] = GetProperties2(id, "PokemonHeadbuttHigh2", fileName);
    //    mapa.HeadbuttHigh[2] = GetProperties2(id, "PokemonHeadbuttHigh3", fileName);
    //    mapa.HeadbuttHigh[3] = GetProperties2(id, "PokemonHeadbuttHigh4", fileName);
    //    mapa.HeadbuttHigh[4] = GetProperties2(id, "PokemonHeadbuttHigh5", fileName);
    //    mapa.HeadbuttHigh[5] = GetProperties2(id, "PokemonHeadbuttHigh6", fileName);
    //    mapa.HeadbuttHigh[6] = GetProperties2(id, "PokemonHeadbuttHigh7", fileName);
    //    mapa.HeadbuttHigh[7] = GetProperties2(id, "PokemonHeadbuttHigh8", fileName); 


    //}
    //public IEnumerator savePKMNs()
    //{
    //    SaveLoad.Load();
    //    yield return new WaitForSeconds(5);
    //    Debug.Log("mic");
    //    for (int i = 1; i < 15; i++)
    //    {
    //        Debug.Log("mec");
     
    //    Pokemon pokemon = new Pokemon();
    //    WWW www = new WWW("http://pokeapi.co/api/v2/pokemon" + i + "/");
    //    yield return www;
    //    Debug.Log(www.text);
    //    JsonData data = JsonMapper.ToObject(www.text);
    //   pokemon.Nombre = data["name"].ToString();

    //    if (data["types"].Count > 1)
    //    {
    //        pokemon.Tipo1 = data["types"][1]["type"]["name"].ToString();
    //        pokemon.Tipo2 = data["types"][0]["type"]["name"].ToString();
    //    }
    //    else
    //    {
    //        pokemon.Tipo1 = data["types"][0]["type"]["name"].ToString();
    //        pokemon.Tipo2 = "NONE";
    //    }
    //    Partida.actual.pokedex.Add(pokemon);
    //    }
    //    Debug.Log("MOC");
    //    File.WriteAllText(Application.persistentDataPath + "/pokemon.txt", JsonMapper.ToJson(Partida.actual.pokedex).ToString());
    //    // yield return new WaitForSeconds(1);
    //}

    public void loadPokemons()
    {
         JsonData data = JsonMapper.ToObject(File.ReadAllText(Application.persistentDataPath + "/pokemon.txt"));
        //List<Pokemon> pokemons = JsonMapper.ToObject<List<Pokemon>>(File.ReadAllText(Application.persistentDataPath + "/pokemon.txt"));
        // Debug.Log(data[0]["Nombre"]);

        List<Pokemon> pokemons = new List<Pokemon>();
          pokemons = JsonMapper.ToObject<List<Pokemon>>(data.ToJson().ToString());
     //   Debug.Log(data[0].ToJson().ToString());
        //Pokemon p = new Pokemon();
        //Debug.Log()
        //pokemons = JsonMapper.ToObject<List<Pokemon>>(File.ReadAllText(Application.persistentDataPath + "/pokemon.txt"));// data[0].ToJson().ToString());
        //string fileName = "pokemon.txt";
        //Debug.Log("MOC");
        //for(int i = 0;i<14; i++)
        //{
        //    Partida.actual.pokedex[i].nombre = data[i]["Nombre"].ToString();
        //    Partida.actual.pokedex[i].id =  Convert.ToInt32(data[i]["id"].ToString());
        //    Partida.actual.pokedex[i].tipo1 = data[i]["tipo1"].ToString();
        //    Partida.actual.pokedex[i].tipo2 = data[i]["tipo2"].ToString();
        //}
        //for (int i = 0;i < 14; i++)
        //{
        //    p.nombre = data[i]["Nombre"].ToString();
        //    Partida.actual.pokedex.Add(p);
        //    Debug.Log(Partida.actual.pokedex[i].nombre);
        //    Partida.actual.pokedex = new List<Pokemon>(JsonMapper.ToObject<List<Pokemon>>(data[i].ToJson().ToString()));
        //   // JsonMapper.ToObject<List<Pokemon>>(data[i].ToJson().ToString()).CopyTo(Partida.actual.pokedex.ToArray());
        //    // pokemons.Add(JsonMapper.ToObject<Pokemon>(data[i].ToJson().ToString()));
        //}
        Debug.Log(pokemons[0].nombre.ToString());
     
      //  Partida.actual.pokedex = new List<Pokemon>();
        //  Partida.actual.pokedex = JsonMapper.ToObject<List<Pokemon>>(data.ToJson().ToString());
     //   Debug.Log(Partida.actual.pokedex[0].tipo1);
        //StreamReader theReader = new StreamReader(Application.dataPath + "/Data/" + fileName, Encoding.Default);

        //try
        //{
        //    using (theReader)
        //    {
        //        do
        //        {
        //            Pokemon pokemon = new Pokemon();
        //            line = theReader.ReadLine();            
        //            if (line != null && line.StartsWith("["))
        //            {
        //                line = theReader.ReadLine();
        //            }

        //            do
        //                {
        //                    // Debug.Log(prop + ": " + line + "; " + line.IndexOf(prop));
        //                    //Debug.Log(line.Substring(0, line.IndexOf("=")));
        //                    if (line.Substring(0, line.IndexOf("=")).Equals("Name"))
        //                    {
        //                        Debug.Log(line.Substring(0, "Name".Length));
        //                       pokemon.Nombre = line.Substring(line.IndexOf("=") + 1, line.Length - (line.IndexOf("=") + 1));
        //                    Debug.Log(pokemon.Nombre);
        //                    }
        //                    else if (line.Substring(0, line.IndexOf("=")) == "InternalName")
        //                    {
        //                        Debug.Log(line.Substring(0, "InternalName".Length));
        //                        pokemon.Internal_name = line.Substring(line.IndexOf("=") + 1, line.Length - (line.IndexOf("=") + 1));
        //                        Debug.Log("SDFSA ");
        //                    }
        //else if (line.Substring(0, line.IndexOf("=")) == "Type1")
        //{
        //    Debug.Log("Type1");
        //    pokemon.Tipo1 = line.Substring(line.IndexOf("=") + 1, line.Length - (line.IndexOf("=") + 1));

        //}
        //else if (line.Substring(0, line.IndexOf("=")) == "Type2")
        //{
        //    Debug.Log("Type2");
        //    pokemon.Tipo2 = line.Substring(line.IndexOf("=") + 1, line.Length - (line.IndexOf("=") + 1));

        //}
        //else if (line.Substring(0, line.IndexOf("=")) == "BaseStats")
        //{
        //    Debug.Log("BASESTATS");
        //    pokemon.SetStats(line.Substring(line.IndexOf("=") + 1, line.Length - (line.IndexOf("=") + 1)));

        //}
        //if (line.Substring(0, line.IndexOf("=")) == "GenderRate")
        //{
        //    Debug.Log("GENDERATE");
        //    pokemon.Ratio_sexo = line.Substring(line.IndexOf("=") + 1, line.Length - (line.IndexOf("=") + 1));

        //}
        //else if (line.Substring(0, line.IndexOf("=")) == "GrowthRate")
        //{
        //    pokemon.Ratio_nivel = line.Substring(line.IndexOf("=") + 1, line.Length - (line.IndexOf("=") + 1));

        //}
        //else if (line.Substring(0, line.IndexOf("=")) == "BaseEXP")
        //{
        //    pokemon.Exp_base = line.Substring(line.IndexOf("=") + 1, line.Length - (line.IndexOf("=") + 1));

        //}
        //else if (line.Substring(0, line.IndexOf("=")) == "EffortPoints")
        //{
        //    pokemon.SetEVStats(line.Substring(line.IndexOf("=") + 1, line.Length - (line.IndexOf("=") + 1)));

        //}
        //else if (line.Substring(0, line.IndexOf("=")) == "Rareness")
        //{
        //    pokemon.Ratio_captura = Convert.ToInt32(line.Substring(line.IndexOf("=") + 1, line.Length - (line.IndexOf("=") + 1)));

        //}
        //else if (line.Substring(0, line.IndexOf("=")) == "Happiness")
        //{
        //    pokemon.Felicidad_base = Convert.ToInt32(line.Substring(line.IndexOf("=") + 1, line.Length - (line.IndexOf("=") + 1)));

        //}
        //else if (line.Substring(0, line.IndexOf("=")) == "Moves")
        //{
        //    Debug.Log("MOVES");
        //    pokemon.SetMoves(line.Substring(line.IndexOf("=") + 1, line.Length - (line.IndexOf("=") + 1)));

        //}
        //else if (line.Substring(0, line.IndexOf("=")) == "StepsToHatch")
        //{
        //    pokemon.Pasos_huevo = Convert.ToInt32(line.Substring(line.IndexOf("=") + 1, line.Length - (line.IndexOf("=") + 1)));

        //}
        //else if (line.Substring(0, line.IndexOf("=")) == "Height")
        //{
        //    pokemon.Altura = Convert.ToDecimal(line.Substring(line.IndexOf("=") + 1, line.Length - (line.IndexOf("=") + 1)));

        //}
        //else if (line.Substring(0, line.IndexOf("=")) == "Weight")
        //{
        //    pokemon.Peso = Convert.ToDecimal(line.Substring(line.IndexOf("=") + 1, line.Length - (line.IndexOf("=") + 1)));

        //}
        //else if (line.Substring(0, line.IndexOf("=")) == "Color")
        //{
        //    pokemon.Color = line.Substring(line.IndexOf("=") + 1, line.Length - (line.IndexOf("=") + 1));

        //}
        //else if (line.Substring(0, line.IndexOf("=")) == "Kind")
        //{
        //    pokemon.Especie = line.Substring(line.IndexOf("=") + 1, line.Length - (line.IndexOf("=") + 1));

        //}
        //else if (line.Substring(0, line.IndexOf("=")) == "Pokedex")
        //{
        //    pokemon.Desc_pokedex = line.Substring(line.IndexOf("=") + 1, line.Length - (line.IndexOf("=") + 1));

        //}
        //else if (line.Substring(0, line.IndexOf("=")) == "Abilities")
        //{
        //    pokemon.Habilidad = line.Substring(line.IndexOf("=") + 1, line.Length - (line.IndexOf("=") + 1));

        //}
        //else if (line.Substring(0, line.IndexOf("=")) == "HiddenAbility")
        //{
        //    pokemon.Habilidad_oculta = line.Substring(line.IndexOf("=") + 1, line.Length - (line.IndexOf("=") + 1));

        //}
        //else if (line.Substring(0, line.IndexOf("=")) == "EggMoves")
        //{
        //    pokemon.SetEGGMoves(line.Substring(line.IndexOf("=") + 1, line.Length - (line.IndexOf("=") + 1)));

        //}
        //else if (line.Substring(0, line.IndexOf("=")) == "Habitat")
        //{
        //    pokemon.Habitat = line.Substring(line.IndexOf("=") + 1, line.Length - (line.IndexOf("=") + 1));

        //}
        //else if (line.Substring(0, line.IndexOf("=")) == "RegionalNumbers")
        //{
        //    Debug.Log("REGIONALNUMBERS");
        //    pokemon.SetPokedexNums(line.Substring(line.IndexOf("=") + 1, line.Length - (line.IndexOf("=") + 1)));

        //}
        //else if (line.Substring(0, line.IndexOf("=")) == "WildItemCommon")
        //{
        //    pokemon.Objeto_habitual = line.Substring(line.IndexOf("=") + 1, line.Length - (line.IndexOf("=") + 1));

        //}
        //else if (line.Substring(0, line.IndexOf("=")) == "WildItemUncommon")
        //{
        //    pokemon.Objeto_pocohab = line.Substring(line.IndexOf("=") + 1, line.Length - (line.IndexOf("=") + 1));

        //}
        //else if (line.Substring(0, line.IndexOf("=")) == "WildItemRare")
        //{
        //    pokemon.Objeto_raro = line.Substring(line.IndexOf("=") + 1, line.Length - (line.IndexOf("=") + 1));

        //}
        //else if (line.Substring(0, line.IndexOf("=")) == "BattlerPlayerY")
        //{
        //    pokemon.BattlerPlayerY1 = Convert.ToInt32(line.Substring(line.IndexOf("=") + 1, line.Length - (line.IndexOf("=") + 1)));

        //}
        //else if (line.Substring(0, line.IndexOf("=")) == "BattlerEnemyY")
        //{
        //    pokemon.BattlerEnemyY1 = Convert.ToInt32(line.Substring(line.IndexOf("=") + 1, line.Length - (line.IndexOf("=") + 1)));

        //}
        //else if (line.Substring(0, line.IndexOf("=")) == "BattlerAltitude")
        //{
        //    pokemon.BattlerAltitude1 = Convert.ToInt32(line.Substring(line.IndexOf("=") + 1, line.Length - (line.IndexOf("=") + 1)));

        //}
        //else if (line.Substring(0, line.IndexOf("=")) == "Evolutions")
        //{
        //    pokemon.SetEvolutionForm(line.Substring(line.IndexOf("=") + 1, line.Length - (line.IndexOf("=") + 1)));

        //}
        //else if (line.Substring(0, line.IndexOf("=")) == "FormNames")
        //{
        //    pokemon.SetFormsPKMN(line.Substring(line.IndexOf("=") + 1, line.Length - (line.IndexOf("=") + 1)));
        //                //}
        //                Debug.Log(line);
        //                Debug.Log("ABANS readline");
        //                line = theReader.ReadLine();
        //                if(line == null)
        //                {
        //                    break;
        //                }
        //                Debug.Log("despres readline");
        //            } while (!line.StartsWith("[") && line != null);

        //            if (pokemon != null)
        //            {
        //                Debug.Log("ABANS add");
        //                pokemons.Add(pokemon);
        //            }
        //                // Do whatever you need to do with the text line, it's a string now
        //                // In this example, I split it into arguments based on comma
        //                // deliniators, then send that array to DoStuff()



        //        }
        //        while (line != null);
        //        // Done reading, close the reader and return true to broadcast success    
        //        theReader.Close();
        //        Debug.Log("ABANS RETURN");
        //        return pokemons;
        //    }
        //}
        //catch (Exception e)
        //{
        //    Debug.Log((e.Message));
        //    return null;
        //}
        //finally
        //{
        //    theReader.Close();
        //}

    }



}
