using System.Collections;
using Game.Script.CharacterBrain;
using UnityEngine;

namespace Game.Script.StateMachine
{
    public abstract class State
    {
        protected readonly WorkerBrain Brain;
        protected int index;

        protected State(WorkerBrain brain)
        {
            Brain = brain;
        }

        public virtual IEnumerator Start()
        {
            yield break;
        }

        protected virtual IEnumerator Move()
        {
            Brain.Movement();
            yield return new WaitUntil(() => !Brain.IsDestinationReach());
        }

        protected virtual IEnumerator SelectNewTarget()
        {
            //yield return new WaitUntil(() => Brain.IsDestinationReach());
            //var random = Random.Range(0,2);
            var random = Random.Range(0,2);
            switch (random)
            {
                case 0:
                    Brain.SetState(new CollectState(Brain));
                    break;
                case 1:
                    Brain.SetState(new CashierState(Brain));
                    break;
            }
            yield break;
        }
    }
}