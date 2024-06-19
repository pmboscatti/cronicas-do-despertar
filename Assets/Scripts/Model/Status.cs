using System;

namespace Assets.Scripts.Model
{
    public class Status : Acao
    {
        public Personagem ator;
        public Personagem alvo;
        public Stat Stat;
        public int nivelBuff;// vai de -6 a +6 

        public Status(string nome, int pp, int precisao, Stat Stat,int nivelBuff) : base(nome, pp, precisao)
        {
            this.Stat = Stat;
            this.nivelBuff= nivelBuff;

        }
        public override Personagem GetAlvo()
        {
            return alvo;
        }
        public override Personagem GetAtor()
        {
            return ator;
        }
        public override void efetuaAcao()
        {
                if(ErraAcao()==false)
                {
                    AplicarBuffDebuff();
                }
        }
        public void AplicarBuffDebuff()
{
     switch (Stat)
    {
        case Stat.def:
            Defesa((float)nivelBuff);
            break;
        case Stat.atk:
            Ataque((float)nivelBuff);
            break;
        case Stat.spatk:
            AtaqueEspecial((float)nivelBuff);
            break;
        case Stat.spdef:
            DefesaEspecial( (float)nivelBuff);
            break;
        case Stat.velocidade:
            Velocidade((float)nivelBuff);
            break;
        default:
            // Erro: Stat inválido
            break;
    }
}

private void Defesa(float modificadorBuff)
{
    float def=alvo.def;
    def*=1+modificadorBuff/2;
    alvo.def =(int) def;
}

private void Ataque(float modificadorBuff)
{
   float atk=alvo.atk;
    atk*=1+modificadorBuff/2;
    alvo.atk =(int) atk;
}
private void Velocidade(float modificadorBuff)
{
   float velocidade=alvo.velocidade;
    velocidade*=1+modificadorBuff/2;
    alvo.velocidade =(int) velocidade;
}
private void AtaqueEspecial(float modificadorBuff)
{
   float spatk=alvo.spatk;
    spatk*=1+modificadorBuff/2;
    alvo.spatk =(int) spatk;
}
private void DefesaEspecial(float modificadorBuff)
{
   float spdef=alvo.spdef;
    spdef*=1+modificadorBuff/2;
    alvo.spdef =(int) spdef;
}

// Funções semelhantes para AtaqueEspecial, DefesaEspecial e Velocidade

    }
   public enum Stat
    { 
    def=0,
    atk=1,
    spatk=2,
    spdef=3,
    velocidade=4
}
    

}