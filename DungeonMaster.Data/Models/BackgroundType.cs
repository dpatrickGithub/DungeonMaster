using System;
using System.Collections.Generic;

namespace DungeonMaster.Data.Models
{
    public partial class BackgroundType
    {
        public BackgroundType()
        {
            Background = new HashSet<Background>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Background> Background { get; set; }
    }
}
