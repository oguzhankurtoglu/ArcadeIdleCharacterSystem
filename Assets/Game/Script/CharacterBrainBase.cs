using UnityEngine;
using UnityEngine.AI;

namespace Game.Script
{
    public enum AIState
    {
        Idle,
        Walk,
        Run,
        Processing,
    }

    public abstract class CharacterBrainBase : MonoBehaviour,ICharacter
    {
        #region Fields

        public AIState aiState = AIState.Idle;
        private Character _character;
        public CharacterAnimator Animator { get; set; }
        public Character Character => _character ??= GetComponent<Character>();

        protected NavMeshAgent NavMeshAgent => gameObject.GetComponent<NavMeshAgent>() != null
            ? gameObject.GetComponent<NavMeshAgent>()
            : gameObject.AddComponent<NavMeshAgent>();

        #endregion

        #region Methots
        protected virtual void Start()
        {
            Animator = GetComponentInChildren<CharacterAnimator>();
            InitProperties();
        }
        public abstract void Movement();

        protected virtual void InitProperties()
        {
        }
        public abstract void Logic();

        #endregion
    }
}