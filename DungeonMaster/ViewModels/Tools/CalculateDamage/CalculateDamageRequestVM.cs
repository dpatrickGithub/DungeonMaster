using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DungeonMaster.WebApi.ViewModels.Tools.CalculateDamage
{
    public class CalculateDamageRequestVM
    {
        public int DieCount { get; set; }
        public DieSizeEnum DieSize { get; set; }
        public int AdditionalModifiers { get; set; }
        public bool IsCritical { get; set; }
    }
}
