using UnityEngine;

namespace Game.Script
{
    public abstract class MonoSingleton <T> : MonoBehaviour where T : MonoSingleton<T>
    {
   
        private static T _instance;

        private static object _lock = new object();

        public static T Instance
        {
            get
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = (T)FindObjectOfType(typeof(T));

                        if (FindObjectsOfType(typeof(T)).Length > 1)
                        {
                            Debug.LogError("[Singleton] Something went really wrong " +
                                           " - there should never be more than 1 singleton!" +
                                           " Reopening the Init scene and destroying all instances");
                        
                            return null;
                        }
                    }
                    return _instance;
                }
            }
        }
    }
}