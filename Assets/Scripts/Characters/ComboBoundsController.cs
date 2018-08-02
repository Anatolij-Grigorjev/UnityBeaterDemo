using UnityEngine;
using System;
using System.Collections.Generic;
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
            
            var comboMoves = gameObject.GetComponents<ComboMove>();
            log.AssertNotNull(comboMoves);

            log.Info("setting bounds to {0} moves...", comboMoves.Length);
            foreach (var move  in comboMoves)
            {
                move.SetBounds(this);
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
            log.Info("resetting combo...");
            comboHappening = false;
        }
    }
}