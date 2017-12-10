using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonMaster.Models.Ability
{
    public class Ability
    {
        public int Score { get; set; }
        public int Modifier => (int)Math.Floor(((double)(Score - 10) / 2));
        public AbilityTypeEnum AbilityType { get; set; }
    }
}
