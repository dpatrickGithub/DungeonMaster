using DungeonMaster.Data.Models;
using System.Collections.Generic;

namespace DungeonMaster.Repositories
{
    public interface IClassRepository
    {
        Dndclass GetClassTypeById(int classTypeId);
    }
}