using System.ComponentModel.DataAnnotations.Schema;

namespace solvex_dominicana.Models
{
    [Table("super-market-brands")]
    public class SuperMarketBrandModel
    {
        public int Id { get; set; }

        public Nullable<int> BrandId { get; set; }
        public Nullable<int> SuperMarketId { get; set; }

        public BrandModel Brand { get; set; }
        public SuperMarketModel SuperMarket { get; set; }
    }
}
