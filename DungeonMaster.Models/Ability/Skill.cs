using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonMaster.Models.Ability
{
    public class Skill
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public SkillTypeEnum SkillType { get; set; }
        public bool IsProficient { get; set; }
    }
}
