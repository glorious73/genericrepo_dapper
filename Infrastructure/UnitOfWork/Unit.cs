using Domain.Base;
using Domain.Database;
using Infrastructure.GenericRepository;

namespace Infrastructure.UnitOfWork;

public class Unit : IUnit
{
    private readonly ApplicationDbContext _context;
    
    public Unit(ApplicationDbContext context)
    {
        _context = context;
    }
    
    public GenericRepository<T> GetRepository<T>() where T : class, IEntity
    {
        return new GenericRepository<T>(_context);
    }
}