using BeaterDemo.Const;
using BeaterDemo.Input;

namespace BeaterDemo {
    public class PlayerAttackInputController : CharacterAttackInputController<PlayerInputEvent> {
        protected override CachedEventInputSource<PlayerInputEvent> createInputSource () {
            return new PlayerInputSource (ref InputCommands.ALL_ATTACK_COMMANDS);
        }

        protected override void ProcessInputs (int newInputsNum) {
            //populate latest hit
            base.ProcessInputs (newInputsNum);

            //this has been filtered down to attack commands so for now try to use as is
        }
    }
}