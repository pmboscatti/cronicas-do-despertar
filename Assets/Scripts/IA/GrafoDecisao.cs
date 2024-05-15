class GrafoDecisao{
    public Inimigo personagem;
    public VerticeIA raiz;
    public VerticeIA fimDoTurno;

    public GrafoDecisao(Inimigo personagem){
        this.personagem=personagem;
        raiz=new VerticeIA();
        fimDoTurno=new VerticeIA();
    }
    
    
    public void criarGrafo()
    { 
        IteraPorTodosOsAtaques();
        IteraPorTodasAsMagias();
        IteraPortodasAsCuras();

    }

    private void IteraPorTodosOsAtaques()
    {
        foreach (Personagem alvo in listaAlvos())
        {
            foreach (Ataque ataque in personagem.GetVetorAtaques())
            {
                VerticeIA vizinho=new VerticeIA(new Ataque(personagem, alvo));
                raiz.vizinhos.add(vizinho);
                raiz.peso.add(1);
                DecisaoAtaque(vizinho);
            }
        }
    }
    private void DecisaoAtaque(){
        
    }
    private void IteraPorTodasAsMagias()
    {
        foreach (Personagem alvo in listaAlvos())
        {
            foreach (Magia magia in personagem.GetVetorMagias())
            {
                VerticeIA vizinho=new VerticeIA(new Magia(personagem, alvo));
                raiz.vizinhos.add(vizinho);
                raiz.peso.add(1);
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
                raiz.vizinhos.add(vizinho);
                raiz.peso.add(1);
                DecisaoCura(vizinho);
            }
        }

    }
    public Personagem[] listaAlvos(){
        
    }
    public Personagem[] listaAliados(){
        
    }
    
    private int estouComVidaBaixa()
    {

    }
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
