using UnityEngine;
using BeaterDemo.Input;

namespace BeaterDemo
{
    public class PlayerController : MonoBehaviour {

        public const int MAX_INPUTS = 9;

        public IInputSource<PlayerInputEvent> playerInputSource;
        public PlayerInputEvent[] latestInputs;

        
        private void Awake() {
            //filte to movement commands?
            playerInputSource = new PlayerInputSource();
            latestInputs = new PlayerInputEvent[MAX_INPUTS];
            for(int i = 0; i < MAX_INPUTS; i++) {
                latestInputs[i] = new PlayerInputEvent();
            }
        }


        private void Update() {
            
            //gather input from source
            int newInputs = playerInputSource.GetInputEvents(ref latestInputs);
            if (newInputs > 0) {
                //TODO: process received inputs
            }
        }

    }
}
