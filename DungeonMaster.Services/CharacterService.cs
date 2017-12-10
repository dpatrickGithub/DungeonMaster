using DungeonMaster.Models.Character;
using DungeonMaster.Models.DNDClass;
using DungeonMaster.Repositories;
using System;

namespace DungeonMaster.Services
{
    public class CharacterService : ICharacterService
    {
        private readonly IClassRepository _classRepo;

        public CharacterService(IClassRepository classRepo)
        {
            _classRepo = classRepo;
        }

        public Character CreateCharacter(Character scaffoldedCharacter)
        {

            var dndClass = new DNDClass();
            return scaffoldedCharacter;
        }
    }
}
