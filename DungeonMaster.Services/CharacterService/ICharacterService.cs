namespace DungeonMaster.Services
{
    using DungeonMaster.Data.Models;

    public interface ICharacterService : IModelService<Character>
    {
        Character GetById(int id);
    }
}