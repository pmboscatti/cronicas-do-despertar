public class BuscaLargura
{
    int[] l;
    int[] nivel;
    Node[] pai;
    int t;
    Queue<int> fila;
    int verticeProcurado;
    Grid grid;
    /**
    * Efetua uma busca em largura a partir de um grid, a partir do @param p
    */
    BuscaLargura(int tamanho, int p, Grid grid)
    {
        l = new int[tamanho + 1];
        nivel = new int[tamanho + 1];
        pai = new int[tamanho + 1];
        t = 0;
        fila = new Queue<int>();
        this.verticeProcurado = p;
        this.grid = grid;
    }
    /**
    *
    */
    public Queue<int> buscaLargura(int v)
    {

        t++;
        fila.add(v);
        this.busca();
        return getCaminho(v);
    }
    private void busca()
    {

        while (fila.isEmpty() == false)
        {
            int v = fila.poll();
            LinkedList lista = grid.GetNeighbours(v);
            while (lista.isEmpty() == false)
            {
                int w = lista.poll();
                if (l[w] == 0)
                {
                    t++;
                    l[w] = t;
                    pai[w] = v;
                    nivel[w] = nivel[v] + 1;
                    fila.add(w);
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
    private Queue<int> getCaminho(int v)
    {
        Stack pilha = new Stack<int>();
        int x = pai[w];

        while (pai[x] != v)
        {
            pilha.add(pai[w]);
            x = pai[x];
        }
    }
}
