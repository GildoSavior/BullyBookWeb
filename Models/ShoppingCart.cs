using System.ComponentModel.DataAnnotations;

namespace BullyBookWeb.Models
{
    public class ShoppingCart
    {
        public Product? Product { get; set; }
        [Range(1, 1000, ErrorMessage ="hgjkl;")]
        public int Count { get; set; }
    }
}