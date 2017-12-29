using System;
using System.Collections.Generic;

namespace DungeonMaster.Data.Models
{
    public partial class Race : Model
    {
        public Race()
        {
            Character = new HashSet<Character>();
            InverseParentRace = new HashSet<Race>();
        }

        public string Name { get; set; }
        public string Description { get; set; }
        public short BaseSpeed { get; set; }
        public int? ParentRaceId { get; set; }
        public int RaceTypeId { get; set; }
        public int? SubRaceTypeId { get; set; }

        public Race ParentRace { get; set; }
        public RaceType RaceType { get; set; }
        public SubRaceType SubRaceType { get; set; }
        public ICollection<Character> Character { get; set; }
        public ICollection<Race> InverseParentRace { get; set; }
    }
}
