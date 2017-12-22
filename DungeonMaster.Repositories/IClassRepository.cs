using DungeonMaster.Data.Models;

namespace DungeonMaster.Repositories
{
    public interface IClassRepository
    {
        ClassType GetClassTypeById(int classTypeId);
    }
}