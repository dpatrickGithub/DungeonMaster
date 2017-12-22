using System;
using System.Collections.Generic;

namespace DungeonMaster.Data.Models
{
    public partial class ClassType
    {
        public ClassType()
        {
            Dndclass = new HashSet<Dndclass>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Dndclass> Dndclass { get; set; }
    }
}
