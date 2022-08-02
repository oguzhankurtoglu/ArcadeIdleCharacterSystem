using Game.Script.CharacterBrain;
using UnityEngine;

namespace Game.Script.Zone
{
    public class WaitZone : MonoBehaviour
    {
        public bool ReachWaitZone { get; set; }

        private void OnTriggerEnter(Collider other)
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