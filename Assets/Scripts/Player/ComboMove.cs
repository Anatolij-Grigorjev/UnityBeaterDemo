using UnityEngine;
using System;

namespace BeaterDemo {


    public class ComboMove : MonoBehaviour {

        private static Logger logger = Logger.getInstance(typeof(ComboMove).ToString());

        public Collider2D hitCollider;
        public Vector2 hitPush;
        public Const.SFX hitSound;
        public string enemyTag;
        public string hitName;
        public bool lastHit;
        public string setTrigger;

        private int hitID;
        
        private CharacterController characterController;

        private void Start() {
            hitID = hitName.GetHashCode();
            hitCollider.enabled = false;
            
            characterController = this.gameObject.FindObjectOfType<CharacterController>();
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

            if(!lastHit) {

                InputEvent latestInput = characterController.latestInput;
                if (latestInput != null) {
                    if (InputCommands.CMD_LIGHT_ATTACK.Equals(latestInput.Command)) {
                        setTrigger = HitTriggers.TRIGGER_LIGHT_ATTACK;
                    } 
                    if (InputCommands.CMD_HEAVY_ATTACK.Equals(latestInput.Command)) {
                        setTrigger = HitTriggers.TRIGGER_HEAVY_ATTACK;
                    }
                }
            }

        }
    }
}