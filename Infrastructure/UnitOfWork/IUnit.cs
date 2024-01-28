using Domain.Base;
using Infrastructure.GenericRepository;

namespace Infrastructure.UnitOfWork;

public interface IUnit
{
    GenericRepository<T> GetRepository<T>() where T : class, IEntity;
}