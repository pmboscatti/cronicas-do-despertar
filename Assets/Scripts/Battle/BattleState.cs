
using Assets.Scripts.IA;
using Assets.Scripts.Model;
using System.Collections.Generic;

namespace Assets.Scripts.Battle
{
	public class BattleState
	{
		public List<Personagem> aliados;
		public List<Inimigo> inimigos;
		bool fimDaBatalha;



		public void AtualizaListaDeVivos()
		{

			foreach (Personagem personagem in aliados)
			{
				if(personagem.vivo==false)
				{
					aliados.Remove(personagem);
				}
			}
			foreach (Inimigo inimigo in inimigos)
			{
				if(inimigo.vivo==false)
				{
					inimigos.Remove(inimigo);
				}
			}
			int aliadosVivos = aliados.Count;
			int inimigosVivos = inimigos.Count;
			if (aliadosVivos == 0)
			{
				fimDaBatalha = true;
				//precisa criar o método de game over;
			}
			else if (inimigosVivos == 0)
			{
				fimDaBatalha = true;
				//precisa criar o método de vitória;
			}
			if (fimDaBatalha == false)
			{
				//chamar o próximo estado;
			}
		}

		public MaxHeap CriaMaxHeap(List<Acao> listaAcoes)
		{
			MaxHeap heap = new();
			foreach (Acao acao in listaAcoes)
			{
				heap.Insert(acao);
			}
			return heap;
		}

		public void EfetuaAtaques(MaxHeap heap)
		{
			while (heap.Count > 0)
			{
				Acao acao = heap.ExtractMax();
				if(acao.GetAtor().vivo&&acao.GetAlvo().vivo)
				{
					acao.EfetuaAcao();
				}
				if(acao.GetAlvo().vivo==false)
				{
					//gerar animação de morte do alvo;
				}
				
			}
		}
		public void DecisaoIA(List<Acao>lista)
	{
		foreach (Inimigo p in inimigos)
		{
			if (ReferenceEquals(p, new Inimigo()))
					{
						GrafoDecisao grafo=new(p);
						lista.Add(grafo.Dijkstra());

					}
		}
	}
	public List<Acao> DecisaoJogador()
	{
		List<Acao> listaDeAcoes=new List<Acao>();

		//receber a lista de ações de escolha do jogador;
		return listaDeAcoes;
	}
	public void EscolhaDeAcoes()
	{
		List<Acao> listaDeAcoes=DecisaoJogador();
		DecisaoIA(listaDeAcoes);
		MaxHeap heap=CriaMaxHeap(listaDeAcoes);
		EfetuaAtaques(heap);
	}
	}
	
	
}