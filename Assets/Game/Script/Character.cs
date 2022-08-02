using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    #endregion
}
