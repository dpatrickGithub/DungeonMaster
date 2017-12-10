using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonMaster.Models.Ability
{
    public class SavingThrow
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public AbilityTypeEnum Type { get; set; }
        public bool IsProficient { get; set; }
    }
}
