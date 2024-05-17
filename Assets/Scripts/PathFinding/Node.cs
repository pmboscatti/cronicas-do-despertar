using System.Collections.Generic;
using UnityEngine;

public class Node
{
    public Vertice vertice;
    public float f;
    public float g;
    public float h;
    public Node pai;

    public Node(Vertice _vertice)
    {
        vertice = _vertice;
        f = 0;
        g = 0;
        h = 0;
        pai = null;
    }
}