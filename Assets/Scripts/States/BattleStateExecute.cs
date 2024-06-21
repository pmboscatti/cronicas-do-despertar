using Assets.Scripts.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.States
{
    public class BattleStateExecute : BattleStates
    {
        public static List<Action<BattleStateMachine>> evento_ComecaExecutar = new();
        public override void Start(BattleStateMachine fsm)
        {

            foreach(Action<BattleStateMachine> evento in evento_ComecaExecutar)
            {
                evento(fsm);
            }

            ExecutaAcoes(fsm.acoesRodada);

           // fsm.TrocaEstado(fsm.battleStateEnd);
        }

        public override void Work(BattleStateMachine fsm)
        {   
            
        }

        public override void End(BattleStateMachine fsm)
        {
            
        }

        void EfetuaAtaques(MaxHeap heap)
        {
            while (heap.Count > 0)
            {
                Acao acao = heap.ExtractMax();
                if (acao.GetAtor().vivo && acao.GetAlvo().vivo)
                {
                    acao.EfetuaAcao();
                }
                if (acao.GetAlvo().vivo == false)
                {
                    //gerar animação de morte do alvo;
                }

            }
        }

        public void ExecutaAcoes(MaxHeap heap)
        {
            EfetuaAtaques(heap);

        }


    }
}
