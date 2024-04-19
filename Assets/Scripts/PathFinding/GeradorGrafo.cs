using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;


public class GeradorGrafo : MonoBehaviour
{
    // Com base no metodo de armazenamentos de grafo em matriz fisica apresentado por Sebastian Lague https://github.com/SebLague/Pathfinding/blob/master/Episode%2002%20-%20grid/Assets/Grid.cs
    // public Transform player;
    public Tilemap terreno;
    public LayerMask mascaraAndavel;
    public LayerMask mascaraColisivel;
    public bool useZAxis = false;
    public Vector2 gridWorldSize;
    public float raioVertice;
    public Transform player;
    Vertice[,] grid;


    float verticeDiametro;
    int gridSizeX, gridSizeY;
    int contador;

    public float gridSize
    {
        get { return (gridSizeX * gridSizeY); }
    }

    void Start()
    {
        contador = 0;
        verticeDiametro = raioVertice * 2;
        gridSizeX = Mathf.RoundToInt(gridWorldSize.x / verticeDiametro);
        gridSizeY = Mathf.RoundToInt(gridWorldSize.y / verticeDiametro);
        CreateGrid();
    }

    void CreateGrid()
    {
        grid = new Vertice[gridSizeX, gridSizeY];
        Vector3 direcao2 = (useZAxis ? Vector3.up : Vector3.forward);
        Vector3 worldBottomLeft = transform.position - Vector3.right * gridWorldSize.x / 2 - direcao2 * gridWorldSize.y / 2;
        

        for (int x = 0; x < gridSizeX; x++)
        {
            for (int y = 0; y < gridSizeY; y++)
            {
                Vector3 worldPoint = worldBottomLeft + Vector3.right * (x * verticeDiametro + raioVertice) + direcao2 * (y * verticeDiametro + raioVertice);


                // Vector3Int teste = new Vector3Int((int)worldPoint.x, (int)worldPoint.y, (int)worldPoint.z);
                bool outside = !(Physics2D.OverlapPoint((Vector2)worldPoint, mascaraAndavel));
                bool walkable = (Physics2D.OverlapBox((Vector2)worldPoint, new Vector2(raioVertice, raioVertice), 0, mascaraColisivel) == null);


                if (!outside)
                {
                    grid[x, y] = new Vertice(contador++, walkable, worldPoint, x, y);
                }
            }
        }
    }   

    public Vertice GetVerticeFromPosition(Vector3 worldPosition)
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

    public List<Vertice> GetVizinhos(Vertice node)
    {
        List<Vertice> list = new List<Vertice>();

        for(int x = -1; x <= 1; x++)
        {
            for(int y = -1; y <= 1; y++)
            {
                // if (x == 0 && y == 0) continue;
                if (Math.Abs(x) == Math.Abs(y)) continue;

                    int vizinhoX = node.xPos + x;
                    int vizinhoY = node.yPos + y;

                    if(vizinhoX >= 0 && vizinhoX < gridSizeX && vizinhoY >= 0 && vizinhoY < gridSizeY)
                    {
                        if (grid[vizinhoX, vizinhoY] != null && grid[vizinhoX, vizinhoY].walkable) list.Add(grid[vizinhoX,vizinhoY]);
                    }
                
            }
        }
        return list;
    }


    public Vertice GetVertice(int v)
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
    public List<int> GetVizinhos(int vertice)
    {
        Vertice node = GetVertice(vertice);

        if (node == null)
        {
            throw new Exception("Vertice não existente");

        }

        List<int> list = new List<int>();

        for (int x = -1; x <= 1; x++)
        {
            for (int y = -1; y <= 1; y++)
            {
                //if (x == 0 && y == 0) continue;
                if (Math.Abs(x) == Math.Abs(y)) continue;

                int vizinhoX = node.xPos + x;
                int vizinhoY = node.yPos + y;

                if (vizinhoX >= 0 && vizinhoX < gridSizeX && vizinhoY >= 0 && vizinhoY < gridSizeY)
                {
                    if(grid[vizinhoX, vizinhoY] != null && grid[vizinhoX, vizinhoY].walkable) list.Add( grid[vizinhoX,vizinhoY].id );
                }

            }
        }
        return list;
    }


    public Stack<Vertice> caminho;
    public List<int> caminhoBuilding;
    void OnDrawGizmos()
    {
        if(useZAxis) Gizmos.DrawWireCube(transform.position, new Vector3(gridWorldSize.x, gridWorldSize.y, 1));
        else Gizmos.DrawWireCube(transform.position, new Vector3(gridWorldSize.x, 1, gridWorldSize.y));


        if (grid != null)
        {
            foreach (Vertice n in grid)
            {
                Vertice playernode = GetVerticeFromPosition(player.position);
                if (n != null)
                {
                  Gizmos.color = (n.walkable) ? Color.white : Color.red;
                    if (n == playernode)
                    {
                        Gizmos.color = Color.green;
                    }
                    foreach (Vertice v in GetVizinhos(playernode))
                    {
                        if (n == v) Gizmos.color = Color.yellow;
                    }
                    if (caminho != null)
                    {
                        //if (caminhoBuilding.Contains(n.id))
                        //{
                        //    Gizmos.color = Color.cyan;
                        //}
                        if (caminho.Contains(n))
                        {
                            Gizmos.color = Color.black;
                        }
                    }
                    Gizmos.DrawCube(n.worldPos, Vector3.one * (verticeDiametro - .1f));
                    
                }

            }
        }
    }
}