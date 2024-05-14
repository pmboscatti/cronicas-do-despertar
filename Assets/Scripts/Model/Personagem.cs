class Personagem
{
    public string nome;
    public int hp;
    public int def;
    public int atk;
    public int spatk;
    public int spdef;
    public int velocidade;
    public Ataque[] ataques;
    public Magia[] magias;
    public Status[] status;
    public Cura[] curas;
     /*
        lógica de buff e debuff, baseado em modifier
    */
    public Ataque [] GetVetorAtaques()
    {
       return this.ataques; 
    }
    public Magia [] GetVetorMagias()
    {
       return this.magias; 
    }
    public Status [] GetVetorStatus()
    {
       return this.status; 
    }
    public Cura [] GetVetorCuras()
    {
       return this.curas; 
    }
}




