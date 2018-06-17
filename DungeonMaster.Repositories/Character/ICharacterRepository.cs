namespace DungeonMaster.Repositories
{
    using DungeonMaster.Data.Models;

    public interface ICharacterRepository : IGenericRepository<Character>
    {
        Character GetById(int id);
    }
}
