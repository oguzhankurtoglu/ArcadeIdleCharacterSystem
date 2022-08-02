using System.Linq;
using Game.Script.CharacterBase;
using Game.Script.Zone;
using UnityEngine;

namespace Game.Script.CharacterBrain
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
        [SerializeField] private WaitZone waitZone;


        #region Unity Lifecycle

        private void Awake()
        {
            var parent = transform.parent;
            _customerManager = parent.parent.GetComponentInChildren<CustomerManager>();
            customerState = CustomerState.Bring;
            destroyZone = GameObject.FindGameObjectWithTag("DestroyZone").transform;
            waitZone = transform.root.GetComponentInChildren<WaitZone>();
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
                    customerState = CustomerState.Drop;
                    break;
                case CustomerState.Collect when waitZone.ReachWaitZone:
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
            if (_customerManager.customerQueue.ToList().IndexOf(transform.gameObject) == 0)
            {
                customerState = CustomerState.Collect;
            }
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