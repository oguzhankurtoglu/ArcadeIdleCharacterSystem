using System.Collections;
using Game.Script.CharacterBrain;
using UnityEngine;

namespace Game.Script.StateMachine
{
    public class CashierState :State
    {
        public CashierState(WorkerBrain brain) : base(brain)
        {
        }

        public override IEnumerator Start()
        {
            var index = Random.Range(0, Brain.waitZone.Count);
            Brain.target = Brain.waitZone[index].transform;
            yield return base.Move();

            Brain.SetState(new CollectState(Brain));
        }
    }
}