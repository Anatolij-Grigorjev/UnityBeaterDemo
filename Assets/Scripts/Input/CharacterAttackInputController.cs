using BeaterDemo.Const;

namespace BeaterDemo.Input {

    public abstract class CharacterAttackInputController<T>: CharacterInputController<T> where T: InputEvent {

        public T latestAttackInput;

        protected T FirstFromEndAttackInput(int totalInputs) {
            
            for (int i = totalInputs - 1; i >= 0; i--) {
                if(InputCommands.IsAttackCommand(latestInputs[i].InputCommand)) {

                    return latestInputs[i];
                }
            }

            return null;
        }

        protected override void ProcessInputs(int newInputsNum) {
            
            if (newInputsNum > 0) {
                latestAttackInput = FirstFromEndAttackInput(newInputsNum);
            }
        }

    }

}