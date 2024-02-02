using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DALProduct.Models;

public  class Product
{
    [Required]
    public int Id { get; set; }

    [Required(ErrorMessage ="Please Enter Product name")]
    public string? Name { get; set; }

    [Required(ErrorMessage = "Please Enter Product description")]
    public string? Description { get; set; }

    [Required(ErrorMessage = "Please Enter Product price")]
    public decimal? Price { get; set; }
}
