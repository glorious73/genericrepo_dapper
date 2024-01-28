using Application.Dto;
using AutoMapper;
using Domain.Contracts;
using Infrastructure.GenericRepository;
using Infrastructure.UnitOfWork;

namespace Application.Logic.CategoryService;

public class CategoryService : ICategoryService
{
    
    private readonly IUnit _unit;
    private readonly IGenericRepository<Category> _repository;
    private readonly IMapper _mapper;
    
    public CategoryService(IUnit unit, IMapper mapper)
    {
        _unit       = unit;
        _repository = _unit.GetRepository<Category>();
        _mapper     = mapper;
    }
    
    public async Task<int> Create(CategoryDto categoryDto)
    {
        var category       = _mapper.Map<Category>(categoryDto);
        category.CreatedAt = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Utc);
        int result         = await _repository.Add(category);
        return result;
    }

    public async Task<int> Update(int id, CategoryDto categoryDto)
    {
        var category          = await GetById(id);
        category.Name         = categoryDto.Name;
        category.UpdatedAt    = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Utc);
        int categoriesUpdated = await _repository.Update(category);
        return categoriesUpdated;
    }

    public async Task<IEnumerable<Category>> GetAll()
    {
        var categories = await _repository.GetAll();
        return categories;
    }

    public async Task<int> CountAll()
    {
        int count = await _repository.CountAll();
        return count;
    }

    public async Task<Category> GetById(int id)
    {
        var category = await _repository.GetById(id);
        if (category == null)
            throw new Exception("Category record does not exist.");
        return category;
    }

    public async Task<bool> Delete(int id)
    {
        var category = await GetById(id);
        int result   = await _repository.Delete(category); // Could also be done with "isDeleted = true;"
        return (result > 0);
    }
}