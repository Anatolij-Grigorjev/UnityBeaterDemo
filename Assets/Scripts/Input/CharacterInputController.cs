using BeaterDemo.Const;
using UnityEngine;

namespace BeaterDemo.Input
{
    public abstract class CharacterInputController<T> : MonoBehaviour where T: InputEvent {

        public const int MAX_INPUTS = 9;

        public IInputSource<T> characterInputSource;
        public T[] latestInputs;

        [HideInInspector]
        public T latestAttackInput; //latest attack input for any connected combomove

        protected abstract IInputSource<T> createInputSource();
        protected abstract T newInputEvent();
        
        protected void Awake() {
            //filte to movement commands?
            characterInputSource = createInputSource();
            latestInputs = new T[MAX_INPUTS];
            for(int i = 0; i < MAX_INPUTS; i++) {
                latestInputs[i] = newInputEvent();
            }
        }


        private void Update() {
            
            //gather input from source
            int newInputs = characterInputSource.GetInputEvents(ref latestInputs);
            if (newInputs > 0) {
                //TODO: process received inputs

                //get latest attack input from end of array
                latestAttackInput = FirstFromEndAttackInput(newInputs);
            }
        }

        private T FirstFromEndAttackInput(int totalInputs) {
            
            for (int i = totalInputs - 1; i >= 0; i--) {
                if(InputCommands.IsAttackCommand(latestInputs[i].InputCommand)) {

                    return latestInputs[i];
                }
            }

            return null;
        }

    }
}
