namespace Assets.Scripts.Model
{
    public class Cura: Acao{
    public Personagem ator;
    public Personagem alvo;
    private readonly int curaBase;
public Cura(string nome, int pp, int precisao, int curaBase) : base(nome, pp, precisao)
    {
        this.curaBase = curaBase;
    }
   public override int CalculoDeCura(){
       
        return (int)(curaBase*RNJesus.GetRange());//tem que inserir um método de pegar o dano do personagem
    
    }
        public void DeterminaAtores(Personagem ator, Personagem alvo)
        {
            this.ator = ator;
            this.alvo = alvo;
        }
        public override void efetuaAcao()
    {
        int cura=0;
        if(ErraAcao()==false)
        {
            cura=CalculoDeCura();
        }
        if (cura>0)
        {
            if(this.alvo.hpAtual+cura>alvo.hp)
            {
                alvo.hpAtual=alvo.hp;
            }
            else{
                alvo.hpAtual+=cura;
            }
            //mensagem de cura efetuada
        }
        else{
            //mensagem de erro na cura
        }
    }  
}
}
