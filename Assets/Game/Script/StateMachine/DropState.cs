using System.Collections;
using Game.Script.CharacterBrain;
using UnityEngine;

namespace Game.Script.StateMachine
{
    public class DropState : State
    {
        public DropState(WorkerBrain brain) : base(brain)
        {
        }

        public override IEnumerator Start()
        {
            var index = Random.Range(0, Brain.dropList.Count);
            Brain.target = Brain.dropList[index].transform;
            yield return base.Move();

            Brain.StartCoroutine(SelectNewTarget());
        }
        
    }
}
