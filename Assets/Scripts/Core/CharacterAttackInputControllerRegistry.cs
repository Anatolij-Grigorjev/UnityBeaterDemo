using System;
using System.Collections.Generic;
using BeaterDemo.Input;

namespace BeaterDemo
{
    public class CharacterAttackInputControllerRegistry: HistoryAwareSingleton<CharacterAttackInputControllerRegistry>
    {

        private Dictionary<int, CharacterAttackInputController<InputEvent>> mappingById;

        protected override void OnAwake() {

            mappingById = new Dictionary<int, CharacterAttackInputController<InputEvent>>();



        }

        public void AddAttackInputController(string id, CharacterAttackInputController<InputEvent> controller) {

            AddAttackInputController(id.GetHashCode(), controller);
        }

        public void AddAttackInputController(int id, CharacterAttackInputController<InputEvent> controller) {

            mappingById.Add(id, controller);
        }

        public CharacterAttackInputController<InputEvent> GetController(int id) {

            if (mappingById.ContainsKey(id)) {

                return mappingById[id];
            } else {
                return null;
            }
        }

        public CharacterAttackInputController<InputEvent> GetController(string id) {
            return GetController(id.GetHashCode());
        }
        
    }
}