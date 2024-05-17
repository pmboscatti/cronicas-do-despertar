using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vertice
{
    public bool walkable;
    public Vector3 worldPos;


    public int xPos;
    public int yPos;

    public int id;

    // Campos para A*
    public float g;
    public float h;
    public Vertice pai; // Vértice pai no caminho
    public List<Vertice> vizinhos; // Vizinhos deste ponto
    
    public Vertice(int id, bool _walkable, Vector3 _worldPos, int _xPos, int _yPos)
    {
        this.id = id;
        xPos = _xPos;
        yPos = _yPos;
        walkable = _walkable;
        worldPos = _worldPos;

        // Inicializa campos para A*
        g = Mathf.Infinity;
        h = 0;
        pai = null;
        vizinhos = new List<Vertice>();
    }


}
