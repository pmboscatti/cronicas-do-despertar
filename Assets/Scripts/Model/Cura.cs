
class Cura: Acao{
    private Personagem ator;
    private Personagem alvo;
    private int curaBase;

  public Cura(Personagem ator, Personagem alvo){
    this.ator = ator;
    this.alvo = alvo;
  }
   public int CalculoDeCura(){
       
        return (int)(curaBase*RNJesus.getRange());//tem que inserir um método de pegar o dano do personagem
    
    }
    public int RealizaCura()
    {
        int cura=0;
        if(erraAcao()==false)
        {
            cura=CalculoDeCura();
        }
        return cura;
    }  
}