using System.Collections.Generic;

public class VerticeIA{
    public List<VerticeIA> vizinhos;
    public List<int> peso;
    static int pesoPadrao=1000;
    public Acao acao; 
    public VerticeIA()
    {
        vizinhos = new List<VerticeIA>();
        peso = new List<int>(); 
        
    }
    public VerticeIA(Acao acao)
    {
        vizinhos = new List<VerticeIA>();
        peso = new List<int>();
        this.acao=acao;        
    }   


}