using System;
namespace Assets.Scripts.Model
{

public class Magia : Acao
{
    public Personagem atacante;
    public Personagem alvo;
    public int dano;

    public AudioSource magicDamageAudio;
    public AudioSource magicDamageCriticalAudio;
    public AudioSource magicDamageMissedAudio;

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
    
    
    public override Personagem GetAtor()
        {
            return atacante;
        }
        
        
        // METODO PRINCIPAL EFETUAR MAGIA
        public override void EfetuaAcao()
        {
            int dano = RealizaAtaque();
            if (dano >= this.GetAlvo().hpAtual)
            {
                this.GetAlvo().hpAtual = 0;
                this.GetAlvo().vivo = false;
            }
            else
            {
                if (dano == 0)
                {
                    //precisa aparecer a mensagem que o ataque errou;
                    magicDamageMissedAudio.Play();
                }
                else
                {
                    if (/*for critico*/) {
                        this.GetAlvo().hpAtual = this.GetAlvo().hpAtual - dano;
                        magicDamageCriticalAudio.Play();
                    } else {
                        this.GetAlvo().hpAtual = this.GetAlvo().hpAtual - dano;
                        magicDamageAudio.Play();
                    }
                }
            }
            //precisa chamar o m�todo que atualiza o hp do alvo na tela do jogo;
        }
    }
}
