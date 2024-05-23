using System.Collections.Generic;

public class VerticeIA
{
    public List<int> vizinhos;
    public List<int> distancia;
    public static int distanciaPadrao = 1000;
    public Acao acao;
    public int distanciaRaiz;
    public VerticeIA()
    {
        vizinhos = new List<int>();
        distancia = new List<int>();
        distanciaRaiz = 100000000;//inicializa a distância para a raiz como uma constante de tamanho grande, representando infinito neste caso.
    }
    public VerticeIA(Acao acao)
    {
        vizinhos = new List<int>();
        distancia = new List<int>();
        this.acao = acao;
    }
    public VerticeIA(VerticeIA vertice)
    {
        vizinhos = new List<int>();
        distancia = new List<int>();
        this.acao = vertice.acao;
    }
    public int[] ListaVizinhos()
    {
        return vizinhos.ToArray();

    }
    public int[] ListaDistancia()
    {
        return distancia.ToArray();
    }


}