using DungeonMaster.Data.Models;

namespace DungeonMaster.Services
{
    public interface ICharacterService
    {
        Character CreateCharacter(Character scaffoldedCharacter);
    }
}