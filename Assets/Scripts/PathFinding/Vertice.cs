using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vertice : ItemHeap<Vertice>
{
    public bool walkable;
    public Vector3 worldPos;


    public int xPos;
    public int yPos;

    public int id;

    public int gCost;
    public int hCost;

    public Vertice pai;

    
    public Vertice(int id, bool _walkable, Vector3 _worldPos, int _xPos, int _yPos)
    {
        this.id = id;
        xPos = _xPos;
        yPos = _yPos;
        walkable = _walkable;
        worldPos = _worldPos;
    }

    public Vertice(bool _walkable, Vector3 _worldPos, int _xPos, int _yPos)
    {
        walkable = _walkable;
        worldPos = _worldPos;
        xPos = _xPos;
        yPos = _yPos;
    }

    public int fCost
    {
        get
        {
            return gCost + hCost;
        }
    }

    public int IndiceHeap { get; set; }

    public int CompareTo(Vertice other)
    {
        int compare = fCost.CompareTo(other.fCost);
        if(compare == 0)
        {
            compare = hCost.CompareTo(other.hCost);
        }

        return -compare;
    }
}
