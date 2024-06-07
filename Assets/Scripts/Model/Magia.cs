using System;

public class Magia : Acao
{
    public Personagem atacante;
    public Personagem alvo;
    public int dano;

    public Magia(String nome, int pp, int precisao, int dano) : base(nome, pp, precisao)
    {
        this.dano = dano;
    }
    public void DeterminaAtores(Personagem atacante, Personagem alvo)
    {
        this.atacante = atacante;
        this.alvo = alvo;
    }
    public Magia(Magia magia, Personagem atacante, Personagem alvo) : base(magia.nome, magia.pp, magia.precisao)
    {
        this.atacante = atacante;
        this.alvo = alvo;
        this.dano = magia.dano;
    }
    public override Personagem GetAlvo()
    {
        return alvo;
    }
    public override int CalculoDeDano()
    {
        return (int)(dano * atacante.spatk / alvo.spdef * RNJesus.GetRange() * RNJesus.Crit());


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
