using System;
using System.Collections.Generic;

namespace DungeonMaster.Data.Models
{
    public partial class Proficiency : Model
    {
        public int SkillTypeId { get; set; }
        public int SavingThrowTypeId { get; set; }

        public AbilityType SavingThrowType { get; set; }
        public SkillType SkillType { get; set; }
    }
}
