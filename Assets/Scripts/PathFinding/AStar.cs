using System.Collections.Generic;
using UnityEngine;

public class AStar
{

    public List<Vertice> EncontrarCaminho(Vertice origem, Vertice destino)
    {
        List<Vertice> caminho = new List<Vertice>();

        // Criar nós para origem e destino
        Node startNode = new Node(origem);
        Node targetNode = new Node(destino);

        List<Node> abertos = new List<Node>();
        HashSet<Node> fechados = new HashSet<Node>();

        abertos.Add(startNode);

        while (abertos.Count > 0)
        {
            Node atual = abertos[0];
            for (int i = 1; i < abertos.Count; i++)
            {
                if (abertos[i].f < atual.f || (abertos[i].f == atual.f && abertos[i].h < atual.h))
                {
                    atual = abertos[i];
                }
            }

            abertos.Remove(atual);
            fechados.Add(atual);

            if (atual.vertice == destino)
            {
                caminho = RetracePath(startNode, atual);
                return caminho;
            }

            foreach (Vertice vizinho in atual.vertice.vizinhos)
            {
                Node vizinhoNode = new Node(vizinho);

                if (!vizinho.walkable || fechados.Contains(vizinhoNode))
                {
                    continue;
                }

                float novoG = atual.g + CalculateWeight(atual, vizinhoNode);
                if (novoG < vizinhoNode.g || !abertos.Contains(vizinhoNode))
                {
                    vizinhoNode.g = novoG;
                    vizinhoNode.h = HeuristicEuclidean(vizinho, destino);
                    vizinhoNode.pai = atual;

                    if (!abertos.Contains(vizinhoNode))
                    {
                        abertos.Add(vizinhoNode);
                    }
                }
            }
        }

        return caminho;
    }

    private List<Vertice> RetracePath(Node origem, Node destino)
    {
        List<Vertice> caminho = new List<Vertice>();
        Node atual = destino;

        while (atual != origem)
        {
            caminho.Add(atual.vertice);
            atual = atual.pai;
        }

        caminho.Reverse();
        return caminho;
    }

    private float CalculateWeight(Node origem, Node destino)
    {
        Vector2 origemPos = origem.vertice.worldPos;
        Vector2 destinoPos = destino.vertice.worldPos;

        Vector2 diff = destinoPos - origemPos;

        float distancia = diff.magnitude;

        if (Mathf.Approximately(distancia, 1f))
        {
            if (!CheckForCollisions(origemPos, destinoPos))
            {
                return 10f; // Sem colisões, peso 10
            }
            else
            {
                return Mathf.Infinity; // Com colisões, peso infinito (não é possível atravessar)
            }
        }
        else if (Mathf.Approximately(distancia, Mathf.Sqrt(2)))
        {
            if (!CheckForCollisions(origemPos, destinoPos))
            {
                return 14f; // Sem colisões, peso 14
            }
            else
            {
                return Mathf.Infinity; // Com colisões, peso infinito (não é possível atravessar)
            }
        }
        else
        {
            return Mathf.Infinity; // Qualquer outra distância é considerada intransponível
        }
    }

    private bool CheckForCollisions(Vector2 start, Vector2 end)
    {
        // Lança um raio entre os pontos de início e fim para verificar colisões
        RaycastHit2D hit = Physics2D.Linecast(start, end);

        // Se o raio atingir algo, há uma colisão
        return hit.collider != null;
    }


    private float HeuristicEuclidean(Vertice a, Vertice b)
    {
        float deltaX = b.worldPos.x - a.worldPos.x;
        float deltaY = b.worldPos.y - a.worldPos.y;

        float distanceSquared = deltaX * deltaX + deltaY * deltaY;

        return Mathf.Sqrt(distanceSquared);
    }

}
