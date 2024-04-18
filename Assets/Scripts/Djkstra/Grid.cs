using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;


public class Grid : MonoBehaviour
{
    // public Transform player;
    public Tilemap terreno;
    public LayerMask walkableMask;
    public LayerMask unwalkableMask;
    public bool useZAxis = false;
    public Vector2 gridWorldSize;
    public float nodeRadius;
    Node[,] grid;
    private int contador;

    float nodeDiameter;
    int gridSizeX, gridSizeY;

    void Start()
    {
        contador = 1;
        nodeDiameter = nodeRadius * 2;
        gridSizeX = Mathf.RoundToInt(gridWorldSize.x / nodeDiameter);
        gridSizeY = Mathf.RoundToInt(gridWorldSize.y / nodeDiameter);
        CreateGrid();
    }

    void CreateGrid()
    {
        grid = new Node[gridSizeX, gridSizeY];
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
                    grid[x, y] = new Node(contador++, true, worldPoint, x, y);
            }
        }
    }   

    public Node NodeFromWorldPoint(Vector3 worldPosition)
    {
        float percentX = (worldPosition.x + gridWorldSize.x / 2) / gridWorldSize.x;
        float percentY = (worldPosition.z + gridWorldSize.y / 2) / gridWorldSize.y;
        percentX = Mathf.Clamp01(percentX);
        percentY = Mathf.Clamp01(percentY);

        int x = Mathf.RoundToInt((gridSizeX - 1) * percentX);
        int y = Mathf.RoundToInt((gridSizeY - 1) * percentY);
        return grid[x, y];
    }

    public List<Node> GetNeighbours(Node node)
    {
        List<Node> list = new List<Node>();

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
    public List<int[]> GetPosNeighbours(Node node)
    {
        List<int[]> list = new List<int[]>();

        for (int x = -1; x <= 1; x++)
        {
            for (int y = -1; y <= 1; y++)
            {
                if (x == 0 && y == 0) continue;

                int vizinhoX = node.xPos + x;
                int vizinhoY = node.yPos + y;

                if (vizinhoX >= 0 && vizinhoX < gridSizeX && vizinhoY >= 0 && vizinhoY < gridSizeY)
                {
                    int[] posVizinho = new int[2];
                    posVizinho[0] = vizinhoX;
                    posVizinho[1] = vizinhoY;
                    list.Add( posVizinho );
                }

            }
        }
        return list;
    }


    void OnDrawGizmos()
    {
        if(useZAxis) Gizmos.DrawWireCube(transform.position, new Vector3(gridWorldSize.x, gridWorldSize.y, 1));
        else Gizmos.DrawWireCube(transform.position, new Vector3(gridWorldSize.x, 1, gridWorldSize.y));


        if (grid != null)
        {
            foreach (Node n in grid)
            {
                // Node playerNode = NodeFromWorldPoint(player.position);
                if (n != null)
                {
                    Gizmos.color = (n.walkable) ? Color.white : Color.red;
                    //if (n == playernode)
                    //{
                    //    gizmos.color = color.green;
                    //}
                    foreach (Node v in GetNeighbours(n))
                    {
                        if (n == v) Gizmos.color = Color.yellow;
                        

                    }


                    Gizmos.DrawCube(n.worldPos, Vector3.one * (nodeDiameter - .1f));
                }
            }
        }
    }
}