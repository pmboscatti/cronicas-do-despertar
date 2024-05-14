public VerticeIA{
    public List<Vertice> vizinhos;
    public List<int> peso;
    static pesoPadrao=1000;
    public Acao acao; 
    public Vertice()
    {
        vizinhos = new List<Vertice>();
        peso = new List<int>(); 
        
    }
    public Vertice(Acao acao)
    {
        vizinhos = new List<Vertice>();
        peso = new List<int>();
        this.acao=acao;        
    }   


}