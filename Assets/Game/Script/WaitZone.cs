using UnityEngine;

namespace Game.Script
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