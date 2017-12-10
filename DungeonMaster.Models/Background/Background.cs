using DungeonMaster.Models.Ability;
using DungeonMaster.Models.Item.Tool;
using DungeonMaster.Models.Race;
using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonMaster.Models.Background
{
    public class Background
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public IEnumerable<SkillTypeEnum> SkillProficiencies { get; set; }
        public IEnumerable<ToolTypeEnum> ToolProficiencies { get; set; }
        public IEnumerable<Item.Item> Equipment { get; set; }
    }
}
