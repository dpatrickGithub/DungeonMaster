using System;
using System.Collections.Generic;

namespace DungeonMaster.Data.Models
{
    public partial class Background : Model
    {
        public Background()
        {
            Character = new HashSet<Character>();
        }

        public int BackgroundTypeId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public BackgroundType BackgroundType { get; set; }
        public ICollection<Character> Character { get; set; }
    }
}
