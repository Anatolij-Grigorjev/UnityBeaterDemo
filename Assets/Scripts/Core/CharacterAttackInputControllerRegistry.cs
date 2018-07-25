using System;
using System.Collections.Generic;
using BeaterDemo.Input;

namespace BeaterDemo
{
    public class CharacterAttackInputControllerRegistry: HistoryAwareSingleton<CharacterAttackInputControllerRegistry>
    {

        private Dictionary<int, IAttackInputSource> mappingById;

        protected override void OnAwake() {

            mappingById = new Dictionary<int, IAttackInputSource>();



        }

        public void AddAttackInputController(string id, IAttackInputSource controller) {

            AddAttackInputController(id.GetHashCode(), controller);
        }

        public void AddAttackInputController(int id, IAttackInputSource controller) {

            mappingById.Add(id, controller);
        }

        public IAttackInputSource GetController(int id) {

            if (mappingById.ContainsKey(id)) {

                return mappingById[id];
            } else {
                return null;
            }
        }

        public IAttackInputSource GetController(string id) {
            return GetController(id.GetHashCode());
        }
        
    }
}