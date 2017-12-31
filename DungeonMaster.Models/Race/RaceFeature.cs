using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonMaster.Models.Race
{
    public class RaceFeature : Feature
    {
        public string Description { get; set; }
        IEnumerable<StatBonus> StatBonuses { get; set; }
    }
}
