using System;
using System.Collections.Generic;

namespace DungeonMaster.Data.Models
{
    public partial class Feature : Model
    {
        public string Title { get; set; }
        public string Summary { get; set; }
        public string Description { get; set; }
        public int FeatureTypeId { get; set; }

    }
}
