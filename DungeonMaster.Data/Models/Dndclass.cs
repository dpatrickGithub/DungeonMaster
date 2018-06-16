using System;
using System.Collections.Generic;

namespace DungeonMaster.Data.Models
{
    public partial class Dndclass : Model
    {
        public Dndclass()
        {
            ChildClasses = new HashSet<Dndclass>();
        }

        public string Name { get; set; }
        public string Description { get; set; }
        public int? ParentClassId { get; set; }
        public int HitDieSize { get; set; }

        public Dndclass ParentClass { get; set; }
        public ICollection<Dndclass> ChildClasses { get; set; }
    }
}
