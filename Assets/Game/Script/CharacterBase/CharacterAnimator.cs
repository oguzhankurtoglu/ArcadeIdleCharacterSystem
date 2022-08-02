using UnityEngine;

namespace Game.Script.CharacterBase
{
    public class CharacterAnimator : MonoBehaviour
    {
        #region fields

        private Animator _animator;
        private Animator Animator => GetComponent<Animator>();
        private CharacterBrainBase _characterBrainBase;
        private CharacterBrainBase CharacterBrainBase => GetComponentInParent<CharacterBrainBase>();

        #endregion

        public void SetStateTrigger()
        {
            SetTrigger(CharacterBrainBase.aiState.ToString());
        }

        public void SetTrigger(string animationName)
        {
            Animator.SetTrigger(animationName);
        }

        public void SetBool(string animationName, bool animationState)
        {
            Animator.SetBool(animationName, animationState);
        }

        public void SetBool(int animationId, bool animationState)
        {
            Animator.SetBool(animationId, animationState);
        }

        public bool GetBool(int animationId)
        {
            return Animator.GetBool(animationId);
        }

        public void SetFloat(string animationName, float speed)
        {
            Animator.SetFloat(animationName, speed);
        }

        public void SetFloat(int animationId, float speed)
        {
            Animator.SetFloat(animationId, speed);
        }
    }
}