using System;
using System.Collections.Generic;

namespace DungeonMaster.Data.Models
{
    public partial class SubRaceType : Model
    {
        public SubRaceType()
        {
            Race = new HashSet<Race>();
        }

        public string Name { get; set; }

        public ICollection<Race> Race { get; set; }
    }
}
