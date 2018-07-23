using BeaterDemo.Const;
using BeaterDemo.Input;

namespace BeaterDemo {
    public class PlayerAttackInputController : CharacterAttackInputController<PlayerInputEvent> {

        private class PlayerInputSourceAdapter : CachedEventInputSource<InputEvent>
        {
            private PlayerInputSource parent;

            public PlayerInputSourceAdapter(PlayerInputSource parent) : base(ref parent.sourceCommands)
            {
                this.parent = parent;
            }

            public override InputEvent CreateTemplateValue(string command)
            {
                return parent.CreateTemplateValue(command);
            }

            public override bool ProcessCommand(InputEvent eventTemplate)
            {
                return parent.ProcessCommand(new PlayerInputEvent(eventTemplate.InputCommand));
            }
        }

        private class PlayerAttackInputControllerAdapter : CharacterAttackInputController<InputEvent>
        {
            private PlayerAttackInputController parent;

            public PlayerAttackInputControllerAdapter(PlayerAttackInputController parent) {
                this.parent = parent;
            }

            protected override CachedEventInputSource<InputEvent> createInputSource()
            {
                return new PlayerInputSourceAdapter(parent.inputSource);
            }

            protected override void ProcessInputs(int newInputsNum) {
                parent.ProcessInputs(newInputsNum);
            }
        } 

        public string attackConrollerId;

        protected override void Awake() {
            inputSource = new PlayerInputSource (ref InputCommands.ALL_ATTACK_COMMANDS);
            base.Awake();

            CharacterAttackInputControllerRegistry.Instance.AddAttackInputController(
                attackConrollerId, new PlayerAttackInputControllerAdapter(this)
            );
        }

        public PlayerInputSource inputSource;

        protected override CachedEventInputSource<PlayerInputEvent> createInputSource () {
            return inputSource;
        }

        protected override void ProcessInputs (int newInputsNum) {
            //populate latest hit
            base.ProcessInputs (newInputsNum);

            //this has been filtered down to attack commands so for now try to use as is
        }
    }
}