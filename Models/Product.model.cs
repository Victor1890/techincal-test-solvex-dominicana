using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace solvex_dominicana.Models
{
    [Table("products")]
    public class ProductModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        public Collection<BrandProductModel> BrandProducts { get; set; }
    }
}
