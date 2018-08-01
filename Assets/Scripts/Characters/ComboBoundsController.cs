using UnityEngine;
using System;
using BeaterDemo.Input;
using BeaterDemo.Const;

namespace BeaterDemo
{
    public class ComboBoundsController: CharacterAttackInputController<InputEvent>
    {
        
        private Logger log = Logger.getInstance(typeof(ComboBoundsController).FullName);

        public CharacterTypes cahracterType;
        public Animator animController;
        public string comboStartId;
        public string comboEndId;

        public bool comboHappening = false;

        protected override void Awake() {

            base.Awake();
        }

        protected override void Start() {

            base.Start();

            log.AssertNotNull(characterInputSource);
            log.AssertNotNull(animController);
            log.AssertNotNull(comboEndId);
            ComboMove lastMove;
            var fetched = ComboMovesRegistry.Instance.
                getCharTypeMoves(cahracterType).TryGetValue(comboEndId.GetHashCode(), out lastMove);
            log.AssertNotNull(lastMove);

            if (!lastMove.lastHit) {
                log.Error("Combo move {0} is not marked as last hit!!!", lastMove.hitName);
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

        public void ResetComboBounds() {
            comboHappening = false;
        }
    }
}