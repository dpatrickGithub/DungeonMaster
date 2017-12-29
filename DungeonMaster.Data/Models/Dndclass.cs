using System;
using System.Collections.Generic;

namespace DungeonMaster.Data.Models
{
    public partial class Dndclass : Model
    {
        public Dndclass()
        {
            InverseParentClass = new HashSet<Dndclass>();
        }

        public string Name { get; set; }
        public string Desription { get; set; }
        public int? ParentClassId { get; set; }
        public int ClassTypeId { get; set; }
        public int? SubClassTypeId { get; set; }

        public ClassType ClassType { get; set; }
        public Dndclass ParentClass { get; set; }
        public SubClassType SubClassType { get; set; }
        public ICollection<Dndclass> InverseParentClass { get; set; }
    }
}
