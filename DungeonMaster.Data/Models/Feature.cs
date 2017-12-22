﻿using System;
using System.Collections.Generic;

namespace DungeonMaster.Data.Models
{
    public partial class Feature
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Summary { get; set; }
        public string Description { get; set; }
        public int FeatureTypeId { get; set; }

        public FeatureType FeatureType { get; set; }
    }
}