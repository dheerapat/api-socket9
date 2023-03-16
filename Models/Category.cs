using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using NT.Common.DataAccess.Entities;
namespace prod.Models;

public class Category : EntityBase
{
    // public int Id { get; set; }
    [Column("categoryName")]
    public string? categoryName { get; set; }
}