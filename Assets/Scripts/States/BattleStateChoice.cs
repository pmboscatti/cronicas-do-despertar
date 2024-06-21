using Assets.Scripts.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Scripts.IA;

namespace Assets.Scripts.States
{
    public class BattleStateChoice : BattleStates
    {
        BattleStateMachine fsm;

        Queue<Personagem> filaAEscolher;

        List<Acao> acoes;



        public override void Start(BattleStateMachine fsm)
        {
            this.fsm = fsm;

            fsm.acoesRodada = new MaxHeap();
            acoes = new List<Acao>();
            filaAEscolher = new Queue<Personagem>();

            foreach (Personagem p in fsm.aliados)
            {
                filaAEscolher.Enqueue(p);
            }

           fsm.TrocaEstado(fsm.battleStateExecute);

        }

        public override void Work(BattleStateMachine fsm)
        {
            if (filaAEscolher.Count > 0)
            {
                // como teria que ser
                // Inimigo alvo = obtem alvo
                // Personagem ator = abtem ator
                // 
            }
        }

        public override void End(BattleStateMachine fsm)
        {
            Decisoes();
            IniciaMax(acoes);
        }

        void Decisoes()
        {
            //obter lista de ações


            DecisaoIA(acoes);
        }

        void DecisaoIA(List<Acao> lista)
        {
            foreach (Inimigo p in fsm.inimigos)
            {
                 GrafoDecisao grafo = new(p);
                 lista.Add(grafo.Dijkstra(fsm.inimigos, fsm.aliados));
               
            }
        }

        public MaxHeap IniciaMax(List<Acao> listaAcoes)
        {
            MaxHeap heap = fsm.acoesRodada;
            foreach (Acao acao in listaAcoes)
            {
                heap.Insert(acao);
            }
            return heap;
        }

    }
}
