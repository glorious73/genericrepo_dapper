using AutoMapper;

namespace Application.Dto;

public class ProductDto
{
    public string? Name { get; set; }
    public string? Description { get; set; }
    public int CategoryId { get; set; }
}

public class ProductDtoProfile : Profile
{
    public ProductDtoProfile()
    {
        CreateMap<ProductDto, Domain.Contracts.Product>();
    }
}