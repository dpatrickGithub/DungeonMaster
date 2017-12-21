using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonMaster.Models.Race
{
    public class RaceFeature : Feature
    {
        public int Id { get; set; }
        public string Summary { get; set; }
        public string Description { get; set; }
        IEnumerable<StatBonus> StatBonuses { get; set; }
    }
}
