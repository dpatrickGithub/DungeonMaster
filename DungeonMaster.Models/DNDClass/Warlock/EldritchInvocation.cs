using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonMaster.Models.DNDClass.Warlock
{
    public class EldritchInvocation
    {
        public int Id { get; set; }
        public string InvocationName { get; set; }
        public int PrerequisiteLevel { get; set; }
        public DNDSubClassTypeEnum PrerequisitePact { get; set; } 
    }
}
