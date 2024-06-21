using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class BuscaLargura : MonoBehaviour
{
    public GameObject Origem;
    public GameObject Destino;

    int[] l;
    int[] nivel;
    int[] pai;
    int t;
    Queue<int> fila;
    int verticeProcurado;
    int verticeOrigem;

    GeradorGrafo grid;
    ControladorPathFinders controladorPathFinder;

    void Awake()
    {
        controladorPathFinder = GetComponent<ControladorPathFinders>(); 
        grid = GetComponent<GeradorGrafo>();
    }

    private void Update()
    {
        // buscaLargura(grid.GetVerticeFromPosition(Origem.transform.position).id);
    }

    public void Busca(Vector3 posInicial)
    {
        StartCoroutine(buscaLargura(grid.GetVerticeFromPosition(posInicial).id));
    }

    /**
    *
    */
    IEnumerator buscaLargura(int v)
    {

        Vertice destino = grid.GetVerticeFromPosition(Destino.transform.position);

        if (v == destino.id) yield break; 
        if ( Vector3.Distance(Origem.transform.position, Destino.transform.position) < 0.1 ) yield break;
        if (!destino.walkable) yield break;

        bool sucesso = false;
        Vector3[] pontos = new Vector3[0];

        // print(Vector3.Distance(Origem.transform.position, Destino.transform.position));

        int tamanho = (int) grid.gridSize;
        l = new int[tamanho + 1];
        nivel = new int[tamanho + 1];
        pai = new int[tamanho + 1];
        t = 0;
        fila = new Queue<int>();
        verticeProcurado = destino.id;  
        verticeOrigem = v;


        t++;
        fila.Enqueue(verticeOrigem);


        yield return null;
        if(busca())
        {
            pontos = CaminhoSimplificado(getCaminho(v));
            Array.Reverse(pontos);
            sucesso = true;
        }
        else
        {
            print("Posi��o invalida");
        }

        controladorPathFinder.FimProcessamentoCaminho(pontos, sucesso);
    }   
    private bool busca()
    {

        while (fila.Count > 0)
        {
            int v = fila.Dequeue();
            List<int> lista = grid.GetVizinhos(v);
            grid.caminhoBuilding = lista;


            while (lista.Count > 0)
            {
                int w = lista[0];
                lista.RemoveAt(0);
                // print(w);
                if (l[w] == 0)
                {
                    t++;
                    l[w] = t;
                    pai[w] = v;
                    nivel[w] = nivel[v] + 1;
                    fila.Enqueue(w);
                    if (w == verticeProcurado)
                    {
                        return true;
                    }
                }
                if (lista.Count >= grid.gridSize) return false;
            }
        }
        return false;
    }
    /**
    a partir do vetor de pai retorna o menor caminho para o v�rtice de origem
    */
    private List<Vertice> getCaminho(int v)
    {
        List<Vertice> caminho = new List<Vertice>();
        int x = pai[verticeProcurado];
        caminho.Add(grid.GetVertice(x));

        while (pai[x] != v)
        {
            caminho.Add(grid.GetVertice(pai[x]));
            x = pai[x];
        }

        caminho.Add(grid.GetVertice(v));
        grid.caminho = caminho;
        return caminho;
    }

    Vector3[] CaminhoSimplificado(List<Vertice> caminho)
    {
        List<Vector3> pontos = new List<Vector3>();
        Vector2 direcaoUltima = Vector2.zero;

        for(int i = 1; i < caminho.Count; i++)
        {
            Vector2 direcaoAtual = new Vector2(caminho[i - 1].xPos - caminho[i].xPos, caminho[i - 1].yPos - caminho[i].yPos);
            if(direcaoAtual != direcaoUltima)
            {
                pontos.Add(caminho[i].worldPos);
            }
            direcaoUltima = direcaoAtual;
        }

        return pontos.ToArray();
    } 
}