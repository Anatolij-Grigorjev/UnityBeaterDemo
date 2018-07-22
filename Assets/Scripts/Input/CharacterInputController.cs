using BeaterDemo.Const;
using UnityEngine;

namespace BeaterDemo.Input
{
    public abstract class CharacterInputController<T> : MonoBehaviour where T: InputEvent {

        public int MAX_INPUTS = 9;

        public CachedEventInputSource<T> characterInputSource;
        public T[] latestInputs;

        protected abstract CachedEventInputSource<T> createInputSource();
        protected virtual T newInputEvent() {

            return characterInputSource.CreateTemplateValue(InputCommands.CMD_NOOP);
        }
        
        protected void Awake() {
            
            characterInputSource = createInputSource();
            latestInputs = new T[MAX_INPUTS];
            for(int i = 0; i < MAX_INPUTS; i++) {
                latestInputs[i] = newInputEvent();
            }
        }


        protected void Update() {
            
            //gather input from source
            int newInputs = characterInputSource.GetInputEvents(ref latestInputs);
            if (newInputs > 0) {
                //rest of inputs
                ProcessInputs(newInputs);
            }
        }

        /// <summary>
        /// Process received inputs given we know how many were actually added for processing
        /// in latestInputs array.
        /// 
        /// lastAttackInput is initialized at this point to be the last recorded attack-related input
        /// </summary>
        /// <param name="numNewInputs">Number of new inputs added for processing in latestInputs array</param>
        protected abstract void ProcessInputs(int numNewInputs);

    }
}
