using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonMaster.Models.Item.Weapon
{
    public class MagicWeapon : MagicItem
    {
        public WeaponTypeEnum WeaponType { get; set; }
        public int DieCount { get; set; }
        public DieSizeEnum DieSize { get; set; }
        public IEnumerable<WeaponProperty> Properties { get; set; }
        public bool IsEquipped { get; set; }
        public int MagicAttackBonus { get; set; }
        public int MagicDamageBonus { get; set; }
    }
}
