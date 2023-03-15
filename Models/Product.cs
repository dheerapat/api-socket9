using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace prod.Models;

public class Product
{
    [Key]
    public int Id { get; set; }
    [Column("productName")]
    public string? productName { get; set; }
    public Category? Category { get; set; }
}