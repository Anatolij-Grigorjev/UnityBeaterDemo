using System;
using BeaterDemo.Input;
using BeaterDemo.Const;
using UnityEngine;


namespace BeaterDemo
{
    public class WorldController: HistoryAwareSingleton<WorldController>
    {

        protected override void OnAwake() {
            InputSourceRegistry.Instance.AddInputSource<InputEvent>(
                RegistryKeys.IS_PLAYER_ATTACK, 
                new PlayerInputSource(ref InputCommands.ALL_ATTACK_COMMANDS)
            );
        }

    }
}