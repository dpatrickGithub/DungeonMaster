using Microsoft.EntityFrameworkCore.Migrations;

namespace DungeonMaster.Data.Migrations
{
    public partial class SeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RaceType_Id",
                table: "Race");

            migrationBuilder.DropColumn(
                name: "SkillType_Id",
                table: "DNDSkill");

            migrationBuilder.DropColumn(
                name: "ClassType_Id",
                table: "DNDClass");

            migrationBuilder.DropColumn(
                name: "SubClassType_Id",
                table: "DNDClass");

            migrationBuilder.DropColumn(
                name: "BackgroundType_Id",
                table: "Background");

            migrationBuilder.AddColumn<string>(
                name: "Size",
                table: "Race",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "DNDSkill",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HitDieSize",
                table: "DNDClass",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "AbilityType",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Strength" },
                    { 2, "Dexterity" },
                    { 3, "Intelligence" },
                    { 4, "Wisdom" },
                    { 5, "Charisma" },
                    { 6, "Constitution" }
                });

            migrationBuilder.InsertData(
                table: "Background",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 12, "orphan boi", "Urchin" },
                    { 11, "army boi", "Soldier" },
                    { 10, "water boi", "Sailor" },
                    { 9, "book boi", "Sage" },
                    { 8, "amish boi", "Outlander" },
                    { 7, "bougie boi", "Noble" },
                    { 6, "introvert boi", "Hermit" },
                    { 5, "professional boi", "Guild Artisan" },
                    { 4, "legendary boi", "folk Hero" },
                    { 3, "performer boi", "Entertainer" },
                    { 2, "outlaw boi", "Criminal" },
                    { 1, "extrovert boi", "Charlatan" }
                });

            migrationBuilder.InsertData(
                table: "DNDClass",
                columns: new[] { "Id", "CharacterId", "Description", "HitDieSize", "Name", "ParentClass_Id" },
                values: new object[,]
                {
                    { 43, null, "Xtra Magic bois", 6, "Wizard", null },
                    { 39, null, "Grumpy Magic bois", 8, "Warlock", null },
                    { 36, null, "Magical bois", 6, "Sorcerer", null },
                    { 32, null, "Sneaky bois", 8, "Rogue", null },
                    { 29, null, "Arrow bois", 10, "Ranger", null },
                    { 25, null, "Crusader bois", 10, "Paladin", null },
                    { 4, null, "Fancy bois", 8, "Bard", null },
                    { 17, null, "Pokie bois", 10, "Fighter", null },
                    { 14, null, "Hippy bois", 8, "Druid", null },
                    { 7, null, "Holy bois", 8, "Cleric", null },
                    { 1, null, "Dumb bois", 12, "Barbarian", null },
                    { 21, null, "Calm bois", 8, "Monk", null }
                });

            migrationBuilder.InsertData(
                table: "Race",
                columns: new[] { "Id", "BaseSpeed", "Description", "Name", "ParentRace_Id", "Size", "SubRaceType_Id" },
                values: new object[,]
                {
                    { 28, (short)30, "little tusky bois", "Half-Orc", null, "medium", null },
                    { 1, (short)25, "little thicc bois", "Dwarf", null, "small", null },
                    { 4, (short)30, "tall pointy bois", "Elf", null, "medium", null },
                    { 8, (short)25, "little happy bois", "Halfling", null, "small", null },
                    { 11, (short)30, "boring bois", "Human", null, "medium", null },
                    { 13, (short)30, "dragon bois", "Dragonborn", null, "medium", null },
                    { 24, (short)30, "stupid lil bois", "Gnome", null, "small", null },
                    { 27, (short)30, "half and half bois", "Half-Elf", null, "medium", null },
                    { 29, (short)30, "devil bois", "Tiefling", null, "medium", null }
                });

            migrationBuilder.InsertData(
                table: "DNDClass",
                columns: new[] { "Id", "CharacterId", "Description", "HitDieSize", "Name", "ParentClass_Id" },
                values: new object[,]
                {
                    { 28, null, "Crusader bois", 10, "Oath of Vengeance Paladin", 25 },
                    { 6, null, "Fancy Theatric bois", 8, "College of Valor Bard", 4 },
                    { 8, null, "Holy bois", 8, "Life Domain Cleric", 7 },
                    { 9, null, "Holy bois", 8, "Light Domain Cleric", 7 },
                    { 10, null, "Holy bois", 8, "Nature Domain Cleric", 7 },
                    { 11, null, "Holy bois", 8, "Tempest Domain Cleric", 7 },
                    { 12, null, "Holy bois", 8, "Trickery Domain Cleric", 7 },
                    { 13, null, "Holy bois", 8, "War Domain Cleric", 7 },
                    { 5, null, "Fancy Smart bois", 8, "College of Lore Bard", 4 },
                    { 15, null, "Hippy bois", 8, "Circle of the Land Druid", 14 },
                    { 18, null, "Strong Pokie bois", 10, "Champion Fighter", 17 },
                    { 19, null, "Versatile Pokie bois", 10, "Battle Master Fighter", 17 },
                    { 20, null, "Magical Pokie bois", 10, "Eldritch Fighter", 17 },
                    { 22, null, "Calm bois", 8, "Way of the Open Hand Monk", 21 },
                    { 23, null, "Calm bois", 8, "Way of the Shadow Monk", 21 },
                    { 24, null, "Calm bois", 8, "Way of the Four Elements Monk", 21 },
                    { 26, null, "Crusader bois", 10, "Oath of Devotion Paladin", 25 },
                    { 16, null, "Hippy bois", 8, "Circle of the Moon Druid", 14 },
                    { 27, null, "Crusader bois", 10, "Oath of The Ancients Paladin", 25 },
                    { 3, null, "Dumb Grumpy bois", 12, "Path of the Berserker Barbarian", 1 },
                    { 31, null, "Arrow bois", 10, "Beast Master Ranger", 29 },
                    { 51, null, "Xtra Magic bois", 6, "Transmutation Wizard", 43 },
                    { 50, null, "Xtra Magic bois", 6, "Necromancy Wizard", 43 },
                    { 49, null, "Xtra Magic bois", 6, "Illusion Wizard", 43 },
                    { 48, null, "Xtra Magic bois", 6, "Evocation Wizard", 43 },
                    { 47, null, "Xtra Magic bois", 6, "Enchantment Wizard", 43 },
                    { 46, null, "Xtra Magic bois", 6, "Divination Wizard", 43 },
                    { 45, null, "Xtra Magic bois", 6, "Conjuration Wizard", 43 },
                    { 2, null, "Dumb Nature bois", 12, "Path of the Totem Warrior Barbarian", 1 },
                    { 44, null, "Xtra Magic bois", 6, "Abjuration Wizard", 43 },
                    { 41, null, "Grumpy Magic bois", 8, "Pact of the Blade Warlock", 39 },
                    { 40, null, "Grumpy Magic bois", 8, "Pact of the Chain Warlock", 39 },
                    { 38, null, "Magical bois", 6, "Wild Magic Sorcerer", 36 },
                    { 37, null, "Magical bois", 6, "Draconic Bloodline Sorcerer", 36 },
                    { 35, null, "Magical Sneaky bois", 8, "Arcane Trickster Rogue", 32 },
                    { 34, null, "Sneaky bois", 8, "Assassin Rogue", 32 },
                    { 33, null, "Sneaky bois", 8, "Thief Rogue", 32 },
                    { 42, null, "Grumpy Magic bois", 8, "Pact of the Tome Warlock", 39 },
                    { 30, null, "Arrow bois", 10, "Hunger Ranger", 29 }
                });

            migrationBuilder.InsertData(
                table: "DNDSkill",
                columns: new[] { "Id", "AbilityType_Id", "Name" },
                values: new object[,]
                {
                    { 1, 1, "Athletics" },
                    { 18, 5, "Persuasion" },
                    { 2, 2, "Acrobatic" },
                    { 3, 2, "Sleight of Hand" },
                    { 4, 2, "Stealth" },
                    { 5, 3, "Arcana" },
                    { 7, 3, "Investigation" },
                    { 8, 3, "Nature" },
                    { 9, 3, "Religion" },
                    { 6, 3, "History" },
                    { 11, 4, "Insight" },
                    { 12, 4, "Medicine" },
                    { 13, 4, "Perception" },
                    { 14, 4, "Survival" },
                    { 15, 5, "Deception" },
                    { 16, 5, "Intimidation" },
                    { 17, 5, "Performace" },
                    { 10, 4, "Animal Handling" }
                });

            migrationBuilder.InsertData(
                table: "Race",
                columns: new[] { "Id", "BaseSpeed", "Description", "Name", "ParentRace_Id", "Size", "SubRaceType_Id" },
                values: new object[,]
                {
                    { 17, (short)30, "bronze dragon bois", "Bronze Dragonborn", 13, "medium", null },
                    { 18, (short)30, "copper dragon bois", "Copper Dragonborn", 13, "medium", null },
                    { 19, (short)30, "gold dragon bois", "Gold Dragonborn", 13, "medium", null },
                    { 23, (short)30, "white dragon bois", "White Dragonborn", 13, "medium", null },
                    { 21, (short)30, "red dragon bois", "Red Dragonborn", 13, "medium", null },
                    { 22, (short)30, "silver dragon bois", "Silver Dragonborn", 13, "medium", null },
                    { 16, (short)30, "brass dragon bois", "Brass Dragonborn", 13, "medium", null },
                    { 20, (short)30, "green dragon bois", "Green Dragonborn", 13, "medium", null },
                    { 15, (short)30, "blue dragon bois", "Blue Dragonborn", 13, "medium", null },
                    { 3, (short)25, "little thicc bois", "Mountain Dwarf", 1, "small", null },
                    { 12, (short)30, "special boring bois", "Variant Human", 11, "medium", null },
                    { 10, (short)25, "little hardy bois", "Stout Halfling", 8, "small", null },
                    { 9, (short)25, "little sneaky bois", "Lightfoot Halfling", 8, "small", null },
                    { 7, (short)30, "tall emo bois", "Dark Elf (Drow)", 4, "medium", null },
                    { 6, (short)35, "tall nature bois", "Wood Elf", 4, "medium", null },
                    { 5, (short)30, "tall bougie bois", "High Elf", 4, "medium", null },
                    { 25, (short)30, "stupid lil nature bois", "Forest Gnome", 24, "small", null },
                    { 2, (short)25, "little thicc bois", "Hill Dwarf", 1, "small", null },
                    { 14, (short)30, "black dragon bois", "Black Dragonborn", 13, "medium", null },
                    { 26, (short)30, "stupid lil hard bois", "Rock Gnome", 24, "small", null }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AbilityType",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Background",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Background",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Background",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Background",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Background",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Background",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Background",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Background",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Background",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Background",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Background",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Background",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "DNDClass",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "DNDClass",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "DNDClass",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "DNDClass",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "DNDClass",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "DNDClass",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "DNDClass",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "DNDClass",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "DNDClass",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "DNDClass",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "DNDClass",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "DNDClass",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "DNDClass",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "DNDClass",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "DNDClass",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "DNDClass",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "DNDClass",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "DNDClass",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "DNDClass",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "DNDClass",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "DNDClass",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "DNDClass",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "DNDClass",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "DNDClass",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "DNDClass",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "DNDClass",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "DNDClass",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "DNDClass",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "DNDClass",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "DNDClass",
                keyColumn: "Id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "DNDClass",
                keyColumn: "Id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "DNDClass",
                keyColumn: "Id",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "DNDClass",
                keyColumn: "Id",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "DNDClass",
                keyColumn: "Id",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "DNDClass",
                keyColumn: "Id",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "DNDClass",
                keyColumn: "Id",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "DNDClass",
                keyColumn: "Id",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "DNDClass",
                keyColumn: "Id",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "DNDClass",
                keyColumn: "Id",
                keyValue: 51);

            migrationBuilder.DeleteData(
                table: "DNDSkill",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "DNDSkill",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "DNDSkill",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "DNDSkill",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "DNDSkill",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "DNDSkill",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "DNDSkill",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "DNDSkill",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "DNDSkill",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "DNDSkill",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "DNDSkill",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "DNDSkill",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "DNDSkill",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "DNDSkill",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "DNDSkill",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "DNDSkill",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "DNDSkill",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "DNDSkill",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Race",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Race",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Race",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Race",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Race",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Race",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Race",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Race",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Race",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Race",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Race",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Race",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Race",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Race",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Race",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Race",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Race",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Race",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Race",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Race",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Race",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Race",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Race",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "AbilityType",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AbilityType",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "AbilityType",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "AbilityType",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "AbilityType",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "DNDClass",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "DNDClass",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "DNDClass",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "DNDClass",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "DNDClass",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "DNDClass",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "DNDClass",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "DNDClass",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "DNDClass",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "DNDClass",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "DNDClass",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "DNDClass",
                keyColumn: "Id",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "Race",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Race",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Race",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Race",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Race",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Race",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DropColumn(
                name: "Size",
                table: "Race");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "DNDSkill");

            migrationBuilder.DropColumn(
                name: "HitDieSize",
                table: "DNDClass");

            migrationBuilder.AddColumn<int>(
                name: "RaceType_Id",
                table: "Race",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SkillType_Id",
                table: "DNDSkill",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ClassType_Id",
                table: "DNDClass",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SubClassType_Id",
                table: "DNDClass",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BackgroundType_Id",
                table: "Background",
                nullable: false,
                defaultValue: 0);
        }
    }
}
