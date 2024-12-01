using Microsoft.AspNetCore.Mvc;
using SimpleProject.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SimpleProject.ViewModels
{
    public class AddProductViewModel
    {
        [Required]
        public string Name { get; set; }
        public decimal Price { get; set; }
        [NotMapped]
        public List<IFormFile?> Files { get; set; }

        public int CategoryId { get; set; }

    }
}
