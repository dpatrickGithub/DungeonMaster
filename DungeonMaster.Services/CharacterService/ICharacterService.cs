namespace DungeonMaster.Services
{
    using DungeonMaster.Data.Models;

    public interface ICharacterService : IModelService<Character>
    {
        Models.Character.Character GetById(int id);
    }
}