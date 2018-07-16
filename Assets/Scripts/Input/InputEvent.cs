namespace BeaterDemo.Input
{
    
    public abstract class InputEvent {

        public string InputCommand;

        public InputEvent(string cmd) {
            InputCommand = cmd;
        }

        public virtual void CopyTo(InputEvent other) {
            other.InputCommand = this.InputCommand;
        }

    }

    public class PlayerInputEvent: InputEvent {

        public PlayerCommandStates State;

        public PlayerInputEvent(string cmd): base(cmd) {

        }

        public override void CopyTo(InputEvent other) {

            base.CopyTo(other);
            if (other is PlayerInputEvent) {
                ((PlayerInputEvent)other).State = this.State;
            }
        }

    }

}