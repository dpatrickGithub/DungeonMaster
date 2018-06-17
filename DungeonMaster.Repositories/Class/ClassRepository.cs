using DungeonMaster.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DungeonMaster.Repositories
{
    public class ClassRepository : GenericRepository<Dndclass>, IClassRepository
    {
        private DungeonMasterDevContext _context;

        public ClassRepository(DbContext context) : base(context)
        {
        }

        public Dndclass GetClassTypeById(int classTypeId)
        {
            var results = _dbSet.FirstOrDefault(ct => ct.Id == classTypeId);
            return results;
        }

        public IEnumerable<Dndclass> GetParentClasses()
        {
            var results = _dbSet.Where(cls => cls.ParentClassId == null);
            return results;
        }

        public IEnumerable<Dndclass> GetChildClasses(int parentClassId)
        {
            var results = _dbSet.Where(cls => cls.ParentClassId == parentClassId);
            return results;
        }
    }
}
