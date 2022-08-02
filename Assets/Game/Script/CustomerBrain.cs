using System.Collections;
using System.Linq;
using UnityEngine;

namespace Game.Script
{
    public enum CustomerState
    {
        Bring,
        Drop,
        Wait,
        Collect,
        Destroy
    }

    public class CustomerBrain : CharacterBrainBase
    {
        public Transform target;
        public CustomerState customerState;
        public Transform destroyZone;
        private CustomerManager _customerManager;

        #region Unity Lifecycle

        private void Awake()
        {
            _customerManager = transform.parent.parent.GetComponentInChildren<CustomerManager>();
            customerState = CustomerState.Bring;
            destroyZone = GameObject.FindGameObjectWithTag("DestroyZone").transform;
        }

        protected new void Start()
        {
            base.Start();
        }

        #endregion


        private bool IsDestinationReach()
        {
            float distanceToTarget = Vector3.Distance(transform.position, NavMeshAgent.destination);

            if (distanceToTarget < NavMeshAgent.stoppingDistance)
            {
                return false;
            }

            return true;
        }

        void CheckCustomerSituation()
        {
            switch (customerState)
            {
                case CustomerState.Bring when !IsDestinationReach():
                    customerState = CustomerState.Wait;
                    break;
                case CustomerState.Wait:
                    customerState = CustomerState.Collect;
                    break;
                case CustomerState.Collect :
                    target = destroyZone;
                    customerState = CustomerState.Destroy;
                    _customerManager.customerQueue.Dequeue();
                    Movement();
                    break;
                case CustomerState.Destroy:
                    break;
            }
        }


        public void FindTarget()
        {
            target = _customerManager.slots[_customerManager.customerQueue.ToList().IndexOf(transform.gameObject)];
            Movement();
        }

        protected override void InitProperties()
        {
            base.InitProperties();
            NavMeshAgent.speed = characterItem.movementSpeed;
            NavMeshAgent.stoppingDistance = characterItem.stoppingDistance;
            NavMeshAgent.acceleration = characterItem.acceleration;
            NavMeshAgent.angularSpeed = characterItem.angularSpeed;

            FindTarget();
        }

        public override void Logic()
        {
            IsDestinationReach();
            CheckCustomerSituation();
            Animator.SetFloat("Velocity", NavMeshAgent.velocity.magnitude);

        }

        public override void Movement()
        {
            NavMeshAgent.SetDestination(target.position);
        }
    }
}