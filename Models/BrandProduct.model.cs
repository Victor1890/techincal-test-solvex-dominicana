using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace solvex_dominicana.Models
{
    [Table("brand-products")]
    public class BrandProductModel
    {
        public int Id { get; set; }

        [Required]
        public Nullable<int> ProductId { get; set; }

        [Required]
        public Nullable<int> BrandId { get; set; }

        public ProductModel Product { get; set; }

        public BrandModel Brand { get; set; }
    }
}
