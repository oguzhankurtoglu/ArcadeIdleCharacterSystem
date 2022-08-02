using System.Collections.Generic;
using Game.Script.CharacterBrain;
using Game.Script.Data;
using UnityEngine;

namespace Game.Script.CharacterBase
{
    public class CustomerManager : MonoBehaviour
    {
        public List<Transform> slots;
        public Queue<GameObject> customerQueue = new();
        public Transform spawnPoint;
        public CharacterItem characterItem;
        public float generateTime;
        private Transform _operationPoint;
        private float _timer;

        private void Update()
        {
            Tick();
        }

        #region Methots

        private void Tick()
        {
            _timer += Time.deltaTime;
            if (_timer > generateTime && customerQueue.Count < slots.Count)
            {
                foreach (var item in customerQueue)
                {
                    item.GetComponent<CustomerBrain>().FindTarget();
                    Debug.Log(item);
                }

                var character = CharacterSpawner.Instance.CreateCharacter(characterItem, spawnPoint);
                customerQueue.Enqueue(character);
                _timer = 0;
            }
        }

        #endregion
    }
}