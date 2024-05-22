using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class BuscaAStar : MonoBehaviour
{

    GeradorGrafo grid;
    ControladorPathFinders controlador;

    void Awake()
    {
        controlador = GetComponent<ControladorPathFinders>();
        grid = GetComponent<GeradorGrafo>();
    }

    public void IniciarCaminho(Vector3 origem, Vector3 destino)
    {
        StartCoroutine(EncontrarCaminho(origem, destino));
    }

    IEnumerator EncontrarCaminho(Vector3 origem, Vector3 destino)
    {
        Vector3[] pontos = new Vector3[0];
        bool encontrou = false;

        // Criar nós para origem e destino
        Vertice startNode = grid.GetVerticeFromPosition(origem);
        Vertice targetNode = grid.GetVerticeFromPosition(destino);


        if (startNode.walkable && targetNode.walkable && startNode != targetNode) {

            MinHeap<Vertice> abertos = new MinHeap<Vertice>(grid.gridSize);
            HashSet<Vertice> fechados = new HashSet<Vertice>();

            abertos.Add(startNode);

            while (abertos.Count > 0)
            {
                Vertice atual = abertos.RemoveFirst();
                fechados.Add(atual);

                if (atual == targetNode)
                {
                    encontrou = true;
                    break;
                }

                foreach (Vertice vizinho in grid.GetVizinhos(atual))
                {
                    if (!vizinho.walkable || fechados.Contains(vizinho))
                    {
                        continue;
                    }

                    int novoG = atual.gCost + GetEuclidianDistance(atual, vizinho);

                    if (novoG < vizinho.gCost || !abertos.Contains(vizinho))
                    {
                        vizinho.gCost = novoG;
                        vizinho.hCost = GetEuclidianDistance(vizinho, targetNode);
                        vizinho.pai = atual;

                        if (!abertos.Contains(vizinho))
                        {
                            abertos.Add(vizinho);
                        }
                    }
                }
            }
        }
        yield return null;
        if(encontrou)
        {
            pontos = RetracePath(startNode, targetNode);
        }

        controlador.FimProcessamentoCaminho(pontos, encontrou);
    }

    Vector3[] RetracePath(Vertice origem, Vertice destino)
    {
        List<Vertice> caminho = new List<Vertice>();
        Vertice atual = destino;

        while (atual != origem)
        {
            caminho.Add(atual);
            atual = atual.pai;
        }
        Vector3[] pontos = CaminhoSimplificado(caminho);
        Array.Reverse(pontos);  
        return pontos;
    }

    Vector3[] CaminhoSimplificado(List<Vertice> caminho)
    {
        List<Vector3> pontos = new List<Vector3>();
        Vector2 direcaoUltima = Vector2.zero;

        for (int i = 1; i < caminho.Count; i++)
        {
            Vector2 direcaoAtual = new Vector2(caminho[i - 1].xPos - caminho[i].xPos, caminho[i - 1].yPos - caminho[i].yPos);
            if (direcaoAtual != direcaoUltima)
            {
                pontos.Add(caminho[i].worldPos);
            }
            direcaoUltima = direcaoAtual;
        }

        return pontos.ToArray();
    }


    int GetEuclidianDistance(Vertice a, Vertice b)
    {
        int deltaX = Mathf.Abs(a.xPos - b.xPos); 
        int deltaY = Mathf.Abs(a.yPos - b.yPos);

        if (deltaX > deltaY) return 14 * deltaY + 10 * (deltaX - deltaY);
        return 14 * deltaX + 10 * (deltaY - deltaX);
    }

}