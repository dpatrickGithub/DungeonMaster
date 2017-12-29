using System;
using System.Collections.Generic;

namespace DungeonMaster.Data.Models
{
    public partial class SubClassType : Model
    {
        public SubClassType()
        {
            Dndclass = new HashSet<Dndclass>();
        }

        public string Name { get; set; }

        public ICollection<Dndclass> Dndclass { get; set; }
    }
}
