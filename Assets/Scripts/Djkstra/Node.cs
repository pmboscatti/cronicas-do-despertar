using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node
{
    public bool walkable;
    public Vector3 worldPos;


    public int xPos;
    public int yPos;
    
    public Node(bool _walkable, Vector3 _worldPos, int _xPos, int _yPos)
    {
        xPos = _xPos;
        yPos = _yPos;
        walkable = _walkable;
        worldPos = _worldPos;
    }


}
