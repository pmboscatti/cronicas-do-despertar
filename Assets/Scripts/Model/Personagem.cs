using System;
namespace Assets.Scripts.Model
{
public class Personagem
{
    public string nome;
    public int hpAtual;
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
    public bool vivo;

        public Personagem()
        {
        }

        //  public Status[] status;
        //  public Cura[] curas;

        public Personagem(string nome, int hp, int def, int atk, int spatk, int spdef, int velocidade)
    {
        this.nome = nome;
        this.hp = hp;
        this.def = def;
        this.atk = atk;
        this.spatk = spatk;
        this.spdef = spdef;
        this.velocidade = velocidade;
        this.vivo = true;
    }

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
}



