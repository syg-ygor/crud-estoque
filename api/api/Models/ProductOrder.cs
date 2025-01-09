using System.ComponentModel.DataAnnotations.Schema;

namespace api.Models
{
    public class ProductOrder
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int OrderId { get; set; }
        [ForeignKey("ProductId")]
        public Product Product
        {
            get; set;

        }
        [ForeignKey("OrderId")]
        public Order Order
        {
            get; set;

        }
    }
}
