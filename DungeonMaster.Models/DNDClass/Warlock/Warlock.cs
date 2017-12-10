using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonMaster.Models.DNDClass.Warlock
{
    public class Warlock : DNDClass
    {
        public IEnumerable<EldritchInvocation> EldritchInvocations { get; set; }
    }
}
