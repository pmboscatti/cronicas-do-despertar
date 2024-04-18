using Dijkstra;
public class BuscaLargura {
    int[] l;
    int[] nivel;
    Node [] pai;
    int t;
    Queue<int> fila;

    BuscaLargura(int m){
    l=new int[m+1];
    nivel=new int[m+1];
    pai=new int [m+1];
    t=0;
    fila=new Queue<int>(); 
    }
    public LinkedList<Integer> buscaLargura(Node v, Node w)
    {
       
        LinkedList resp = new LinkedList<int>();
                
                t++;
                fila.add();
                this.busca();
        }


        return resp;
    }
    private void busca()
    {

        while(fila.isEmpty()==false)
        {
            int v=fila.poll();
            for(int c=0;c<la.vertices[v-1].adjacentes.size();c++)
            {
                
                if(l[w]==0)
                {
                    t++;
                    l[w]=t;
                    pai[w]=v;
                    nivel[w]=nivel[v]+1;
                    fila.add(w);
                }
            }
        }
    }
}
