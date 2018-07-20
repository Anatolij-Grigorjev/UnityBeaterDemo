using System;

namespace BeaterDemo.Const
{
    
    public static class InputCommands {

        public const string CMD_NOOP = "";
        public const string CMD_LIGHT_ATTACK = "LightAttack";
        public const string CMD_HEAVY_ATTACK = "HeavyAttack";



        public static string[] ALL_ATTACK_COMMANDS = {
            CMD_LIGHT_ATTACK,
            CMD_HEAVY_ATTACK
        };

        public static string[] ALL_PLAYER_COMMANDS = {
            CMD_LIGHT_ATTACK,
            CMD_HEAVY_ATTACK
        };


        public static bool IsAttackCommand(string command) {

            return Array.Find(ALL_ATTACK_COMMANDS, cmd => cmd.Equals(command)) != null;
        }
    }

}