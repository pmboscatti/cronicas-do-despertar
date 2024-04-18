class Magia:Acao{
    private  int dano;
    private  bool tipoDano;//true físico, false especial
   private  int calculoDeDano(Personagem atacante, Personagem vitima ){
        return (int)(dano*atacante.spatk/vitima.spdef*RNJesus.getRange()*RNJesus.crit());

    
    }
    public  int realizaAtaque(Personagem atacante, Personagem vitima)
    {
        int dano=0;
        if(erraAcao()==false)
        {
            dano=calculoDeDano(atacante, vitima );
        }
        return dano;
    }  
    
}
