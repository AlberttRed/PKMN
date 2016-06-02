using UnityEngine;
using System.Collections;
using LitJson;
using System.IO;

[System.Serializable]
public class Movimiento  {

    public int id;
    public string internal_name;
    public string nombre;
    public string function_code;
    public int potencia;
    public Tipo tipo;
    public CategoriaMovimiento categoria; //fisico, especial, de estado
    public int precision;
    public int PP;
    public int probabilidad_efecto; //Hi ha atacs, com ascuas, que a vegades cremen. Quina probabilitat hi ha de que ho fagin.
    public int target;
    public int prioridad;
    public int efecto;
    public int min_golpes;
    public int max_golpes;
    public int min_turns;
    public int max_turns;
    public int sumaresta_vida;
    public int curavida;
    public int ratio_critico;
    public int ratio_retroceso;
    
   // public string flags;
    public string descripcion;
   
    public Movimiento()
    {

    }
    // Use this for initialization
   
    // Update is called once per frame
    void Update () {
	
	}
}
