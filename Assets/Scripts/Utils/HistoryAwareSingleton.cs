using System;
using UnityEngine;

namespace BeaterDemo {
    public abstract class HistoryAwareSingleton<T> : MonoBehaviour where T: HistoryAwareSingleton<T> {
        public static T Instance {
            get {
                if (instance != null) {
                    return instance;
                }

                instance = FindObjectOfType<T> ();

                return instance;
            }
        }

        protected static T instance;

        protected T old_instance;

        void Awake () {
            //deal with old instance
            if (Instance != null && Instance != this) {

                FoundOldInstance();

                old_instance = Instance;
            }
            instance = this as T;

            OnAwake();
        }

        void Start() {
            //deal with old instance
            if (old_instance != null) {
                PreOldDestroy();
                Destroy(old_instance);
            }

            OnStart();
        }

        /// <summary>
        /// Called in Awake method. Happens when on awake this object notices another
        /// instance already in existence. This method can be used
        /// to salvage bits of the old instance before its destroyed on Start
        /// </summary>
        protected virtual void FoundOldInstance() {}
        /// <summary>
        /// Regular Awake logic goes here, apart from old instance bookeeping
        /// </summary>
        protected virtual void OnAwake() {}
        /// <summary>
        /// Regular Start logic goes here, apart from old instance bookeeping
        /// </summary>
        protected virtual void OnStart() {}
        /// <summary>
        /// Called before old instance is destroyd in Start
        /// </summary>
        protected virtual void PreOldDestroy() {}
    }
}