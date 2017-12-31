namespace DungeonMaster.Repositories
{
    using DungeonMaster.Data.Models;
    using System;

    public class UnitOfWork : IUnitOfWork
    {
        private DungeonMasterDevContext _dbContext;

        public UnitOfWork(DungeonMasterDevContext context)
        {
            _dbContext = context;
        }

        public int Commit()
        {
            return _dbContext.SaveChanges();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_dbContext != null)
                {
                    _dbContext.Dispose();
                    _dbContext = null;
                }
            }
        }
    }
}
