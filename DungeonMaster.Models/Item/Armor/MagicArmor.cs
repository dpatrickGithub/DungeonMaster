using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonMaster.Models.Item.Armor
{
    public class MagicArmor : MagicItem
    {
        public int AdditionalAC { get; set; }
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
                    return 14 + dexMod + AdditionalAC;
                case ArmorTypeEnum.ChainMail:
                    return 16 + AdditionalAC;
                case ArmorTypeEnum.ChainShirt:
                    if (dexMod > 1) dexMod = 2;
                    return 13 + dexMod + AdditionalAC;
                case ArmorTypeEnum.HalfPlate:
                    if (dexMod > 1) dexMod = 2;
                    return 15 + dexMod + AdditionalAC;
                case ArmorTypeEnum.Hide:
                    if (dexMod > 1) dexMod = 2;
                    return 12 + dexMod + AdditionalAC;
                case ArmorTypeEnum.Leather:
                    return 11 + dexMod + AdditionalAC;
                case ArmorTypeEnum.Padded:
                    return 11 + dexMod + AdditionalAC;
                case ArmorTypeEnum.Plate:
                    return 18 + AdditionalAC;
                case ArmorTypeEnum.RingMail:
                    return 14 + AdditionalAC;
                case ArmorTypeEnum.ScaleMail:
                    if (dexMod > 1) dexMod = 2;
                    return 14 + dexMod + AdditionalAC;
                case ArmorTypeEnum.Splint:
                    return 17 + AdditionalAC;
                case ArmorTypeEnum.StuddedLeather:
                    return 12 + dexMod + AdditionalAC;
                case ArmorTypeEnum.Cloak:
                    return 10 + dexMod + AdditionalAC;
                default:
                    throw new Exception("Unexpected Armor Type.");
            }
        }
    }
}
