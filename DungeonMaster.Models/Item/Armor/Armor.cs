using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonMaster.Models.Item.Armor
{
    public class Armor : Item
    {
        public ArmorWeightEnum WeightCategory { get; set; }
        public ArmorTypeEnum Type { get; set; }
        public bool DisadvantageOnStealth { get; set; }
        public int StrengthRequired { get; set; }
        public bool IsEquipped { get; set; }

        public int CalculateAC(int dexMod)
        {
            switch (Type)
            {
                case ArmorTypeEnum.BreastPlate:
                    if (dexMod > 1) dexMod = 2;
                    return 14 + dexMod;
                case ArmorTypeEnum.ChainMail:
                    return 16;
                case ArmorTypeEnum.ChainShirt:
                    if (dexMod > 1) dexMod = 2;
                    return 13 + dexMod;
                case ArmorTypeEnum.HalfPlate:
                    if (dexMod > 1) dexMod = 2;
                    return 15 + dexMod;
                case ArmorTypeEnum.Hide:
                    if (dexMod > 1) dexMod = 2;
                    return 12 + dexMod;
                case ArmorTypeEnum.Leather:
                    return 11 + dexMod;
                case ArmorTypeEnum.Padded:
                    return 11 + dexMod;
                case ArmorTypeEnum.Plate:
                    return 18;
                case ArmorTypeEnum.RingMail:
                    return 14;
                case ArmorTypeEnum.ScaleMail:
                    if (dexMod > 1) dexMod = 2;
                    return 14 + dexMod;
                case ArmorTypeEnum.Splint:
                    return 17;
                case ArmorTypeEnum.StuddedLeather:
                    return 12 + dexMod;
                default:
                    throw new Exception("Unexpected Armor Type.");
            }
        }
    }
}
