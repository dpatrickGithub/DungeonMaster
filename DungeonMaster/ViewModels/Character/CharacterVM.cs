using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DungeonMaster.WebApi.ViewModels.Character
{
    public class CharacterVM
    {
        public int Id { get; set; }
        public string CharacterName { get; set; }
        public string PlayerName { get; set; }
        public int HitPoints { get; set; }
        public int? ArmorClass { get; set; }
    }
}
