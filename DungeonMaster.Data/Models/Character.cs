using System;
using System.Collections.Generic;

namespace DungeonMaster.Data.Models
{
    public partial class Character : Model
    {
        public string CharacterName { get; set; }
        public string PlayerName { get; set; }
        public int RaceId { get; set; }
        public int BackgroundId { get; set; }
        public int Level { get; set; }
        public int? Height { get; set; }
        public int? Weight { get; set; }
        public int? Age { get; set; }
        public decimal? Platinum { get; set; }
        public decimal? Gold { get; set; }
        public decimal? Silver { get; set; }
        public decimal? Electrum { get; set; }
        public decimal? Copper { get; set; }

        public Background Background { get; set; }
        public Race Race { get; set; }

        public ICollection<Dndclass> Classes { get; set; }
        public ICollection<CharacterAbilityScore> AbilityScores { get; set; }
    }
}
