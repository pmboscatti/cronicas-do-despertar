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
    /**
    * Efetua uma busca em largura a partir de um grid, a partir do @param p
    */
    BuscaLargura(GeradorGrafo grid)
    {
        Vertice origem = grid.NodeFromWorldPoint(Origem.transform.position);
        Vertice destino = grid.NodeFromWorldPoint(Destino.transform.position);

        int tamanho = grid.gridSize;
        l = new int[tamanho + 1];
        nivel = new int[tamanho + 1];
        pai = new int[tamanho + 1];
        t = 0;
        fila = new Queue<int>();
        verticeProcurado = destino.id;
        verticeOrigem = origem.id;
        this.grid = grid;

        buscaLargura(verticeOrigem);
    }
    /**
    *
    */
    public Stack<int> buscaLargura(int v)
    {

        t++;
        fila.Enqueue(verticeOrigem);
        this.busca();
        return getCaminho(v);
    }
    private void busca()
    {

        while (fila.Count > 0)
        {
            int v = fila.Dequeue();
            List<int> lista = grid.GetNeighbours(v);
            while (lista.Count > 0)
            {
                int w = lista.IndexOf(0);
                lista.RemoveAt(0);
                if (l[w] == 0)
                {
                    t++;
                    l[w] = t;
                    pai[w] = v;
                    nivel[w] = nivel[v] + 1;
                    fila.Enqueue(w);
                    if (w == verticeProcurado)
                    {
                        return;
                    }
                }
            }
        }
    }
    /**
    a partir do vetor de pai retorna o menor caminho para o vértice de origem
    */
    private Stack<int> getCaminho(int v)
    {
        Stack<int> pilha = new Stack<int>();
        int x = pai[verticeProcurado];

        while (pai[x] != v)
        {
            pilha.Push(pai[x]);
            x = pai[x];
        }

        pilha.Push(v);

        return pilha;
    }
}