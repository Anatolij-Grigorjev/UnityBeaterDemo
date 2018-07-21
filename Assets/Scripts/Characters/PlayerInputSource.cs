using System;
using System.Collections;
using BeaterDemo.Input;
using BeaterDemo.Const;
using UnityEngine;

namespace BeaterDemo
{
    public class PlayerInputSource: CachedEventInputSource<PlayerInputEvent> {

        public PlayerInputSource(): base(ref InputCommands.ALL_PLAYER_COMMANDS) {

        }

        public PlayerInputSource(ref string[] commandsFilter): base(ref commandsFilter) {
            
        }

        protected override bool ProcessCommand(PlayerInputEvent eventTemplate) {
            var cmd = eventTemplate.InputCommand;
            if (UnityEngine.Input.GetButtonDown(cmd)) {
                eventTemplate.State = PlayerCommandStates.JUST_PRESSED;
                return true;
            }
            if (UnityEngine.Input.GetButton(cmd)) {
                eventTemplate.State = PlayerCommandStates.HELD_DOWN;
                return true;
            }
            if (UnityEngine.Input.GetButtonUp(cmd)) {
                eventTemplate.State = PlayerCommandStates.JUST_RELEASED;
                return true;
            }

            return false;
        }

        public override PlayerInputEvent CreateTemplateValue(string cmd) {

            return new PlayerInputEvent(cmd);
        }
    }
}