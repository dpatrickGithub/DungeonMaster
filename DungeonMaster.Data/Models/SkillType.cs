using System;
using System.Collections.Generic;

namespace DungeonMaster.Data.Models
{
    public partial class SkillType : Model
    {
        public SkillType()
        {
            Dndskill = new HashSet<Dndskill>();
            Proficiency = new HashSet<Proficiency>();
        }

        public string Name { get; set; }

        public ICollection<Dndskill> Dndskill { get; set; }
        public ICollection<Proficiency> Proficiency { get; set; }
    }
}
