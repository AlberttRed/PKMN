using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using LitJson;
using System;



public class SaveLoad  {

   // public static List<Partida> savedGames = new List<Partida>();
   
    public static void Save()
    {
        // savedGames.Add(Partida.actual);
        //      BinaryFormatter bf = new BinaryFormatter();
        //  FileStream file = File.Create(Application.persistentDataPath + "/savedGames.gd");
        //Mec q = new Mec(1, 2, 3);
        List<Pokemon> m = new List<Pokemon>();
        Pokemon  a = new Pokemon();
        m.Add(a);
        Partida par = Partida.actual;

        Partida.actual = null;
        File.WriteAllText(Application.dataPath + "/metadataPKMN/savedGame.txt", JsonMapper.ToJson(par).ToString());
        Partida.actual = par;
        //   bf.Serialize(file, SaveLoad.savedGames);

    }

    public static void Load()
    {
        //if (File.Exists(Application.persistentDataPath + "/savedGame.txt"))
        //{
        //persistentdatapath
        JsonData categorias = JsonMapper.ToObject(File.ReadAllText(Application.dataPath + "/metadataPKMN/CategoriasMovimientos.txt"));
        JsonData partida = JsonMapper.ToObject(File.ReadAllText(Application.dataPath + "/metadataPKMN/savedGame.txt"));
        JsonData tipos = JsonMapper.ToObject(File.ReadAllText(Application.dataPath + "/metadataPKMN/types.txt"));
        JsonData objetos = JsonMapper.ToObject(File.ReadAllText(Application.dataPath + "/metadataPKMN/objetos.txt"));
        JsonData movimientos = JsonMapper.ToObject(File.ReadAllText(Application.dataPath + "/metadataPKMN/movimientos.txt"));
        JsonData pokemons = JsonMapper.ToObject(File.ReadAllText(Application.dataPath + "/metadataPKMN/pokemon.txt"));
        //Debug.Log(data.ToJson().ToString());

        //List<Pokemon> p = new List<Pokemon>();
        //JsonMapper.ToObject<List<Pokemon>>(data.ToJson().ToString()).CopyTo(p.ToArray());     
        //   Debug.Log(p[0].nombre);
        // JsonData data = JsonMapper.ToObject(File.ReadAllText(Application.persistentDataPath + "/pokemon.txt"));
        //BinaryFormatter bf = new BinaryFormatter();
        //FileStream file = File.Open(Application.persistentDataPath + "/savedGames.gd", FileMode.Open);

        Datos.categorias = JsonMapper.ToObject<List<CategoriaMovimiento>>(categorias.ToJson().ToString());
        Datos.tipos = JsonMapper.ToObject<List<Tipo>>(tipos.ToJson().ToString());
        Datos.objetos = JsonMapper.ToObject<List<Objeto>>(objetos.ToJson().ToString());
        Datos.movimientos = JsonMapper.ToObject<List<Movimiento>>(movimientos.ToJson().ToString());
        Datos.pokemons = JsonMapper.ToObject<List<Pokemon>>(pokemons.ToJson().ToString());
        //    Debug.Log(Partida.actual.pokedex[4].nombre);
        Partida.actual = new Partida(partida["nombre_rival"].ToString(), (Int32)partida["horas"], Datos.pokemons);//, MiJson["nombre_jugador"].ToString(), (MiJson["sexo"]).ToString(), Convert.ToInt32(MiJson["trainer_id"]));
        Debug.Log(Datos.tipos[0].nombre);
        Debug.Log(Partida.actual.pokedex[0].nombre);
        //Debug.Log(data[0]["Nombre"]);
        //file.Close();
        //}
    }
}
