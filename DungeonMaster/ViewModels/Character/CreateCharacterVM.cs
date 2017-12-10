using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DungeonMaster.WebApi.ViewModels.Character
{
    public class CreateCharacterVM
    {
        public string CharacterName { get; set; }
        public string PlayerName { get; set; }

        public int RaceId { get; set; }
        public int ClassId { get; set; }
        public int BackgroundId { get; set; }

        public int StrScore { get; set; }
        public int DexScore { get; set; }
        public int ConScore { get; set; }
        public int IntScore { get; set; }
        public int WisScore { get; set; }
        public int ChaScore { get; set; }
        
    }
}
