using System;
using System.Collections.Generic;

namespace DungeonMaster.Data.Models
{
    public partial class SubClassType
    {
        public SubClassType()
        {
            Dndclass = new HashSet<Dndclass>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Dndclass> Dndclass { get; set; }
    }
}
