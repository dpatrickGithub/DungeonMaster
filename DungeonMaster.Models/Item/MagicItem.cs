using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonMaster.Models.Item
{
    public class MagicItem : Item
    {
        public bool OneTimeUse { get; set; }
        public bool IsSentient { get; set; }
        public ItemRarityEnum Rarity { get; set; }
        public IEnumerable<StatBonus> StatBonuses { get; set; }
    }
}
