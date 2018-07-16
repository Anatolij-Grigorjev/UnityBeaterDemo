using UnityEngine;
using System;

namespace BeaterDemo {


    public class ComboMove : MonoBehaviour {

        public Collider2D hitCollider;
        public Vector2 hitPush;
        public Const.SFX hitSound;
        public string enemyTag;
        public string hitName;
        public bool lastHit;
        public string setTrigger;

        private int hitID;

        private void Start() {
            hitID = hitName.GetHashCode();
            hitCollider.enabled = false;
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

                if (UnityEngine.Input.GetButton("NormalAttack")) {
                    setTrigger = HitTriggers.TRIGGER_NORMAL_ATTACK;
                } 
                if (UnityEngine.Input.GetButton("SpecialAttack")) {
                    setTrigger = HitTriggers.TRIGGER_SPECIAL_ATTACK;
                }
            }

        }
    }
}