using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonMaster.Models.Spell
{
    public class Spell
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Level { get; set; }
        public bool IsPrepared { get; set; }
        public bool IsUsed { get; set; }
    }
}
