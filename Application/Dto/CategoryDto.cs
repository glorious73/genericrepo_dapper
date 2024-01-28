using AutoMapper;

namespace Application.Dto;

public class CategoryDto
{
    public string? Name { get; set; }
}

public class CategoryDtoProfile : Profile
{
    public CategoryDtoProfile()
    {
        CreateMap<CategoryDto, Domain.Contracts.Category>();
    }
}