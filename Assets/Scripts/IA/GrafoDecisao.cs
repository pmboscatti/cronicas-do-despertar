using System;
using System.Collections.Generic;
class GrafoDecisao{
    public Inimigo personagem;
    public List<VerticeIA> array;// primeira posição[0] é o vértice de fim, s
    public int V;//número de vértices
    public GrafoDecisao(Inimigo personagem){
        this.personagem=personagem;
        VerticeIA raiz=new VerticeIA();
        array.Add(new VerticeIA());
        AdicionaVertice(raiz);//raíz índice um, fim índice zero
        raiz.distanciaRaiz=0;
    }
    
    public void AdicionaVertice(VerticeIA vertice){
        array.Add(vertice);
        V++;
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
                AdicionaVertice(vizinho);
                array[1].vizinhos.Add(V);
                array[1].distancia.Add(100/personagem.aptidaoAtaqueFisico);
                DecisaoAtaque(vizinho);
            }
        }
    }
    private void DecisaoAtaque(VerticeIA atual){
        //cria um vértice do grafo com o distancia do dano causado ao inimigo
        VerticeIA novo=new(atual);
        AdicionaVertice(novo);
        atual.vizinhos.Add(V);
        int danoCausado=atual.acao.CalculoDeDano();
        atual.distancia.Add(VerticeIA.distanciaPadrao/danoCausado);
        //cria um vértice que dá prioridade ao ataque que mata o inimigo 
        atual=novo;
        novo=new(atual);
        AdicionaVertice(novo);
        atual.vizinhos.Add(V);
        atual.distancia.Add(VerificaSeAlvoMorre(danoCausado, atual.acao.GetAlvo()));
        //cria um vértice que dá prioridade ao ataque mais preciso
        atual=novo;
        novo=new(atual);
        AdicionaVertice(novo);
        atual.vizinhos.Add(V);
        atual.distancia.Add(VerticeIA.distanciaPadrao/(atual.acao.precisao*4));
        //conectar com o fim do turno.
        novo.vizinhos.Add(0);

    }
    private int VerificaSeAlvoMorre(int dano, Personagem alvo){
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
                AdicionaVertice(new VerticeIA(new Magia(magia, personagem, alvo)));
                array[1].vizinhos.Add(V);
                array[1].distancia.Add(100/personagem.aptidaoMagia);
                DecisaoAtaque(array[V]);
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
    //             raiz.distancia.Add(1);
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
