using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace solvex_dominicana.Models
{
    [Table("brands")]
    public class BrandModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        public Collection<BrandProductModel> BrandProducts { get; set; }
    }
}
