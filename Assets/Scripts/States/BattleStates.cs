using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.States
{
    public abstract class BattleStates
    {
        public abstract void Start(BattleStateMachine fsm);

        public abstract void Work(BattleStateMachine fsm);

        public abstract void End(BattleStateMachine fsm);
    }
}
