public class Inimigo : Personagem
{
    public int aptidaoAtaqueFisico;
    public int aptidaoMagia;

    public Inimigo(string nome, int hp, int def, int atk, int spatk, int spdef,int velocidade, int aptidaoAtaqueFisico, int aptidaoMagia) :
    base(nome, hp, def, atk, spatk, spdef,velocidade)
    {

        this.aptidaoAtaqueFisico = aptidaoAtaqueFisico;
        this.aptidaoMagia = aptidaoMagia;
    }
    // public int curarAliado;
    // public int autoProtecao;
    // public int protegerAliado;


}
