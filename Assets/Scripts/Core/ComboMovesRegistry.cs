using System;
using System.Collections.Generic;

namespace BeaterDemo
{
    public class ComboMovesRegistry: HistoryAwareSingleton<ComboMovesRegistry>
    {
        private Dictionary<Const.CharacterTypes, Dictionary<int, ComboMove>> movesByType;

        protected override void OnAwake() {
            var allCharacterTypes = (Const.CharacterTypes[])Enum.GetValues(typeof(Const.CharacterTypes));
            movesByType = new Dictionary<Const.CharacterTypes, Dictionary<int, ComboMove>>(
                allCharacterTypes.Length);

            foreach(var charType in allCharacterTypes) {
                movesByType[charType] = new Dictionary<int, ComboMove>();
            }
            
        }

        public Dictionary<int, ComboMove> getCharTypeMoves(Const.CharacterTypes charType) {

            return movesByType[charType];
        }
    }
}