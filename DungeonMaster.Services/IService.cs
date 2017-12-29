namespace DungeonMaster.Services
{
    using DungeonMaster.Data.Models;
    using DungeonMaster.Repositories;
    using System;
    using System.Collections.Generic;

    public interface IService
    {
    }

    public interface IModelService<T> : IService where T : BaseModel
    {
        void Create(T entity);
        void Delete(T entity);
        IEnumerable<T> GetAll();
        void Update(T entity);
    }

    public abstract class ModelService<T> : IModelService<T> where T : BaseModel
    {
        IUnitOfWork _unitOfWork;
        IGenericRepository<T> _repository;

        public ModelService(IUnitOfWork unitOfWork, IGenericRepository<T> repository)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
        }


        public virtual void Create(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            _repository.Add(entity);
            _unitOfWork.Commit();
        }


        public virtual void Update(T entity)
        {
            if (entity == null) throw new ArgumentNullException("entity");
            _repository.Edit(entity);
            _unitOfWork.Commit();
        }

        public virtual void Delete(T entity)
        {
            if (entity == null) throw new ArgumentNullException("entity");
            _repository.Delete(entity);
            _unitOfWork.Commit();
        }

        public virtual IEnumerable<T> GetAll()
        {
            return _repository.GetAll();
        }
    }
}
