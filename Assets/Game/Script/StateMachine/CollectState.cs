using System.Collections;
using Game.Script.CharacterBrain;
using UnityEngine;

namespace Game.Script.StateMachine
{
    public class CollectState : State
    {
        public CollectState(WorkerBrain brain) : base(brain)
        {
        }

        public override IEnumerator Start()
        {
            Brain.StartCoroutine(Collecting());
            return base.Start();
        }

        private IEnumerator Collecting()
        {
            Brain.target = Brain.collectList[Random.Range(0, Brain.collectList.Count)]
                .transform;
            yield return base.Move();
            
            Brain.SetState(new DropState(Brain));
        }
    }
}