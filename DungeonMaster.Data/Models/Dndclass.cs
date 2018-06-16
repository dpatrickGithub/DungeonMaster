using System;
using System.Collections.Generic;

namespace DungeonMaster.Data.Models
{
    public partial class Dndclass : Model
    {
        public Dndclass()
        {
            ChildClass = new HashSet<Dndclass>();
        }

        public string Name { get; set; }
        public string Description { get; set; }
        public int? ParentClassId { get; set; }
        public int ClassTypeId { get; set; }
        public int? SubClassTypeId { get; set; }

        public Dndclass ParentClass { get; set; }
        public ICollection<Dndclass> ChildClass { get; set; }
    }
}
