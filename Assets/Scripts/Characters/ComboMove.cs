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
        public bool isPending;
        public string setTrigger;

        private int hitID;
        
        private IAttackInputSource characterController;
        private ComboBoundsController comboBounds;

        private void Awake() {
            logger = Logger.getInstance(String.Format("{0}-{1}-{2}", typeof(ComboMove).ToString(), controllerId, hitName));
            hitID = hitName.GetHashCode();
            //insert move into registry
            ComboMovesRegistry.Instance.getCharTypeMoves(characterType).Add(hitID, this);
        }

        private void Start() {

            hitCollider.enabled = false;
            
            characterController = AttackInputSourceRegistry.Instance.GetAttackInputSource(controllerId);
            
            logger.AssertNotNull(characterController);
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

            if(!lastHit && isPending) {

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

        public void FinishHit(bool triggeredMore) {

            isPending = false;
            if(lastHit || !triggeredMore) {
                comboBounds.ResetComboBounds();
            }
        }

        public void SetBounds(ComboBoundsController bounds) {
            comboBounds = bounds;
        }
    }
}