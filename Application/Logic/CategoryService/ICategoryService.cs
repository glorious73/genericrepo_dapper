using Application.Dto;
using Domain.Contracts;

namespace Application.Logic.CategoryService;

public interface ICategoryService
{
    Task<int> Create(CategoryDto categoryDto);
    Task<int> Update(int id, CategoryDto categoryDto);
    Task<IEnumerable<Category>> GetAll();
    Task<int> CountAll();
    Task<Category> GetById(int id);
    Task<bool> Delete(int id);
}