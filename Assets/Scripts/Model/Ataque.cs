class Ataque: Acao{
   private int calculoDeDano(Personagem atacante, Personagem vitima ){
       
        return (int)dano*atacante.atk*NJesus.getRange()*RNJesus.crit()/vitima.def;
    
    }
    public int realizaAtaque(Personagem atacante, Personagem vitima)
    {
        int dano=0
        if(erraAcao()==false)
        {
            dano=calculoDeDano(Personagem atacante, Personagem vitima );
        }
        return dano;
    }  
    
}
