using System;
using System.Collections;
using System.Collections.Generic;
using Game.Script;
using UnityEngine;

namespace Game.Script.CharacterBase
{
    public enum CharacterType
    {
        Player,
        AI
    }

    public enum AIBrainType
    {
        None,
        Idle,
        Worker,
        Customer
    }

    public class Character : MonoBehaviour
    {
        #region fields

        public CharacterType characterType;
        public AIBrainType aiBrainType;
        private ICharacter _characterProps;
        public ICharacter CharacterProps => _characterProps ??= GetComponent<ICharacter>();


        private void Update()
        {
            CharacterProps.Logic();
        }

   

        #endregion
    }
}