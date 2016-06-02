using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class CategoriaMovimiento {
    public int id;
    public string internal_name;
    public string nombre;
    public string descripcion;
    public List<int> movimientos = new List<int>();

    public CategoriaMovimiento()
    {

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
}
