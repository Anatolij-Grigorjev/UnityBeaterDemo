using UnityEngine;
using System;
using BeaterDemo.Input;
using BeaterDemo.Const;

namespace BeaterDemo
{
    public class ComboBoundsController: CharacterAttackInputController<InputEvent>
    {
        
        private Logger log = Logger.getInstance(typeof(ComboBoundsController).Name);

        public Animator animController;
        public string inputSourceId;
        private int inputSourceIdCode;
        public bool comboHappening = false;

        protected override CachedEventInputSource<InputEvent> createInputSource()
        {
            return InputSourceRegistry.Instance.GetInputSource<InputEvent>(inputSourceIdCode);
        }

        protected override void Awake() {
            inputSourceIdCode = inputSourceId.GetHashCode();

            base.Awake();

            if (characterInputSource == null) {
                log.Error("characterInputSource = null!!");
            }
            if(animController == null) {
                log.Error("animController = null!!");
            }
        }

        protected override void ProcessInputs(int newInputsNum) {
            base.ProcessInputs(newInputsNum);

            if (!comboHappening) {

                switch(latestAttackInput.InputCommand) {
                    case InputCommands.CMD_LIGHT_ATTACK:
                        animController.SetTrigger(HitTriggers.TRIGGER_LIGHT_ATTACK);
                        break;
                    case InputCommands.CMD_HEAVY_ATTACK:
                        animController.SetTrigger(HitTriggers.TRIGGER_HEAVY_ATTACK);
                        break;
                    default:
                        break;
                }

                comboHappening = true;
            }
        }
    }
}