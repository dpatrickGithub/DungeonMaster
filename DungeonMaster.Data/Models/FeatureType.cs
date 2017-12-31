using System;
using System.Collections.Generic;

namespace DungeonMaster.Data.Models
{
    public partial class FeatureType : Model
    {
        public FeatureType()
        {
            Feature = new HashSet<Feature>();
        }

        public string Name { get; set; }

        public ICollection<Feature> Feature { get; set; }
    }
}
