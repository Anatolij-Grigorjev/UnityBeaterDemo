namespace BeaterDemo.Const
{
    
    public static class InputCommands {

        public const string CMD_NOOP = "";
        public const string CMD_LIGHT_ATTACK = "LightAttack";
        public const string CMD_HEAVY_ATTACK = "HeavyAttack";




        public static string[] ALL_PLAYER_COMMANDS = {
            CMD_LIGHT_ATTACK,
            CMD_HEAVY_ATTACK
        };
    }

}