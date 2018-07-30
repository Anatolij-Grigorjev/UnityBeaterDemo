using System;
using System.Collections.Generic;
using BeaterDemo.Input;

namespace BeaterDemo
{
    public class InputSourceRegistry: HistoryAwareSingleton<InputSourceRegistry>
    {

        static class PerInputEventType<T> where T: InputEvent {
            public static Dictionary<int, CachedEventInputSource<T>> mappingById = new Dictionary<int, CachedEventInputSource<T>>();
        }

        protected override void OnAwake() {

           
        }

        public void AddInputSource<T>(string id, CachedEventInputSource<T> controller) where T: InputEvent {

            AddInputSource(id.GetHashCode(), controller);
        }

        public void AddInputSource<T>(int id, CachedEventInputSource<T> controller) where T: InputEvent {

            PerInputEventType<T>.mappingById.Add(id, controller);
        }

        public CachedEventInputSource<T> GetInputSource<T>(int id) where T: InputEvent {

            if (PerInputEventType<T>.mappingById.ContainsKey(id)) {

                return PerInputEventType<T>.mappingById[id];
            } else {
                return null;
            }
        }

        public CachedEventInputSource<T> GetInputSource<T>(string id) where T: InputEvent {
            return GetInputSource<T>(id.GetHashCode());
        }
        
    }
}