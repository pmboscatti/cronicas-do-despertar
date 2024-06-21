using Assets.Scripts.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine.SceneManagement;
using UnityEngine;


namespace Assets.Scripts.States
{
    public class BattleStateEnd : BattleStates
    {
        public static List<Action<BattleStateMachine>> evento_NovoTurno = new();
        BattleStateMachine fsm;

        public override void Start(BattleStateMachine fsm)
        {
            Debug.Log("Estado alcançando.");
            this.fsm = fsm;

            Stack<int> aSerRemovido = new(); 
            for(int i = 0; i <  fsm.aliados.Count; i++)
            {
                if (!fsm.aliados[i].vivo)
                {
                    aSerRemovido.Push(i);
                }
            }


            while (aSerRemovido.Count > 0)
            {
                int i = aSerRemovido.Pop();

                fsm.aliados.RemoveAt(i);

            }

            aSerRemovido = new();

            for (int i = 0; i < fsm.inimigos.Count; i++)
            {
                if (!fsm.inimigos[i].vivo)
                {
                    aSerRemovido.Push(i);
                }
            }

            while (aSerRemovido.Count > 0)
            {
                int i = aSerRemovido.Pop();

                fsm.inimigos.RemoveAt(i);

            }


            if (verificaFIM() != "BATALHA CONTINUA")
            {
                // fim da batalha
                SceneManager.UnloadSceneAsync("Battle01");
                return;
            }




            fsm.TrocaEstado(fsm.battleStateChoice);

        }

        public override void Work(BattleStateMachine fsm)
        {
            
        }

        public override void End(BattleStateMachine fsm)
        {
            Debug.Log("Chamando controlador UI");
            foreach(Action<BattleStateMachine> evento in evento_NovoTurno)
            {
                evento(fsm);
            }



            fsm.acoesRodada = null;
        }

        string verificaFIM()
        {
            if (fsm.inimigos.Count == 0 && fsm.aliados.Count == 0) return "EMPATE";
            else if (fsm.inimigos.Count < 1) return "VITORIA ALIADA";
            else if (fsm.aliados.Count < 1) return "DERROTA";
            else return "BATALHA CONTINUA";
        }

    }
}
