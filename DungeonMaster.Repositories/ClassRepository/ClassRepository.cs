using DungeonMaster.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DungeonMaster.Repositories
{
    public class ClassRepository : IClassRepository
    {
        private DungeonMasterDevContext _context;

        public ClassRepository(DungeonMasterDevContext context)
        {
            _context = context;
        }

        public Dndclass GetClassTypeById(int classTypeId)
        {
            var results = _context.Dndclass.FirstOrDefault(ct => ct.Id == classTypeId);
            return results;
        }
    }
}
