using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;


public class GeradorGrafo : MonoBehaviour
{
    // public Transform player;
    public Tilemap terreno;
    public LayerMask walkableMask;
    public LayerMask unwalkableMask;
    public bool useZAxis = false;
    public Vector2 gridWorldSize;
    public float nodeRadius;
    public Transform player;
    Vertice[,] grid;


    float nodeDiameter;
    float gridSizeX, gridSizeY;
    int contador;

    public float gridSize
    {
        get { return (gridSizeX * gridSizeY); }
    }

    void Start()
    {
        contador = 0;
        nodeDiameter = nodeRadius * 2;
        gridSizeX = Mathf.RoundToInt(gridWorldSize.x / nodeDiameter);
        gridSizeY = Mathf.RoundToInt(gridWorldSize.y / nodeDiameter);
        CreateGrid();
    }

    void CreateGrid()
    {
        grid = new Vertice[(int) gridSizeX, (int) gridSizeY];
        Vector3 direcao2 = (useZAxis ? Vector3.up : Vector3.forward);
        Vector3 worldBottomLeft = transform.position - Vector3.right * gridWorldSize.x / 2 - direcao2 * gridWorldSize.y / 2;
        

        for (int x = 0; x < gridSizeX; x++)
        {
            for (int y = 0; y < gridSizeY; y++)
            {
                Vector3 worldPoint = worldBottomLeft + Vector3.right * (x * nodeDiameter + nodeRadius) + direcao2 * (y * nodeDiameter + nodeRadius);

                //bool walkable = !(Physics.CheckSphere(worldPoint, nodeRadius, unwalkableMask));
                //bool outside = !(Physics.CheckSphere(worldPoint, nodeRadius, walkableMask));

                // bool walkable = Physics2D.IsTouching((Collider2D) this.GetComponent("Box Collider 2D"), (Collider2D) terreno.GetComponent("Box Collider 2D"));
                // bool outside = !(Physics2D.IsTouching((BoxCollider2D) this.GetComponent("Box Collider 2D"), (BoxCollider2D) terreno.GetComponent("Box Collider 2D")));
                //  if (walkable && outside) grid[x, y] = null;
                Vector3Int teste = new Vector3Int((int)worldPoint.x, (int)worldPoint.y, (int)worldPoint.z);
                bool outside = (terreno.GetTile(teste) == null);



                if (!outside)
                {
                    grid[x, y] = new Vertice(contador++, true, worldPoint, x, y);
                    print(grid[x, y].id);
                }
            }
        }
    }   

    public Vertice NodeFromWorldPoint(Vector3 worldPosition)
    {
        float percentX = (worldPosition.x + gridWorldSize.x / 2) / gridWorldSize.x;
        float d2 = (useZAxis ? worldPosition.y : worldPosition.z);
        float percentY = (d2 + gridWorldSize.y / 2) / gridWorldSize.y;
        percentX = Mathf.Clamp01(percentX);
        percentY = Mathf.Clamp01(percentY);

        int x = Mathf.RoundToInt((gridSizeX - 1) * percentX);
        int y = Mathf.RoundToInt((gridSizeY - 1) * percentY);
        return grid[x, y];
    }

    public List<Vertice> GetNeighbours(Vertice node)
    {
        List<Vertice> list = new List<Vertice>();

        for(int x = -1; x <= 1; x++)
        {
            for(int y = -1; y <= 1; y++)
            {
                if (x == 0 && y == 0) continue;
                
                    int vizinhoX = node.xPos + x;
                    int vizinhoY = node.yPos + y;

                    if(vizinhoX >= 0 && vizinhoX < gridSizeX && vizinhoY >= 0 && vizinhoY < gridSizeY)
                    {
                        list.Add(grid[vizinhoX,vizinhoY]);
                    }
                
            }
        }
        return list;
    }


    public Vertice getVertice(int v)
    {
        Vertice vertice = null;

        for (int i = 0; i < gridSizeX; i++)
        {
            for (int j = 0; j < gridSizeY; j++)
            {
                if (grid[i, j] != null && grid[i, j].id == v)
                {
                    vertice = grid[i, j];
                    break;
                }
            }
        }

        return vertice;

    }

    /// <summary>
    ///  
    /// </summary>
    /// <param name="vertice"></param>
    /// <returns></returns>
    /// <exception cref="Exception">Retorna exceção se o vertice não for encontrado</exception>
    public List<int> GetNeighbours(int vertice)
    {
        Vertice node = getVertice(vertice);

        if (node == null)
        {
            throw new Exception("Vertice não existente");

        }

        List<int> list = new List<int>();

        for (int x = -1; x <= 1; x++)
        {
            for (int y = -1; y <= 1; y++)
            {
                if (x == 0 && y == 0) continue;

                int vizinhoX = node.xPos + x;
                int vizinhoY = node.yPos + y;

                if (vizinhoX >= 0 && vizinhoX < gridSizeX && vizinhoY >= 0 && vizinhoY < gridSizeY)
                {
                    if(grid[vizinhoX, vizinhoY] != null) list.Add( grid[vizinhoX,vizinhoY].id );
                }

            }
        }
        return list;
    }


    public Stack<Vertice> caminho;
    void OnDrawGizmos()
    {
        if(useZAxis) Gizmos.DrawWireCube(transform.position, new Vector3(gridWorldSize.x, gridWorldSize.y, 1));
        else Gizmos.DrawWireCube(transform.position, new Vector3(gridWorldSize.x, 1, gridWorldSize.y));


        if (grid != null)
        {
            foreach (Vertice n in grid)
            {
                Vertice playernode = NodeFromWorldPoint(player.position);
                if (n != null)
                {
                  Gizmos.color = (n.walkable) ? Color.white : Color.red;
                    if (n == playernode)
                    {
                        Gizmos.color = Color.green;
                    }
                    foreach (Vertice v in GetNeighbours(playernode))
                    {
                        if (n == v) Gizmos.color = Color.yellow;
                    }
                    if (caminho != null)
                    {
                        if (caminho.Contains(n))
                        {
                            Gizmos.color = Color.black;
                        }
                    }
                    Gizmos.DrawCube(n.worldPos, Vector3.one * (nodeDiameter - .1f));
                }

            }
        }
    }
}