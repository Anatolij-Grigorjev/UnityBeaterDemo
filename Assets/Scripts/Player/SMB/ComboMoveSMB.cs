using System;
using UnityEngine;
using UnityEngine.Animations;

namespace BeaterDemo.SMB
{
    public class ComboMoveSMB: StateMachineBehaviour
    {
        public Const.CharacterTypes characterType;
        public string comboMoveName;
        private int comboMoveID;
        public int colliderStartWaitFrames = -1; //how many frames of animation are played before hit collider is enabled? -1 means immediately
        public int colliderEndAfterFrames = -1; //how many frames of animation are played before hit collider is disabled? -1 means at very end
        private int currentFrameCounter = 0;

        public ComboMoveSMB(): base() {
            comboMoveID = comboMoveName.GetHashCode();
        }

        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
            currentFrameCounter = 0;
            
        }

        public override  void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex, AnimatorControllerPlayable controller) {

        }

        public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex, AnimatorControllerPlayable controller) {
            currentFrameCounter++;
        }
    }
}