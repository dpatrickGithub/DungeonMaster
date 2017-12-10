using DungeonMaster.Models.DNDClass;

namespace DungeonMaster.Repositories
{
    public interface IClassRepository
    {
        DNDClassTypeEnum GetClassTypeById(int classTypeId);
    }
}