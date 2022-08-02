using System.Collections;
using UnityEngine;

namespace Game.Script
{
    public static class Executer
    {
        private static IEnumerator _coroutine;

        public static void RunAfter(this MonoBehaviour monoBehaviour, float duration, System.Action action)
        {
            _coroutine = CreateRoutine(duration, action);
            StartRoutine(monoBehaviour);
        }

        private static IEnumerator CreateRoutine(float duration, System.Action action)
        {
            yield return new WaitForSeconds(duration);
            
            if (_coroutine != null)
            {
                action();
            }
        }
        
        private static void StartRoutine(MonoBehaviour monoBehaviour)
        {
            monoBehaviour.StartCoroutine(_coroutine);
        }
    }
}