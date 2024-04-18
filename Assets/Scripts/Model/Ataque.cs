class Ataque: Acao{
   public int calculoDeDano(Personagem atacante, Personagem vitima ){
       
        return (int)(atacante.atk*RNJesus.getRange()*RNJesus.crit()/vitima.def);//tem que inserir um método de pegar o dano do personagem
    
    }
    public int realizaAtaque(Personagem atacante, Personagem vitima)
    {
        int dano=0;
        if(erraAcao()==false)
        {
            dano=calculoDeDano(atacante,vitima );
        }
        return dano;
    }  
    
}
