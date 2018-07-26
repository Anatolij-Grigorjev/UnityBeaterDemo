using System;
using System.Collections;
using BeaterDemo.Input;
using BeaterDemo.Const;
using UnityEngine;

namespace BeaterDemo
{
    public class PlayerInputSource: CachedEventInputSource<PlayerInputEvent> {

        Logger log = Logger.getInstance(typeof(PlayerInputSource).Name);

        public PlayerInputSource(): base(ref InputCommands.ALL_PLAYER_COMMANDS) {

        }

        public PlayerInputSource(ref string[] commandsFilter): base(ref commandsFilter) {
            
        }

        public override bool ProcessCommand(PlayerInputEvent eventTemplate) {
            var cmd = eventTemplate.InputCommand;
            if (UnityEngine.Input.GetButtonDown(cmd)) {
                log.Info("Captured PRESSED command {0}", cmd);
                eventTemplate.State = PlayerCommandStates.JUST_PRESSED;
                return true;
            }
            if (UnityEngine.Input.GetButton(cmd)) {
                log.Info("Captured HELD command {0}", cmd);
                eventTemplate.State = PlayerCommandStates.HELD_DOWN;
                return true;
            }
            if (UnityEngine.Input.GetButtonUp(cmd)) {
                log.Info("Captured RELEASED command {0}", cmd);
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