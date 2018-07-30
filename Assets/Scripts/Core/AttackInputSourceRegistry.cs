using System;
using System.Collections.Generic;
using BeaterDemo.Input;

namespace BeaterDemo
{
    public class AttackInputSourceRegistry: HistoryAwareSingleton<AttackInputSourceRegistry>
    {

        private Dictionary<int, IAttackInputSource> mappingById;

        protected override void OnAwake() {

            mappingById = new Dictionary<int, IAttackInputSource>();



        }

        public void AddAttackInputSource(string id, IAttackInputSource controller) {

            AddAttackInputSource(id.GetHashCode(), controller);
        }

        public void AddAttackInputSource(int id, IAttackInputSource controller) {

            mappingById.Add(id, controller);
        }

        public IAttackInputSource GetAttackInputSource(int id) {

            if (mappingById.ContainsKey(id)) {

                return mappingById[id];
            } else {
                return null;
            }
        }

        public IAttackInputSource GetAttackInputSource(string id) {
            return GetAttackInputSource(id.GetHashCode());
        }
        
    }
}