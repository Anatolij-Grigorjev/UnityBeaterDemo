using UnityEngine;
using System;
using BeaterDemo.Input;
using BeaterDemo.Const;

namespace BeaterDemo {


    public class ComboMove : MonoBehaviour {

        private Logger logger; 

        public Collider2D hitCollider;
        public Vector2 hitPush;
        public Const.CharacterTypes characterType;
        public Const.SFX hitSound;
        public string enemyTag;
        public string hitName;
        public string controllerId;
        public bool lastHit;
        public bool isActive;
        public string setTrigger;

        private int hitID;
        
        private IAttackInputSource characterController;

        private void Awake() {
            logger = Logger.getInstance(String.Format("{0}-{1}-{2}", typeof(ComboMove).ToString(), controllerId, hitName));
        }

        private void Start() {

            hitID = hitName.GetHashCode();
            //insert move into registry
            ComboMovesRegistry.Instance.getCharTypeMoves(characterType).Add(hitID, this);

            hitCollider.enabled = false;
            
            characterController = CharacterAttackInputControllerRegistry.Instance.GetController(controllerId);
            
            if (characterController == null) {
                logger.Error("No character controller for ComboMove " + this.ToString());
            }
        }


        public void EnableCollider() {
            hitCollider.enabled = true;
            ResetNextActionTrigger();
        }

        public void DisableCollider() {
            hitCollider.enabled = false;
        }

        public bool ColliderEnabled() {
            return hitCollider.enabled;
        }

        private void ResetNextActionTrigger() {
            setTrigger = null;
        }

        
        public string ConsumeNextActionTrigger() {
            string triggerValue = null;
            if (setTrigger != null) {
                triggerValue = string.Copy(setTrigger);
                setTrigger = null;
            }

            return triggerValue;
        }

        //hurt other if they are a character and remain within our trigger
        private void OnTriggerStay2D(Collider2D other) {
            
            if (other != null && other.CompareTag(enemyTag)) {
                //do the pain
            }
        }

        void Update() {

            if(!lastHit && isActive) {

                InputEvent latestInput = characterController.GetLatestAttackInput();
                
                if (latestInput != null) {
                    logger.Info("Got latest attack input: {0}", latestInput.InputCommand);
                    if (InputCommands.CMD_LIGHT_ATTACK.Equals(latestInput.InputCommand)) {
                        setTrigger = HitTriggers.TRIGGER_LIGHT_ATTACK;
                    } 
                    if (InputCommands.CMD_HEAVY_ATTACK.Equals(latestInput.InputCommand)) {
                        setTrigger = HitTriggers.TRIGGER_HEAVY_ATTACK;
                    }
                    //consume attack event after setting trigger
                    characterController.ClearLatestAttackInput();
                }
            }

        }
    }
}