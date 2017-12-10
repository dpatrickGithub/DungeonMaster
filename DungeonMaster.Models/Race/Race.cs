using DungeonMaster.Models.Ability;
using DungeonMaster.Models.Item.Armor;
using DungeonMaster.Models.Item.Tool;
using DungeonMaster.Models.Item.Weapon;
using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonMaster.Models.Race
{
    public class Race
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int BaseSpeed { get; set; }

        public IEnumerable<RaceFeature> Features { get; set; }
        public IEnumerable<StatBonus> StatBonuses { get; set; }
        public IEnumerable<WeaponTypeEnum> WeaponProficiencies { get; set; }
        public IEnumerable<ArmorTypeEnum> ArmorProficiencies { get; set; }
        public IEnumerable<ToolTypeEnum> ToolProficiencies { get; set; }
        public IEnumerable<AbilityTypeEnum> AbilityProficiencies { get; set; }
    }
}
