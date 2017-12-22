using System;
using System.Collections.Generic;

namespace DungeonMaster.Data.Models
{
    public partial class FeatureType
    {
        public FeatureType()
        {
            Feature = new HashSet<Feature>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Feature> Feature { get; set; }
    }
}
