using Unity.VisualScripting;

namespace Assets.Scripts.Model
{
public class Ataque : Acao
{
    public Personagem atacante;
    public Personagem alvo;
    public int dano;

    public Ataque(string nome, int pp, int precisao, int dano) : base(nome, pp, precisao)
    {
        this.dano = dano;
    }
    public override int CalculoDeDano()
    {

        return (int)(atacante.atk * RNJesus.GetRange() * RNJesus.Crit() * dano / alvo.def);//tem que inserir um método de pegar o dano do personagem

    }
    public Ataque(Ataque ataque, Personagem atacante, Personagem alvo) : base(ataque.nome, ataque.pp, ataque.precisao)
    {
        this.atacante = atacante;
        this.dano = ataque.dano;
        this.alvo = alvo;
    }
    public void DeterminaAtores(Personagem atacante, Personagem alvo)
    {
        this.atacante = atacante;
        this.alvo = alvo;
    }
    public override Personagem GetAlvo()
    {
        return alvo;
    }
        public override Personagem GetAtor()
        {
            return atacante;
        }
        private int RealizaAtaque()
    {
        int dano = 0;
        if (ErraAcao() == false)
        {
            dano = CalculoDeDano();
        }
        return dano;
    }
        public override void AtualizaHp()
        {
            int dano=RealizaAtaque();
            if (dano>=this.GetAlvo().hpAtual)
            {
                this.GetAlvo().hpAtual = 0;
                this.GetAlvo().vivo = false;
            }
            else
            {
                if(dano==0)
                {
                    //precisa aparecer a mensagem que o ataque errou;
                }
                else
                {
                    this.GetAlvo().hpAtual = this.GetAlvo().hpAtual - dano;
                }
            }
            //precisa chamar o método que atualiza o hp do alvo na tela do jogo;
        }

    }
}