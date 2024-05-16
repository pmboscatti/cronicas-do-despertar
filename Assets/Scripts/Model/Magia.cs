using System;

public class Magia : Acao
{
    public Personagem atacante;
    public Personagem alvo;
    public int dano;

    public Magia(String nome, int pp,int precisao,int dano):base(nome,pp,precisao)
    {
        this.dano = dano;
    }
    public void DeterminaAtores(Personagem atacante, Personagem alvo){
    this.atacante=  atacante;
    this.alvo= alvo;
    }
    public int CalculoDeDano()
    {
        return (int)(dano * atacante.spatk / alvo.spdef * RNJesus.getRange() * RNJesus.crit());


    }
    public int RealizaAtaque()
    {
        int dano = 0;
        if (ErraAcao() == false)
        {
            dano = CalculoDeDano();
        }
        return dano;
    }

}
