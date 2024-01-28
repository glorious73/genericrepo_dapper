using Application.Dto;
using AutoMapper;
using Domain.Contracts;
using Infrastructure.GenericRepository;
using Infrastructure.UnitOfWork;

namespace Application.Logic.ProductService;

public class ProductService : IProductService
{
    private readonly IUnit _unit;
    private readonly IGenericRepository<Product> _repository;
    private readonly IMapper _mapper;
    
    public ProductService(IUnit unit, IMapper mapper)
    {
        _unit       = unit;
        _repository = _unit.GetRepository<Product>();
        _mapper     = mapper;
    }
    
    public async Task<int> Create(ProductDto productDto)
    {
        var product       = _mapper.Map<Product>(productDto);
        product.CreatedAt = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Utc);
        int result        = await _repository.Add(product);
        return result;
    }

    public async Task<int> Update(int id, ProductDto productDto)
    {
        var product         = await GetById(id);
        product.Name        = productDto.Name;
        product.Description = productDto.Description;
        product.CategoryId  = productDto.CategoryId;
        product.UpdatedAt   = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Utc);
        int productsUpdated = await _repository.Update(product);
        return productsUpdated;
    }

    public async Task<IEnumerable<Product>> GetAll()
    {
        var products = await _repository.GetAll();
        return products;
    }

    public async Task<int> CountAll()
    {
        int count = await _repository.CountAll();
        return count;
    }

    public async Task<Product> GetById(int id)
    {
        var product = await _repository.GetById(id);
        if (product == null)
            throw new Exception("Product record does not exist.");
        return product;
    }

    public async Task<bool> Delete(int id)
    {
        var product  = await GetById(id);
        int result   = await _repository.Delete(product); // Could also be done with "isDeleted = true;"
        return (result > 0);
    }
}