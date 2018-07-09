using UnityEngine;
using System;

namespace BeaterDemo {


    public class ComboMove : MonoBehaviour {

        public Collider2D hitCollider;
        public Vector2 hitPush;
        public Const.SFX hitSound;
        public string enemyTag;
        public string hitName;
        private long hitID;

        private void Start() {
            hitID = hitName.GetHashCode() + TimeUtils.CurrentUnixTime();
            hitCollider.enabled = false;
        }


        public void EnableCollider() {
            hitCollider.enabled = true;
        }

        public void DisableCollider() {
            hitCollider.enabled = false;
        }

        //hurt other if they are a character and remain within our trigger
        private void OnTriggerStay2D(Collider2D other) {
            
            if (other != null && other.CompareTag(enemyTag)) {
                //do the pain
            }
        }
    }
}