using SkillNetworkMVC.Data.Repositories;
using System;

namespace SkillNetworkMVC.Data.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        int SaveChanges(bool ensureAutoHistory = false);

        IRepository<TEntity> GetRepository<TEntity>(bool hasCustomRepository = true) where TEntity : class;
    }
}
