using System;
using System.Collections.Generic;

namespace DungeonMaster.Data.Models
{
    public partial class AbilityType : Model
    {
        public AbilityType()
        {
            Dndskill = new HashSet<Dndskill>();
            Proficiency = new HashSet<Proficiency>();
        }

        public string Name { get; set; }

        public CharacterAbilityScore CharacterAbilityScore { get; set; }
        public ICollection<Dndskill> Dndskill { get; set; }
        public ICollection<Proficiency> Proficiency { get; set; }
    }
}
