using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonMaster.Models
{
    public class StatBonus
    {
        public int Id { get; set; }
        public Ability.AbilityTypeEnum AbilityType { get; set; }
        public int Value { get; set; }
    }
}
