using System.ComponentModel.DataAnnotations.Schema;

namespace solvex_dominicana.Models
{
    [Table("super-markets")]
    public class SuperMarketModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}
