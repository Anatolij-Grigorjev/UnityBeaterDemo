using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

namespace BeaterDemo.SMB {
    public class ComboMoveSMB : StateMachineBehaviour {
        private Logger log;
        public Const.CharacterTypes characterType;
        public string comboMoveName = "";
        private int comboMoveID;
        public int colliderStartWaitFrames = -1; //how many frames of animation are played before hit collider is enabled? -1 means immediately
        public int colliderEndAfterFrames = -1; //how many frames of animation are played before hit collider is disabled? -1 means at very end
        private int currentFrameCounter = 0;
        private ComboMove moveCache; //cache updated every time animation is entered

        public ComboMoveSMB () : base () {
            
            comboMoveID = -1;
            log = Logger.getInstance (String.Format ("{0}-{1}-{2}", typeof (ComboMoveSMB).ToString (), characterType.ToString (), comboMoveName));
        }

        public override void OnStateEnter (Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
            currentFrameCounter = 0;
            if (comboMoveID == -1 && !String.IsNullOrEmpty(comboMoveName)) {
                comboMoveID = comboMoveName.GetHashCode();
            }
            var charTypeMoves = ComboMovesRegistry.Instance.getCharTypeMoves (characterType);
            log.Info("Starting move animation, move id: {0}", comboMoveID);

            if (comboMoveID != -1 && !charTypeMoves.TryGetValue (comboMoveID, out moveCache)) {
                log.Error ("No move found for description string {0}, id: {1}!", comboMoveName, comboMoveID);

            }
            if (moveCache != null) {
                if (colliderStartWaitFrames < 0) {
                    moveCache.EnableCollider ();
                }
                moveCache.isPending = true;
                log.Info("move is pending...");
            } else {
                log.Info("no move cache!");
            }
        }

        public override void OnStateExit (Animator animator, AnimatorStateInfo stateInfo, int layerIndex, AnimatorControllerPlayable controller) {
            log.Info("State exit for {0}", comboMoveName);
            if (moveCache != null) {
                moveCache.DisableCollider ();

                var nextTrigger = moveCache.ConsumeNextActionTrigger ();
                log.Info("extracted trigger: {0}", nextTrigger);
                if (nextTrigger != null) {
                    animator.SetTrigger (nextTrigger);
                }
                moveCache.FinishHit(nextTrigger != null);
                moveCache = null;
            }
        }

        public override void OnStateUpdate (Animator animator, AnimatorStateInfo stateInfo, int layerIndex, AnimatorControllerPlayable controller) {
            currentFrameCounter++;
            log.Info("processing frame {0}", currentFrameCounter);
            if (moveCache != null) {
                if (colliderStartWaitFrames < currentFrameCounter && !moveCache.ColliderEnabled ()) {
                    moveCache.EnableCollider ();
                }

                if (colliderEndAfterFrames < currentFrameCounter && moveCache.ColliderEnabled ()) {
                    moveCache.DisableCollider ();
                }
            }
        }
    }
}