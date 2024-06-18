namespace Assets.Scripts.Model
{
public class Acao
{
    public string nome;
    public int pp;//powerpoint
    public int precisao;//varia de 1 a 100, sendo garantido que acertará, não pode ser zero

    public Acao(string nome, int pp, int precisao)
    {
        this.nome = nome;
        this.pp = pp;
        this.precisao = precisao;
    }
    public virtual int CalculoDeDano()
    {
        return 0;
    }
    public static int CalculaDanoPuroAtaque(Personagem atacante, Personagem alvo, int dano)
    {
        return (int)(atacante.atk * dano / alvo.def);
    }
    public static int CalculaDanoPuroMagia(Personagem atacante, Personagem alvo, int dano)
    {
        return (int)(atacante.spatk * dano / alvo.spdef);
    } 
    public virtual Personagem GetAlvo()
    {
        return null;
    }
    public virtual Personagem GetAtor(){
        return null;
    }
    public bool ErraAcao()
    {
        return RNJesus.ErraAcao(precisao);
    }
    public virtual void AtualizaHp()
        {
            return;
        }
}
}