using System.Collections.Generic;
using Game.Script.CharacterBrain;
using Game.Script.Data;
using UnityEngine;

namespace Game.Script.CharacterBase
{
    public class CustomerManager:MonoBehaviour
    {
        public List<Transform> slots;
        public Queue<GameObject> customerQueue = new();
        private Transform _operationPoint;
        public Transform spawnPoint;
        public CharacterItem characterItem;
        public float generateTime;
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
                }
                var character = CharacterSpawner.Instance.CreateCharacter(characterItem, spawnPoint);
                customerQueue.Enqueue(character);
                _timer = 0;
            }
        }
        #endregion
    }
}