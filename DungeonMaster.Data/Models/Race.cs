﻿using System;
using System.Collections.Generic;

namespace DungeonMaster.Data.Models
{
    public partial class Race : Model
    {
        public Race()
        {
            Character = new HashSet<Character>();
            ChildRaces = new HashSet<Race>();
        }

        public string Name { get; set; }
        public string Description { get; set; }
        public short BaseSpeed { get; set; }
        public int? ParentRaceId { get; set; }
        public int? SubRaceTypeId { get; set; }
        public string Size { get; set; }


        public Race ParentRace { get; set; }
        public ICollection<Character> Character { get; set; }
        public ICollection<Race> ChildRaces { get; set; }
    }
}
