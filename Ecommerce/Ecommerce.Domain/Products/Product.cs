﻿using System.ComponentModel.DataAnnotations;

namespace Ecommerce.Domain.Products;
public class Product
{
    [Key]
    public int ProductId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public int StockQuantity { get; set; }
}
