using BeaterDemo.Const;
using BeaterDemo.Input;

namespace BeaterDemo {
    public class PlayerAttackInputController : CharacterAttackInputController<PlayerInputEvent>, IAttackInputSource {

        Logger log = Logger.getInstance(typeof(PlayerAttackInputController).Name);

        public string attackConrollerId;

        protected override void Awake() {
            inputSource = new PlayerInputSource (ref InputCommands.ALL_ATTACK_COMMANDS);
            base.Awake();

            CharacterAttackInputControllerRegistry.Instance.AddAttackInputController(
                attackConrollerId, this
            );
        }

        public PlayerInputSource inputSource;

        protected override CachedEventInputSource<PlayerInputEvent> createInputSource () {
            return inputSource;
        }

        protected override void ProcessInputs (int newInputsNum) {
            log.Info("Processing {0} inputs", newInputsNum);
            //populate latest hit
            base.ProcessInputs (newInputsNum);

            //this has been filtered down to attack commands so for now try to use as is
        }

        public InputEvent GetLatestAttackInput()
        {
            return latestAttackInput;
        }

        public void ClearLatestAttackInput()
        {
            latestAttackInput = null;
        }
    }
}