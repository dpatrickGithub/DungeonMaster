﻿using System;
using System.Collections.Generic;

namespace DungeonMaster.Data.Models
{
    public partial class SkillType
    {
        public SkillType()
        {
            Dndskill = new HashSet<Dndskill>();
            Proficiency = new HashSet<Proficiency>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Dndskill> Dndskill { get; set; }
        public ICollection<Proficiency> Proficiency { get; set; }
    }
}
