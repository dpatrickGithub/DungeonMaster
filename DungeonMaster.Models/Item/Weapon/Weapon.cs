using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonMaster.Models.Item.Weapon
{
    public class Weapon : Item
    {
        public WeaponTypeEnum WeaponType { get; set; }
        public int DieCount { get; set; }
        public DieSizeEnum DieSize { get; set; }
        public IEnumerable<WeaponProperty> Properties { get; set; }
        public bool IsEquipped { get; set; }
    }
}
