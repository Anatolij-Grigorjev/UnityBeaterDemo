using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

namespace BeaterDemo.SMB
{
    public class ComboMoveSMB: StateMachineBehaviour
    {
        private static Logger logger = Logger.getInstance(typeof(ComboMoveSMB).ToString());
        public Const.CharacterTypes characterType;
        public string comboMoveName;
        private int comboMoveID;
        public int colliderStartWaitFrames = -1; //how many frames of animation are played before hit collider is enabled? -1 means immediately
        public int colliderEndAfterFrames = -1; //how many frames of animation are played before hit collider is disabled? -1 means at very end
        private int currentFrameCounter = 0;
        private ComboMove moveCache; //cache updated every time animation is entered

        public ComboMoveSMB(): base() {
            comboMoveID = comboMoveName.GetHashCode();
        }

        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
            currentFrameCounter = 0;
            var charTypeMoves = ComboMovesRegistry.Instance.getCharTypeMoves(characterType);
            if (!charTypeMoves.TryGetValue(comboMoveID, out moveCache)) {
                //TODO: did not get move for animation, use logger
                
            }
            if (colliderStartWaitFrames < 0 && moveCache != null) {
                moveCache.EnableCollider();
            }
        }

        public override  void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex, AnimatorControllerPlayable controller) {

            moveCache = null;
        }

        public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex, AnimatorControllerPlayable controller) {
            currentFrameCounter++;
            
        }
    }
}