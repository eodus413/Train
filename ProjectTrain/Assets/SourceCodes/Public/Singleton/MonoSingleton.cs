using UnityEngine;
using System.Collections;
using System;
namespace Singleton
{
    public class MonoSingleton<T> : MonoBehaviour where T : MonoBehaviour
    {
        private static WeakReference _container;
        private static WeakReference _instance;

        protected void Awake()
        {
            DontDestroyOnLoad(gameObject);
        }

        public static T Instance
        {
            get
            {
                GameObject container;

                if (_container != null)
                {
                    container = _container.Target as GameObject;
                    if (container != null)
                    {
                        return _instance.Target as T;
                    }
                }

                container = new GameObject();
                container.name = "_" + typeof(T).Name;
                T instance = container.AddComponent(typeof(T)) as T;

                _container = new WeakReference(container, false);
                _instance = new WeakReference(instance, false);

                return instance;
            }
        }
    }
}