using UnityEngine;
using System.Collections;
using System.Collections.Generic;




 public class Partida {
    
    public static Partida actual;
    public int horas;
    //char minutos, segundos, milisegundos;
   // public Player p;
    public string nombre_rival;
    //int pasos_huevo;
    //int pasos_veneno;
    public static int pasos_wild;
    //short currentMapX;
    //short currentMapY;
    //short currentMap;
    //int objeto_select;
    public List<Pokemon> pokedex;
    //dades pokedex
    //char[] pokemon_vistos;
    //char[] pokemon_atrapados;

 

    public Partida(string nombre_rival, int horas, List<Pokemon> pokedex)//, string nombre_jugador, string sexo, int trainer_id)
    {
        this.nombre_rival = nombre_rival;
        this.horas = horas;
        this.pokedex = pokedex;
     //   this.pokedex = pokedex;
        //p = GameObject.Find("Player").GetComponent<Player>();
        //this.p.Nombre = nombre_jugador.ToString();
        //this.p.Sexo = sexo;
        //this.p.Trainer_id = trainer_id;
        //this.p.Pos = p.transform.position;
    }


}
