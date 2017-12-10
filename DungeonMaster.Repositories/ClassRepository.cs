using DungeonMaster.Models.DNDClass;
using System;

namespace DungeonMaster.Repositories
{
    public class ClassRepository : IClassRepository
    {
        public DNDClassTypeEnum GetClassTypeById(int classTypeId)
        {
            if (!Enum.IsDefined(typeof(DNDClassTypeEnum), classTypeId))
            {
                throw new Exception(String.Format("Could not find a class corresponding to {0}", classTypeId));
            }

            return (DNDClassTypeEnum)classTypeId;
        }
    }
}
