using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace SimpleProject.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Remote("IsProductNameExist" , "Product", HttpMethod="Post" , ErrorMessage ="Name Is Already Exist")]
        public string Name { get; set; }
        [Range(1, double.MaxValue , ErrorMessage ="Min value equal 1 and Max value equal 500000")]
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
        [ForeignKey(nameof(CategoryId))]
        public Category? Category { get; set; }
        public ICollection<ProductImages> ProductsImages { get; set; } = new HashSet<ProductImages>();

    }
}
