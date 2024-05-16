class GrafoDecisao{
    public Inimigo personagem;
    public VerticeIA raiz;
    public VerticeIA fim;

    public GrafoDecisao(Inimigo personagem){
        this.personagem=personagem;
        raiz=new VerticeIA();
        fim=new VerticeIA();
    }
    
    
    public void CriarGrafo()
    { 
        IteraPorTodosOsAtaques();
        IteraPorTodasAsMagias();
        // IteraPortodasAsCuras();

    }

    private void IteraPorTodosOsAtaques()
    {
        foreach (Personagem alvo in listaAlvos())
        {
            foreach (Ataque ataque in personagem.GetVetorAtaques())
            {
                VerticeIA vizinho=new VerticeIA(new (ataque, personagem, alvo));
                raiz.vizinhos.Add(vizinho);
                raiz.peso.Add(100/personagem.aptidaoAtaqueFisico);
                DecisaoAtaque(vizinho);
            }
        }
    }
    private void DecisaoAtaque(VerticeIA atual){
        //cria um vértice do grafo com o peso do dano causado ao inimigo
        VerticeIA novo=new(atual);
        atual.vizinhos.Add(novo);
        int danoCausado=atual.acao.CalculoDeDano();
        atual.peso.Add(atual.pesoPadrao/danoCausado);
        //cria um vértice que dá prioridade ao ataque que mata o inimigo 
        atual=novo;
        novo=new(atual);
        atual.vizinhos.Add(novo);
        atual.peso.Add(verificaSeAlvoMorre(danoCausado, acao.alvo));
        //cria um vértice que dá prioridade ao ataque mais preciso
        atual=novo;
        novo=new(atual);
        atual.vizinhos.Add(novo);
        atual.peso.Add(atual.pesoPadrao/(precisao*4));
        //conectar com o fim do turno.
        novo.vizinhos.Add(fim);

    }
    private int verificaSeAlvoMorre(int dano, Personagem alvo){
        int resultado=1000;
        if(alvo.hp<=dano)
        {
            resultado= 0;
        }
        return resultado;
    }
    private void IteraPorTodasAsMagias()
    {
        foreach (Personagem alvo in listaAlvos())
        {
            foreach (Magia magia in personagem.GetVetorMagias())
            {
                VerticeIA vizinho=new VerticeIA(new Magia(personagem, alvo));
                raiz.vizinhos.Add(vizinho);
                raiz.peso.Add(100/personagem.aptidaoMagia);
                DecisaoMagia(vizinho);
            }
        }
    }
    
    private void IteraPortodasAsCuras()
    {
        foreach (Personagem aliado in listaAliados())
        {
            foreach (Cura cura in personagem.GetVetorCuras())
            {
                VerticeIA vizinho=new VerticeIA(new Cura(personagem, alvo));
                raiz.vizinhos.Add(vizinho);
                raiz.peso.Add(1);
                DecisaoCura(vizinho);
            }
        }

    }
    public Personagem[] listaAlvos(){
        
    }
    public Personagem[] listaAliados(){

    }
    
    // private int estouComVidaBaixa()
    // {

    // }
    // private int corroRiscoDeNaoSobreviver()
    // {

    // }
    // private int consigoEfetuarUmDebuff()
    // {

    // }
    // private int consigoEfetuarUmDebuff()
    // {

    // }
    // private int aliadoEstaComVidaBaixa()
    // {

    // }
    // private int consigoEliminarOInimigo()
    // {

    // }
    
    
    // private int aliadoConseguiraSobreviverAoTurno()
    // {

    // }
    // private int buffCalculo()
    // {

    // }
    // private int debuffCalculo()
    // {

    // }
    
}
