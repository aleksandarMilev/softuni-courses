namespace Invoices.Data.Models
{
    using System.ComponentModel.DataAnnotations.Schema;

    public class ProductClient
    {
        public int ProductId { get; set; }

        [ForeignKey(nameof(ProductId))]
        public Product Product { get; set; } = null!;

        public int ClientId { get; set; }

        [ForeignKey(nameof(ClientId))]
        public Client Client { get; set; } = null!;
    }
}