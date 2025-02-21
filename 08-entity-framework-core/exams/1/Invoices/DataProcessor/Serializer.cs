namespace Invoices.DataProcessor
{
    using Invoices.Data;
    using Invoices.DataProcessor.ExportDto;
    using Invoices.Extensions;
    using Microsoft.EntityFrameworkCore;
    using System.ComponentModel.DataAnnotations;
    using System.Xml.Linq;

    public class Serializer
    {
        public static string ExportClientsWithTheirInvoices(InvoicesContext context, DateTime date)
        {
            var clientInvoiceDtos = context.Clients
                .Where(c => c.Invoices
                    .Any(i => i.IssueDate > date))
                .Select(c => new ExportClientInvoiceDto
                {
                    ClientName = c.Name,
                    VatNumber = c.NumberVat,
                    InvoicesCount = c.Invoices.Count,
                    Invoices = c.Invoices
                        .OrderBy(i => i.IssueDate)
                        .ThenByDescending(i => i.DueDate)
                        .Select(i => new ExportInvoiceDto()
                        {
                            InvoiceNumber = i.Number,
                            InvoiceAmount = decimal.Parse(i.Amount.ToString("0.##")),
                            DueDate = i.DueDate.ToString("MM/dd/yyyy"),
                            Currency = i.CurrencyType
                        })
                        .ToArray()
                })
                .OrderByDescending(c => c.InvoicesCount)
                .ThenBy(c => c.ClientName)
                .ToArray();

            return clientInvoiceDtos.SerializeToXml("Clients");
        }

        public static string ExportProductsWithMostClients(InvoicesContext context, int nameLength)
        {
            ExportProductDto[] products = context.Products
                .Where(p => p.ProductsClients
                    .Any(pc => pc.Client.Name.Length >= nameLength))
                .Include(p => p.ProductsClients)
                .ThenInclude(pc => pc.Client)
                .Select(p => new ExportProductDto()
                {
                    Name = p.Name,
                    Price = decimal.Parse(p.Price.ToString("0.##")),
                    Category = p.CategoryType,
                    Clients = p.ProductsClients
                        .Where(pc => pc.Client.Name.Length >= nameLength)
                        .Select(pc => new ExportClientDto()
                        {
                            Name = pc.Client.Name,
                            NumberVat = pc.Client.NumberVat
                        })
                        .OrderBy(c => c.Name)
                        .ToArray()
                })
                .OrderByDescending(ep => ep.Clients.Length)
                .ThenBy(ep => ep.Name)
                .Take(5)
                .ToArray();

            return products.SerializeToJson();
        }
    }
}