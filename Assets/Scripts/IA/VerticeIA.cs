using System.Collections.Generic;

public class VerticeIA{
    public List<VerticeIA> vizinhos;
    public List<int> peso;
    public static int pesoPadrao=1000;
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
    public VerticeIA(Ataque ataque, Inimigo personagem, Personagem alvo)    {
        Acao( ataque, personagem, alvo);
    }
    public VerticeIA(VerticeIA vertice)
    {
       vizinhos = new List<VerticeIA>();
        peso = new List<int>();  
        this.acao=vertice.acao;
    }     


}