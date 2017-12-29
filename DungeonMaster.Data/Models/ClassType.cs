using System;
using System.Collections.Generic;

namespace DungeonMaster.Data.Models
{
    public partial class ClassType : Model
    {
        public ClassType()
        {
            Dndclass = new HashSet<Dndclass>();
        }

        public string Name { get; set; }

        public ICollection<Dndclass> Dndclass { get; set; }
    }
}
