using System;
using System.Collections.Generic;

namespace DungeonMaster.Data.Models
{
    public partial class CharacterAbilityScore : Model
    {
        public int AbilityTypeId { get; set; }
        public int CharacterId { get; set; }
        public int Score { get; set; }

        public AbilityType IdNavigation { get; set; }
    }
}
