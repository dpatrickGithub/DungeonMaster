using System;
using System.Collections.Generic;

namespace DungeonMaster.Data.Models
{
    public partial class Dndskill : Model
    {
        public int AbilityTypeId { get; set; }
        public string Name { get; set; }
        public AbilityType AbilityType { get; set; }
    }
}
