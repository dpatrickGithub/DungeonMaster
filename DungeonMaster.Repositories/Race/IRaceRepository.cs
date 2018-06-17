using System.Collections.Generic;
using DungeonMaster.Data.Models;

namespace DungeonMaster.Repositories
{
    public interface IRaceRepository
    {
        IEnumerable<Race> GetChildRacesByParentRaceId(int parentRaceId);
        IEnumerable<Race> GetParentRaces();
    }
}