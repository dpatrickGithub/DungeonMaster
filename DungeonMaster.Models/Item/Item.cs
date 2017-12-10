using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonMaster.Models.Item
{
    public class Item
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Weight { get; set; }
        public int Cost { get; set; }
        public MoneyUOMEnum MoneyUnitOfMeasure { get; set; }
    }
}
