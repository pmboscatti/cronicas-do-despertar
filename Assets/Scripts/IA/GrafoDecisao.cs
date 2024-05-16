using System.Collections.Generic;

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
        foreach (Personagem alvo in ListaAlvos())
        {
            foreach (Ataque ataque in personagem.GetVetorAtaques())
            {
                VerticeIA vizinho=new VerticeIA(new Ataque(ataque, personagem, alvo));
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
        atual.peso.Add(VerticeIA.pesoPadrao/danoCausado);
        //cria um vértice que dá prioridade ao ataque que mata o inimigo 
        atual=novo;
        novo=new(atual);
        atual.vizinhos.Add(novo);
        atual.peso.Add(verificaSeAlvoMorre(danoCausado, atual.acao.GetAlvo()));
        //cria um vértice que dá prioridade ao ataque mais preciso
        atual=novo;
        novo=new(atual);
        atual.vizinhos.Add(novo);
        atual.peso.Add(VerticeIA.pesoPadrao/(atual.acao.precisao*4));
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
        foreach (Personagem alvo in ListaAlvos())
        {
            foreach (Magia magia in personagem.GetVetorMagias())
            {
                VerticeIA vizinho=new VerticeIA(new Magia(magia, personagem, alvo));
                raiz.vizinhos.Add(vizinho);
                raiz.peso.Add(100/personagem.aptidaoMagia);
                DecisaoAtaque(vizinho);
            }
        }
    }
    
    // private void IteraPortodasAsCuras()
    // {
    //     foreach (Personagem aliado in listaAliados())
    //     {
    //         foreach (Cura cura in personagem.GetVetorCuras())
    //         {
    //             VerticeIA vizinho=new VerticeIA(new Cura(personagem, alvo));
    //             raiz.vizinhos.Add(vizinho);
    //             raiz.peso.Add(1);
    //             DecisaoCura(vizinho);
    //         }
    //     }

    // }
    //Está estático no momento para testes
    public Personagem[] ListaAlvos(){
        Personagem cleitinho=new("Cleitinho", 200, 100,100,100,100,100);
        Personagem felisberto=new("Felisberto", 200, 160,120,110,130,101);
        Ataque[] ataques=new Ataque[2];
        Magia[] magias=new Magia[2];
        ataques[0]=new Ataque("ataque de espada",8,90,50);
        ataques[1]=new Ataque("ataque de espada forte",8,80,70);
        magias[0]=new Magia("Lança chamas",8,90,50);
        magias[1]=new Magia("Bola de fogo",8,80,70);
        cleitinho.ataques=ataques;
        cleitinho.magias=magias;
        felisberto.ataques=ataques;
        felisberto.magias=magias;
        Personagem[]lista=new Personagem[2];
        lista[0]=felisberto;
        lista[1]=cleitinho;
        return lista;
    }
    // public  Personagem[] listaAliados(){

    // }
    
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
