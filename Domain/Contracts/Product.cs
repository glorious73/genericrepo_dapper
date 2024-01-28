using System.ComponentModel.DataAnnotations.Schema;
using Domain.Base;

namespace Domain.Contracts;

[Table("products")]
public class Product : Entity
{
    [Column("name")]
    public string? Name { get; set; }
    [Column("description")]
    public string? Description { get; set; }
    [Column("category_id")]
    public int CategoryId { get; set; }
}