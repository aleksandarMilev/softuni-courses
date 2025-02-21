namespace Invoices.DataProcessor.ExportDto
{
    using Invoices.Data.Models.Enums;

    public class ExportProductDto
    {
        public string Name { get; set; } = null!;

        public decimal Price { get; set; }

        public CategoryType Category { get; set; }

        public ExportClientDto[] Clients { get; set; }
    }
}
