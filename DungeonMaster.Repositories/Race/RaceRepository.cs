using DungeonMaster.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DungeonMaster.Repositories
{
    public class RaceRepository : GenericRepository<Race>, IRaceRepository
    {
        public RaceRepository(DbContext context) : base(context)
        {
        }

        public IEnumerable<Race> GetParentRaces()
        {
            return _dbSet.Where(race => race.ParentRaceId == null);
        }

        public IEnumerable<Race> GetChildRacesByParentRaceId(int parentRaceId)
        {
            return _dbSet.Where(race => race.ParentRaceId == parentRaceId);
        }
    }
}
