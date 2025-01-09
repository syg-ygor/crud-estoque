using System.ComponentModel.DataAnnotations.Schema;

namespace api.Models
{
    public class Maintenance
    {
        public int Id { get; set; }
        public string Observation { get; set; }
        public int ProductId { get; set; }

        [ForeignKey("ProductId")]
        public Product Product
        {
            get; set;

        }
    }
}
