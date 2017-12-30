namespace DungeonMaster.Services
{
    using DungeonMaster.Data.Models;
    using System.Collections.Generic;

    public interface IModelService<T> : IService where T : BaseModel
    {
        void Create(T entity);
        void Delete(T entity);
        IEnumerable<T> GetAll();
        void Update(T entity);
    }
}
