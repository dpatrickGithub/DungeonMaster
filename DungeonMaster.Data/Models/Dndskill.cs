﻿using System;
using System.Collections.Generic;

namespace DungeonMaster.Data.Models
{
    public partial class Dndskill
    {
        public int Id { get; set; }
        public int SkillTypeId { get; set; }
        public int AbilityTypeId { get; set; }

        public AbilityType AbilityType { get; set; }
        public SkillType SkillType { get; set; }
    }
}