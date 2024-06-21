
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
				//chamada para o próximo estado de batalha
				EstadoEscolha();
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
		//listaDeAcoes= () //receber a lista de ações vinda do método do Pedro
		return listaDeAcoes;
	}
	public void EscolhaDeAcoes()
	{
		List<Acao> listaDeAcoes=DecisaoJogador();
		DecisaoIA(listaDeAcoes);
		MaxHeap heap=CriaMaxHeap(listaDeAcoes);
		ExecutaAcoes(heap);//aqui já é a chamada para o próximo estado
	}
	public void IniciaAliados()
	{
		aliados=new();
		Personagem Guerreiro = new("Guerreiro", 200, 150, 150, 50, 50, 50);
		Personagem Mago = new("Mago", 200, 80,20 , 180, 130, 101);
		Ataque[] ataques = new Ataque[2];
		Magia[] magias = new Magia[2];
		Cura[]curas=new Cura[2];
		ataques[0] = new Ataque("ataque de espada", 8, 90, 50);
		ataques[1] = new Ataque("ataque de machado", 8, 80, 70);
		magias[0] = new Magia("Lança chamas", 8, 90, 50);
		magias[1] = new Magia("Bola de fogo", 8, 80, 70);
		curas[0] = new Cura("Recuperar",5,90,50);
		curas[1] = new Cura("Benção do Deus do Sol ",5,70,100);
		Guerreiro.ataques = ataques;
		Guerreiro.magias = magias;
		Mago.ataques = ataques;
		Mago.magias = magias;
		Status[]status=new Status[6];
		status[0]= new Status("Maldição de lentidão",5, 70,Stat.velocidade, -2);
		status[1]= new Status("Intimidar",5, 90,Stat.atk, -1);
		status[2]=  new Status("Benção de força",5, 90,Stat.atk, 1);
		status[3]=  new Status("Pele de pedra",5, 90,Stat.def, 1);
		status[4]=  new Status("Benção de Hermes",5, 90,Stat.velocidade, 1);
		status[5]=  new Status("Armadura mágica",5, 90,Stat.spdef, 1);
		Mago.status=status;
		aliados.Add(Guerreiro);
		aliados.Add(Mago);
	}
	public void IniciaInimigos()
	{
		inimigos=new();
		Inimigo Tonhao = new("Tonhão",  100, 100, 100, 100, 100, 100, 5, 8);
		Inimigo Tiao= new("Tião",200, 115, 100, 100, 100, 100, 8, 5);
		Ataque[] ataques = new Ataque[2];
		Magia[] magias = new Magia[2];
		ataques[0] = new Ataque("Soco", 8, 90, 50);
		ataques[1] = new Ataque("Pedrada", 8, 80, 70);
		magias[0] = new Magia("Lança Chamas", 8, 90, 50);
		magias[1] = new Magia("Bola de fogo", 8, 80, 70);
		Tonhao.ataques=ataques;
		Tonhao.magias=magias;
		Tiao.ataques=ataques;
		Tiao.magias=magias;
		inimigos.Add(Tonhao);
		inimigos.Add(Tiao);

	}
	
//para chamar no estado de inicialização
	public void Inicialização()
	{
		IniciaAliados();
		IniciaInimigos();

	}
	//estado de escolha
	public void EstadoEscolha()
	{
		EscolhaDeAcoes();
	}
	//estado de execução
	public void ExecutaAcoes(MaxHeap heap)
	{
		EfetuaAtaques(heap);

	}
	//estado de fim de turno
	public void FimDeTurno()
	{
		AtualizaListaDeVivos();
	}
	
	
	}

	
	
}