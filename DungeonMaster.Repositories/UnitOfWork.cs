namespace DungeonMaster.Repositories
{
    using DungeonMaster.Data.Models;
    using Microsoft.EntityFrameworkCore;
    using System;

    public interface IUnitOfWork : IDisposable
    {
        int Commit();
    }

    public class UnitOfWork : IUnitOfWork
    {
        private DungeonMasterDevContext _dbContext;

        public UnitOfWork(DungeonMasterDevContext context)
        {

            _dbContext = context;
        }

        public int Commit()
        {
            // Save changes with the default options
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
