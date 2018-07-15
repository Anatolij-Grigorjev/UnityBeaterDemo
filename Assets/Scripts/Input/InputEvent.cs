namespace BeaterDemo.Input
{
    
    public abstract class InputEvent {

        public string InputCommand;

        public InputEvent(string cmd) {
            InputCommand = cmd;
        }

    }

    public class PlayerInputEvent: InputEvent {

        public PlayerCommandStates State;

        public PlayerInputEvent(string cmd): base(cmd) {

        }

        public void CopyTo(out PlayerInputEvent other) {
            other.InputCommand = this.InputCommand;
            other.State = this.State;
        }
    }

}