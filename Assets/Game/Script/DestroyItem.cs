using System;
using UnityEngine;

namespace Game.Script
{
    public class DestroyItem : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            Destroy(other.gameObject);
        }
    }
}