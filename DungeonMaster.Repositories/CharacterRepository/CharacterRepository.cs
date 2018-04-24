namespace DungeonMaster.Repositories
{
    using DungeonMaster.Data.Models;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Linq;

    public class CharacterRepository : GenericRepository<Character>, ICharacterRepository
    {
        public CharacterRepository(DungeonMasterDevContext context) : base(context)
        {
        }

        public override IEnumerable<Character> GetAll() => _entities.Set<Character>().Include(c => c.Background).AsEnumerable();

        public Character GetById(int id) => _dbSet
            .Include(c => c.Background)
            .Include(c => c.Race)
            .Include(c => c.Race)
            .Include(c => c.Race).ThenInclude(r => r.ParentRace)
            .Where(c => c.Id == id).FirstOrDefault();
    }
}
