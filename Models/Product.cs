using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using NT.Common.DataAccess.Entities;

namespace prod.Models;

public class Product : EntityBase
{
    // [Key]
    // public int Id { get; set; }
    [Column("productName")]
    public string? productName { get; set; }
    public Category? Category { get; set; }
}