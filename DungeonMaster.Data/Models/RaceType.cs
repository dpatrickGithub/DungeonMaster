using System;
using System.Collections.Generic;

namespace DungeonMaster.Data.Models
{
    public partial class RaceType
    {
        public RaceType()
        {
            Race = new HashSet<Race>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Race> Race { get; set; }
    }
}
