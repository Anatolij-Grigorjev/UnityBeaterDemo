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

        protected override boolean ProcessCommand(ref PlayerInputEvent eventTemplate) {
            var cmd = eventTemplate.InputCommand;
            if (Input.GetButtonDown(cmd)) {
                eventTemplate.State = PlayerCommandStates.JUST_PRESSED;
                return true;
            }
            if (Input.GetButton(cmd)) {
                eventTemplate.State = PlayerCommandStates.HELD_DOWN;
                return true;
            }
            if (Input.GetButtonUp(cmd)) {
                eventTemplate.State = PlayerCommandStates.JUST_RELEASED;
                return true;
            }

            return false;
        }

        protected override PlayerInputEvent CreateTemplateValue(string cmd) {

            return new PlayerInputEvent(cmd);
        }
    }
}