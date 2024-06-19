using System;
using Assets.Scripts.Model;
namespace Assets.Scripts.IA
{
    public class Master
    {
        public static void Main(string[] args)
        {
            Personagem cleitinho = new("Cleitinho", 200, 100, 100, 100, 100, 100);
            Personagem felisberto = new("Felisberto", 200, 160, 120, 110, 130, 101);
            Inimigo fulano = new("Fulano", 200, 100, 100, 100, 100, 100, 5, 8);
            Inimigo beltrano = new("Beltrano", 200, 115, 100, 100, 100, 100, 8, 5);
            Ataque[] ataques = new Ataque[2];
            Magia[] magias = new Magia[2];
            ataques[0] = new Ataque("ataque de espada", 8, 90, 50);
            ataques[1] = new Ataque("ataque de espada forte", 8, 80, 70);
            magias[0] = new Magia("Lança chamas", 8, 90, 50);
            magias[1] = new Magia("Bola de fogo", 8, 80, 70);
            fulano.ataques = ataques;
            fulano.magias = magias;
            beltrano.magias = magias;
            beltrano.ataques = ataques;
            cleitinho.ataques = ataques;
            cleitinho.magias = magias;
            felisberto.ataques = ataques;
            felisberto.magias = magias;
            GrafoDecisao grafo = new(fulano);
            grafo.CriarGrafo();
            Acao acao = grafo.Dijkstra();
            Console.WriteLine(acao.nome + acao.GetAlvo());
            grafo = new(beltrano);
            grafo.CriarGrafo();
            acao = grafo.Dijkstra();
            Console.WriteLine(acao.nome + acao.GetAlvo());
        }
    }

}
