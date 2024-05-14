class Ataque: Acao{
    private Personagem atacante;
    private Personagem alvo;
    private int DanoBase;

  public Ataque(Personagem atacante, Personagem alvo){
    this.atacante = atacante;
    this.alvo = alvo;
  }
   public int calculoDeDano(){
       
        return (int)(atacante.atk*RNJesus.getRange()*RNJesus.crit()*DanoBase/alvo.def);//tem que inserir um método de pegar o dano do personagem
    
    }
    public int realizaAtaque()
    {
        int dano=0;
        if(erraAcao()==false)
        {
            dano=calculoDeDano();
        }
        return dano;
    }  
    
}
