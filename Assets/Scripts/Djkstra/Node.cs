using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node
{
    public int id;
    public bool walkable;
    public Vector3 worldPos;


    public int xPos;
    public int yPos;
    
    public Node(int _id, bool _walkable, Vector3 _worldPos, int _xPos, int _yPos)
    {
        id = _id;
        xPos = _xPos;
        yPos = _yPos;
        walkable = _walkable;
        worldPos = _worldPos;
    }


}
