using System.ComponentModel.DataAnnotations.Schema;
using Domain.Base;

namespace Domain.Contracts;

[Table("categories")]
public class Category : Entity
{
    [Column("name")]
    public string? Name { get; set; }
}