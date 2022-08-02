using Game.Script.CharacterBrain;
using UnityEngine;

namespace Game.Script.Zone
{
    public class WaitZone : MonoBehaviour
    {
        private float _timer;
        public bool ReachWaitZone { get; set; }

        private void OnTriggerStay(Collider other)
        {
            if (other.TryGetComponent(out WorkerBrain _))
            {
                ReachWaitZone = true;
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.TryGetComponent(out WorkerBrain _) )
            {
                ReachWaitZone = false;
            }
        }
    }
}