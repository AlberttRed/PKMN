using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

[System.Serializable]
public class Tipo
{

    public int id;
    public CategoriaMovimiento categoria;
    public List<int> pokemons = new List<int>();
    public List<int> movimientos = new List<int>();
    public string nombre;
    public string internal_name;

    public List<int> weakness = new List<int>();
    public List<int> resistances = new List<int>();
    public List<int> immunities = new List<int>();



    public Tipo()
    {

    }

    public List<Pokemon> Pokemons()
    {
        List<Pokemon> p = new List<Pokemon>();
        foreach (int id in pokemons)
        {
            IEnumerable<Pokemon> pkmns = from pkmn in Partida.actual.pokedex
                                         where pkmn.id == id
                                         select pkmn;
            p.Add(pkmns.FirstOrDefault());
        }
        return p;
    }

    public List<Movimiento> Movimientos()
    {
        List<Movimiento> m = new List<Movimiento>();
        foreach (int id in movimientos)
        {
            IEnumerable<Movimiento> moves = from move in Datos.movimientos
                                         where move.id == id
                                         select move;
            m.Add(moves.FirstOrDefault());
        }
        return m;
    }

    public float GetDamage(Tipo t)
    {
        float daño;
        IEnumerable<int> tipos = from tipo in weakness
                                        where tipo == t.id
                                        select tipo;
       
        if(tipos.Count() == 0)
        {
                    tipos = from tipo in resistances
                                    where tipo == t.id
                                    select tipo;
            if (tipos.Count() == 0)
            {
                tipos = from tipo in immunities
                        where tipo == t.id
                        select tipo;
                if (tipos.Count() == 0)
                {
                    daño = 1;
                }
                else
                {
                    daño = 0;
                }

                }
            else
            {
                daño = 0.5f;
            }

        }
        else
        {
            daño = 2;
        }
        return daño;   
    }

    //public CategoriaMovimiento Categoria()
    //{
       
    //        IEnumerable<CategoriaMovimiento> catgris = from catgri in Datos.categorias
    //                                     where catgri.id == categoria
    //                                     select catgri;

    //    return catgris.FirstOrDefault();

    //}

}
