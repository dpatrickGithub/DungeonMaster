using DungeonMaster.Models.Ability;
using DungeonMaster.Models.Item.Armor;
using DungeonMaster.Models.Item.Weapon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DungeonMaster.WebApi.ViewModels.DNDClass
{
    public class DNDClassVM
    {
        public int Id { get; set; }
        public int ClassLevel { get; set; }
        public string Name { get; set; }

        public IEnumerable<WeaponTypeEnum> WeaponProficiencies { get; set; }
        public IEnumerable<ArmorTypeEnum> ArmorProficiencies { get; set; }
        public IEnumerable<AbilityTypeEnum> SavingThrowProficiencies { get; set; }
        public IEnumerable<SkillTypeEnum> SkillProficiencies { get; set; }
    }
}
