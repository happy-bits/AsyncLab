using System.ComponentModel.DataAnnotations;

namespace AsyncLab.Models;

public class Product
{
    public int Id { get; set; }
    [Required]
    public string Name { get; set; } = string.Empty;
    public decimal Price { get; set; }
} 