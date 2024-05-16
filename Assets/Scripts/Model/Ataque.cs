public class Ataque: Acao{
    public Personagem atacante;
    public Personagem alvo;
    public int dano;

    public Ataque(string nome, int pp,int precisao,int dano):base(nome,pp,precisao)
    {
        this.dano = dano;
    }
   public override int CalculoDeDano(){
       
        return (int)(atacante.atk*RNJesus.getRange()*RNJesus.crit()*dano/alvo.def);//tem que inserir um método de pegar o dano do personagem
    
    }
    public void DeterminaAtores(Personagem atacante, Personagem alvo){
    this.atacante=  atacante;
    this.alvo= alvo;
    }
    public int RealizaAtaque()
    {
        int dano=0;
        if(ErraAcao()==false)
        {
            dano=CalculoDeDano();
        }
        return dano;
    }  
    
}
