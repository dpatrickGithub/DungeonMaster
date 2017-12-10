using DungeonMaster.Models.Ability;
using DungeonMaster.Models.Item.Armor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DungeonMaster.Models.Character
{
    public class Character
    {
        public Character(int strScore, int dexScore, int conScore, int intScore, int wisScore, int chaScore)
        {
            _strScore = strScore;
            _dexScore = dexScore;
            _conScore = conScore;
            _intScore = intScore;
            _wisScore = wisScore;
            _chaScore = chaScore;
        }

        private int _strScore;
        private int _dexScore;
        private int _conScore;
        private int _intScore;
        private int _wisScore;
        private int _chaScore;

        public int Id { get; set; }
        public string CharacterName { get; set; }
        public string PlayerName { get; set; }
        public int Level
        {
            get
            {
                return Classes.Sum(cls => cls.ClassLevel);
            }
            set
            {
                Level = value;
            }
        }
        public int HitPoints { get; set; }
        public int ProficiencyBonus {
            get
            {
                if (Level < 5) return 2;
                if (Level >= 5 && Level < 9) return 3;
                if (Level >= 9 && Level < 13) return 4;
                if (Level >= 13 && Level < 17) return 5;
                if (Level >= 17 && Level < 21) return 6;
                else throw new Exception("Character Level out of bounds.");
            }
        }
        public int ArmorClass
        {
            get
            {
                var armor = Inventory
                    .FirstOrDefault(inv => 
                    (inv is Armor || inv is MagicArmor) && 
                    ((Armor)inv).Type != ArmorTypeEnum.Shield &&
                    ((Armor)inv).IsEquipped);

                var shield = Inventory
                    .FirstOrDefault(inv =>
                    (inv is Armor || inv is MagicArmor) &&
                    ((Armor)inv).Type == ArmorTypeEnum.Shield &&
                    ((Armor)inv).IsEquipped);

                if (armor == null)
                {
                    return 10 + AbilityScores.Single(score => score.AbilityType == AbilityTypeEnum.Dexterity).Modifier;
                }

                if (armor is Armor)
                {
                    var rawAC = ((Armor)armor).CalculateAC(AbilityScores.Single(score => score.AbilityType == AbilityTypeEnum.Dexterity).Modifier);
                    if (shield == null)
                    {
                        return rawAC;
                    }

                    if (shield is MagicArmor)
                    {
                        return ((MagicArmor)shield).AdditionalAC + 2 + rawAC;
                    }
                    if (shield is Armor)
                    {
                        return 2 + rawAC;
                    }
                }
                else if (armor is MagicArmor)
                {
                    var rawAC = ((MagicArmor)armor).CalculateAC(AbilityScores.Single(score => score.AbilityType == AbilityTypeEnum.Dexterity).Modifier);
                    if (shield == null)
                    {
                        return rawAC;
                    }

                    if (shield is MagicArmor)
                    {
                        return ((MagicArmor)shield).AdditionalAC + 2 + rawAC;
                    }
                    if (shield is Armor)
                    {
                        return 2 + rawAC;
                    }
                }
                
                throw new Exception("Something went wrong when calculating Armor Class");
                
            }
            set
            {
                ArmorClass = value;
            }
        }

        public Dictionary<int, int> NumberOfSpellSlots { get; set; }

        public IEnumerable<Item.Item> Inventory { get; set; }
        public Race.Race Race { get; set; }
        public AlignmentTypeEnum Alignment { get; set; }
        public IEnumerable<DNDClass.DNDClass> Classes { get; set; } //IEnumerable to deal with multiclassing
        public Background.Background Background { get; set; }

        public IEnumerable<Ability.Ability> AbilityScores
        {
            get
            {
                var strBonus = Race.StatBonuses.FirstOrDefault(sb => sb.AbilityType == Ability.AbilityTypeEnum.Strength)?.Value ?? 0;
                var dexBonus = Race.StatBonuses.FirstOrDefault(sb => sb.AbilityType == Ability.AbilityTypeEnum.Dexterity)?.Value ?? 0;
                var conBonus = Race.StatBonuses.FirstOrDefault(sb => sb.AbilityType == Ability.AbilityTypeEnum.Constitution)?.Value ?? 0;
                var intBonus = Race.StatBonuses.FirstOrDefault(sb => sb.AbilityType == Ability.AbilityTypeEnum.Intelligence)?.Value ?? 0;
                var wisBonus = Race.StatBonuses.FirstOrDefault(sb => sb.AbilityType == Ability.AbilityTypeEnum.Wisdom)?.Value ?? 0;
                var chaBonus = Race.StatBonuses.FirstOrDefault(sb => sb.AbilityType == Ability.AbilityTypeEnum.Charisma)?.Value ?? 0;

                var scores = new List<Ability.Ability>();
                scores.Add(new Ability.Ability()
                {
                    AbilityType = AbilityTypeEnum.Strength,
                    Score = strBonus + _strScore
                });
                scores.Add(new Ability.Ability()
                {
                    AbilityType = AbilityTypeEnum.Dexterity,
                    Score = dexBonus + _dexScore
                });
                scores.Add(new Ability.Ability()
                {
                    AbilityType = AbilityTypeEnum.Constitution,
                    Score = conBonus + _conScore
                });
                scores.Add(new Ability.Ability()
                {
                    AbilityType = AbilityTypeEnum.Intelligence,
                    Score = intBonus + _intScore
                });
                scores.Add(new Ability.Ability()
                {
                    AbilityType = AbilityTypeEnum.Wisdom,
                    Score = wisBonus + _wisScore
                });
                scores.Add(new Ability.Ability()
                {
                    AbilityType = AbilityTypeEnum.Charisma,
                    Score = chaBonus + _chaScore
                });
                return scores;
            }
            set { AbilityScores = value; }
        }
        public Dictionary<AbilityTypeEnum, int> SavingThrowModifiers
        {
            get
            {
                var strMod = AbilityScores.Single(score => score.AbilityType == AbilityTypeEnum.Strength).Modifier;
                var dexMod = AbilityScores.Single(score => score.AbilityType == AbilityTypeEnum.Dexterity).Modifier;
                var conMod = AbilityScores.Single(score => score.AbilityType == AbilityTypeEnum.Constitution).Modifier;
                var intMod = AbilityScores.Single(score => score.AbilityType == AbilityTypeEnum.Intelligence).Modifier;
                var wisMod = AbilityScores.Single(score => score.AbilityType == AbilityTypeEnum.Wisdom).Modifier;
                var chaMod = AbilityScores.Single(score => score.AbilityType == AbilityTypeEnum.Charisma).Modifier;

                if (SavingThrowProficiencies.Contains(AbilityTypeEnum.Strength))
                {
                    strMod += ProficiencyBonus;
                }
                if (SavingThrowProficiencies.Contains(AbilityTypeEnum.Dexterity))
                {
                    dexMod += ProficiencyBonus;
                }
                if (SavingThrowProficiencies.Contains(AbilityTypeEnum.Constitution))
                {
                    conMod += ProficiencyBonus;
                }
                if (SavingThrowProficiencies.Contains(AbilityTypeEnum.Intelligence))
                {
                    intMod += ProficiencyBonus;
                }
                if (SavingThrowProficiencies.Contains(AbilityTypeEnum.Wisdom))
                {
                    wisMod += ProficiencyBonus;
                }
                if (SavingThrowProficiencies.Contains(AbilityTypeEnum.Charisma))
                {
                    chaMod += ProficiencyBonus;
                }

                var saveScores = new Dictionary<AbilityTypeEnum, int>();

                saveScores.Add(AbilityTypeEnum.Strength, strMod);
                saveScores.Add(AbilityTypeEnum.Dexterity, dexMod);
                saveScores.Add(AbilityTypeEnum.Constitution, conMod);
                saveScores.Add(AbilityTypeEnum.Intelligence, intMod);
                saveScores.Add(AbilityTypeEnum.Wisdom, wisMod);
                saveScores.Add(AbilityTypeEnum.Charisma, chaMod);

                return saveScores;
            }
            set
            {
                SavingThrowModifiers = value;
            }
        }
        public Dictionary<SkillTypeEnum, int> SkillModifiers
        {
            get
            {
                var strMod = AbilityScores.Single(score => score.AbilityType == AbilityTypeEnum.Strength).Modifier;
                var dexMod = AbilityScores.Single(score => score.AbilityType == AbilityTypeEnum.Dexterity).Modifier;
                var conMod = AbilityScores.Single(score => score.AbilityType == AbilityTypeEnum.Constitution).Modifier;
                var intMod = AbilityScores.Single(score => score.AbilityType == AbilityTypeEnum.Intelligence).Modifier;
                var wisMod = AbilityScores.Single(score => score.AbilityType == AbilityTypeEnum.Wisdom).Modifier;
                var chaMod = AbilityScores.Single(score => score.AbilityType == AbilityTypeEnum.Charisma).Modifier;

                var skillModifiers = new Dictionary<SkillTypeEnum, int>();

                var acroMod = dexMod;
                if (SkillProficiencies.Contains(SkillTypeEnum.Acrobatics))
                {
                    acroMod += ProficiencyBonus;
                }
                skillModifiers.Add(SkillTypeEnum.Acrobatics, acroMod);

                var animalHandlingMod = wisMod;
                if (SkillProficiencies.Contains(SkillTypeEnum.AnimalHandling))
                {
                    animalHandlingMod += ProficiencyBonus;
                }
                skillModifiers.Add(SkillTypeEnum.AnimalHandling, animalHandlingMod);

                var arcanaMod = intMod;
                if (SkillProficiencies.Contains(SkillTypeEnum.Arcana))
                {
                    arcanaMod += ProficiencyBonus;
                }
                skillModifiers.Add(SkillTypeEnum.Arcana, arcanaMod);

                var athleticsMod = strMod;
                if (SkillProficiencies.Contains(SkillTypeEnum.Athletics))
                {
                    athleticsMod += ProficiencyBonus;
                }
                skillModifiers.Add(SkillTypeEnum.Athletics, athleticsMod);

                var deceptionMod = chaMod;
                if (SkillProficiencies.Contains(SkillTypeEnum.Deception))
                {
                    deceptionMod += ProficiencyBonus;
                }
                skillModifiers.Add(SkillTypeEnum.Deception, deceptionMod);

                var histMod = intMod;
                if (SkillProficiencies.Contains(SkillTypeEnum.History))
                {
                    histMod += ProficiencyBonus;
                }
                skillModifiers.Add(SkillTypeEnum.History, histMod);

                var insightMod = wisMod;
                if (SkillProficiencies.Contains(SkillTypeEnum.Insight))
                {
                    insightMod += ProficiencyBonus;
                }
                skillModifiers.Add(SkillTypeEnum.Insight, insightMod);

                var intimidationMod = chaMod;
                if (SkillProficiencies.Contains(SkillTypeEnum.Intimidation))
                {
                    intimidationMod += ProficiencyBonus;
                }
                skillModifiers.Add(SkillTypeEnum.Intimidation, intimidationMod);

                var investigationMod = intMod;
                if (SkillProficiencies.Contains(SkillTypeEnum.Investigation))
                {
                    investigationMod += ProficiencyBonus;
                }
                skillModifiers.Add(SkillTypeEnum.Investigation, investigationMod);

                var medicineMod = wisMod;
                if (SkillProficiencies.Contains(SkillTypeEnum.Medicine))
                {
                    medicineMod += ProficiencyBonus;
                }
                skillModifiers.Add(SkillTypeEnum.Medicine, medicineMod);

                var natureMod = intMod;
                if (SkillProficiencies.Contains(SkillTypeEnum.Nature))
                {
                    natureMod += ProficiencyBonus;
                }
                skillModifiers.Add(SkillTypeEnum.Nature, natureMod);

                var perceptionMod = wisMod;
                if (SkillProficiencies.Contains(SkillTypeEnum.Perception))
                {
                    perceptionMod += ProficiencyBonus;
                }
                skillModifiers.Add(SkillTypeEnum.Perception, perceptionMod);

                var performanceMod = chaMod;
                if (SkillProficiencies.Contains(SkillTypeEnum.Performance))
                {
                    performanceMod += ProficiencyBonus;
                }
                skillModifiers.Add(SkillTypeEnum.Performance, performanceMod);

                var persuasionMod = chaMod;
                if (SkillProficiencies.Contains(SkillTypeEnum.Persuasion))
                {
                    persuasionMod += ProficiencyBonus;
                }
                skillModifiers.Add(SkillTypeEnum.Persuasion, histMod);

                var religionMod = intMod;
                if (SkillProficiencies.Contains(SkillTypeEnum.Religion))
                {
                    religionMod += ProficiencyBonus;
                }
                skillModifiers.Add(SkillTypeEnum.Religion, religionMod);

                var sleightOfHand = dexMod;
                if (SkillProficiencies.Contains(SkillTypeEnum.SleightOfHand))
                {
                    sleightOfHand += ProficiencyBonus;
                }
                skillModifiers.Add(SkillTypeEnum.SleightOfHand, sleightOfHand);

                var stealthMod = dexMod;
                if (SkillProficiencies.Contains(SkillTypeEnum.Stealth))
                {
                    stealthMod += ProficiencyBonus;
                }
                skillModifiers.Add(SkillTypeEnum.Stealth, stealthMod);

                var survivalMod = intMod;
                if (SkillProficiencies.Contains(SkillTypeEnum.Survival))
                {
                    survivalMod += ProficiencyBonus;
                }
                skillModifiers.Add(SkillTypeEnum.Stealth, survivalMod);

                return skillModifiers;
            }
            set
            {
                SkillModifiers = value;
            }
        }

        public IEnumerable<AbilityTypeEnum> SavingThrowProficiencies { get; set; }
        public IEnumerable<SkillTypeEnum> SkillProficiencies { get; set; }

        public IEnumerable<Spell.Spell> Spells { get; set; }
    }
}
