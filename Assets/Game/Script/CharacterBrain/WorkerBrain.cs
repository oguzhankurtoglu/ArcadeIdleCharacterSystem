using System.Collections.Generic;
using System.Linq;
using Game.Script.CharacterBase;
using Game.Script.StateMachine;
using Game.Script.Storage;
using Game.Script.Zone;
using UnityEngine;

namespace Game.Script.CharacterBrain
{
    public class WorkerBrain : CharacterBrainBase
    {
        [SerializeField] public State previousState;
        [SerializeField] public List<InputStorage> collectList;
        [SerializeField] public List<GameObject> zoneList;
        [SerializeField] public List<OutputStorage> dropList;
        [SerializeField] public List<WaitZone> waitZone;
        [SerializeField] public Transform target;
        private State _currentState;

        private void FindRelatedZone() // Find related zones, each ai must know own currencies
        {
            zoneList.AddRange(GameObject.FindGameObjectsWithTag("Zone"));
            var collect = zoneList.SelectMany(i => i.transform.GetComponentsInParent<InputStorage>()
                .Where(r => r != null));
            collectList = collect.ToList();
            var drop = zoneList.SelectMany(o => o.transform.GetComponentsInParent<OutputStorage>()
                .Where(r => r != null));
            dropList = drop.ToList();

            var wait = zoneList.SelectMany(o => o.transform.GetComponentsInParent<WaitZone>()
                .Where(r => r != null));
            waitZone = wait.ToList();

            SetState(new CollectState(this));
        }

        #region CustomMethots

        public void SetState(State state)
        {
            previousState = _currentState;
            _currentState = state;
            StartCoroutine(_currentState.Start());
        }

        public bool IsDestinationReach()
        {
            var distanceToTarget = Vector3.Distance(transform.position, NavMeshAgent.destination);
            Animator.SetFloat("Magnitude", NavMeshAgent.velocity.magnitude);
            return !(distanceToTarget < NavMeshAgent.stoppingDistance);
        }

        #endregion

        #region Methots

        protected override void InitProperties()
        {
            base.InitProperties();

            NavMeshAgent.speed = characterItem.movementSpeed;
            NavMeshAgent.stoppingDistance = characterItem.stoppingDistance;
            NavMeshAgent.acceleration = characterItem.acceleration;
            NavMeshAgent.angularSpeed = characterItem.angularSpeed;
            FindRelatedZone();
        }

        public override void Logic()
        {
            IsDestinationReach();
        }

        public override void Movement()
        {
            NavMeshAgent.SetDestination(target.position);
        }

        #endregion
    }
}