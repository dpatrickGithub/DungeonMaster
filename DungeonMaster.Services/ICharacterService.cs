using DungeonMaster.Models.Character;

namespace DungeonMaster.Services
{
    public interface ICharacterService
    {
        Character CreateCharacter(Character scaffoldedCharacter);
    }
}