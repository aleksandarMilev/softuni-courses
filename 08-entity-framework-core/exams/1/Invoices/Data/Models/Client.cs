namespace Invoices.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Client
    {
        private const int NameMaxLength = 25;
        private const int NumberVatMaxLength = 15;

        public Client()
        {
            Invoices = new List<Invoice>();
            Addresses = new List<Address>();
            ProductsClients = new List<ProductClient>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(NameMaxLength)]
        public string Name { get; set; } = null!;

        [Required]
        [MaxLength(NumberVatMaxLength)]
        public string NumberVat { get; set; } = null!;

        public virtual ICollection<Invoice> Invoices { get; set; }

        public virtual ICollection<Address> Addresses { get; set; }

        public virtual ICollection<ProductClient> ProductsClients { get; set; }
    }
}