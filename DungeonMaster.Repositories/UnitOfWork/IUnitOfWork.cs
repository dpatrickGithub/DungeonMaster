namespace DungeonMaster.Repositories
{
    using System;

    public interface IUnitOfWork : IDisposable
    {
        int Commit();
    }
}
