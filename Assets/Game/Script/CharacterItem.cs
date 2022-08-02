using UnityEngine;

namespace Game.Script
{
    [CreateAssetMenu(fileName = "Item")]

    public class CharacterItem : ScriptableObject
    {
        public int collectCapacity = 10;
        public float collectDuration = 0.5f;
        public float dropDuration = 0.5f;
        public float movementSpeed = 6;
        public float stoppingDistance;
        public float acceleration;
        public float angularSpeed;
    }
}