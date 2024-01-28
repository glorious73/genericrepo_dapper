using Application.Dto;
using Domain.Contracts;

namespace Application.Logic.ProductService;

public interface IProductService
{
    Task<int> Create(ProductDto productDto);
    Task<int> Update(int id, ProductDto productDto);
    Task<IEnumerable<Product>> GetAll();
    Task<int> CountAll();
    Task<Product> GetById(int id);
    Task<bool> Delete(int id);
}