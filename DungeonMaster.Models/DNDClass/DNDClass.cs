using DungeonMaster.Models.Ability;
using DungeonMaster.Models.Item.Armor;
using DungeonMaster.Models.Item.Weapon;
using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonMaster.Models.DNDClass
{
    public class DNDClass
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ClassLevel { get; set; }
        public Spell.ClassCasterTypeEnum ClassCaster { get; set; } //Full, Half, Third, or None. For multiclassing.

        public DNDClassTypeEnum ClassType { get; set; }
        public DieSizeEnum HitDie { get; set; }
        public IEnumerable<ClassFeature> Features { get; set; }

        public IEnumerable<WeaponTypeEnum> WeaponProficiencies { get; set; }
        public IEnumerable<ArmorTypeEnum> ArmorProficiencies { get; set; }
        public IEnumerable<AbilityTypeEnum> SavingThrowProficiencies { get; set; }
        public IEnumerable<SkillTypeEnum> SkillProficiencies { get; set; }
    }
}
