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

    void Awake()
    {
        grid = GetComponent<GeradorGrafo>();
    }

    private void Update()
    {
        // buscaLargura(grid.GetVerticeFromPosition(Origem.transform.position).id);
    }


    /**
    * Efetua uma busca em largura a partir de um grid, a partir do @param p
    */
    public BuscaLargura()
    {
    }
    /**
    *
    */
    public Stack<Vertice> buscaLargura(int v)
    {

        Vertice destino = grid.GetVerticeFromPosition(Destino.transform.position);

        if (v == destino.id) return null; 
        if ( Vector3.Distance(Origem.transform.position, Destino.transform.position) < 0.1 ) return null;
        if (!destino.walkable) return null;

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
        if(this.busca()) return getCaminho(v);
        else
        {
            print("Posição invalida");
            return null;
        } 
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
    a partir do vetor de pai retorna o menor caminho para o vértice de origem
    */
    private Stack<Vertice> getCaminho(int v)
    {
        Stack<Vertice> pilha = new Stack<Vertice>();
        int x = pai[verticeProcurado];
        pilha.Push(grid.GetVertice(x));

        while (pai[x] != v)
        {
            pilha.Push(grid.GetVertice(pai[x]));
            x = pai[x];
        }

        pilha.Push(grid.GetVertice(v));
        grid.caminho = pilha;

        return pilha;
    }
}