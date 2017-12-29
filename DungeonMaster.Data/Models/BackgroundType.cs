using System;
using System.Collections.Generic;

namespace DungeonMaster.Data.Models
{
    public partial class BackgroundType : Model
    {
        public BackgroundType()
        {
            Background = new HashSet<Background>();
        }

        public string Name { get; set; }

        public ICollection<Background> Background { get; set; }
    }
}
