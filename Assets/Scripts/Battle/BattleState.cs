
using Assets.Scripts.Model;
using System.Collections.Generic;

namespace Assets.Scripts.Battle
{
	public class BattleState
	{
		public List<Personagem> personagens;
		bool fimDaBatalha;



		public void AtualizaListaDeVivos()
		{
			int aliadosVivos = 0;
			int inimigosVivos = 0;
			foreach (Personagem p in personagens)
			{
				if (p.vivo)
				{
					if (ReferenceEquals(p, new Inimigo()))
					{
						inimigosVivos++;
					}
					else
					{
						aliadosVivos++;
					}
				}
				else
				{
					personagens.Remove(p);
				}
			}
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

		public void CriaMaxHeap(List<Acao> listaAcoes)
		{
			MaxHeap heap = new();
			foreach (Acao acao in listaAcoes)
			{
				heap.Insert(acao);
			}
		}

		public void EfetuaAtaques(MaxHeap heap)
		{
			while (heap.Count > 0)
			{
				Acao acao = heap.ExtractMax();
				if(acao.GetAtor().vivo&&acao.GetAlvo().vivo)
				{
					acao.AtualizaHp();
				}
				
			}
		}
	}
}