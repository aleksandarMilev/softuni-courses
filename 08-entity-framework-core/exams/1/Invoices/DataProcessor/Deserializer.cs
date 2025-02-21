namespace Invoices.DataProcessor
{
    using System.ComponentModel.DataAnnotations;
    using System.Text;
    using System.Xml.Linq;
    using Invoices.Data;
    using Invoices.Data.Models;
    using Invoices.Data.Models.Enums;
    using Invoices.DataProcessor.ImportDto;
    using Invoices.Extensions;
    using Microsoft.EntityFrameworkCore.Query.SqlExpressions;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedClients
            = "Successfully imported client {0}.";

        private const string SuccessfullyImportedInvoices
            = "Successfully imported invoice with number {0}.";

        private const string SuccessfullyImportedProducts
            = "Successfully imported product - {0} with {1} clients.";


        public static string ImportClients(InvoicesContext context, string xmlString)
        {
            List<ImportClientDto> clients = xmlString
                .DeserializeToXml<List<ImportClientDto>>("Clients");

            List<Client> clientsToImport = new();
            StringBuilder builder = new();

            foreach (ImportClientDto clientDto in clients)
            {
                if (!IsValid(clientDto))
                {
                    builder.AppendLine(ErrorMessage);
                    continue;
                }

                Client client = new()
                {
                    Name = clientDto.Name,
                    NumberVat = clientDto.NumberVat
                };

                foreach (var addressDto in clientDto.Addresses)
                {
                    if (!IsValid(addressDto))
                    {
                        builder.AppendLine(ErrorMessage);
                        continue;
                    }

                    client.Addresses.Add(new()
                    {
                        StreetName = addressDto.StreetName,
                        StreetNumber = addressDto.StreetNumber,
                        City = addressDto.City,
                        PostCode = addressDto.PostCode,
                        Country = addressDto.Country,
                    });
                }

                clientsToImport.Add(client);
                builder.AppendLine(string.Format(SuccessfullyImportedClients, client.Name));
            }

            context.Clients.AddRange(clientsToImport);
            context.SaveChanges();

            return builder.ToString().Trim()!;
        }

        public static string ImportInvoices(InvoicesContext context, string jsonString)
        {
            List<ImportInvoiceDto> invoices = jsonString
                .DeserializeFromJson<List<ImportInvoiceDto>>();

            List<Invoice> inovicesToImport = new();

            StringBuilder builder = new();

            foreach (ImportInvoiceDto invoiceDto in invoices)
            {
                if (!IsValid(invoiceDto) || invoiceDto.DueDate < invoiceDto.IssueDate)
                {
                    builder.AppendLine(ErrorMessage);
                    continue;
                }

                Invoice invoice = new()
                {
                    Number = invoiceDto.Number,
                    IssueDate = invoiceDto.IssueDate,
                    DueDate = invoiceDto.DueDate,
                    Amount = invoiceDto.Amount,
                    CurrencyType = invoiceDto.CurrencyType,
                    ClientId = invoiceDto.ClientId
                };

                inovicesToImport.Add(invoice);
                builder.AppendLine(string.Format(SuccessfullyImportedInvoices, invoice.Number));
            }

            context.Invoices.AddRange(inovicesToImport);
            context.SaveChanges();

            return builder.ToString().Trim()!;
        }

        public static string ImportProducts(InvoicesContext context, string jsonString)
        {
            List<ImportProductDto> products = JsonSerializationExtension
                .DeserializeFromJson<List<ImportProductDto>>(jsonString);

            List<Product> productsToImport = new();

            int[] clientsIds = context.Clients
                .Select(c => c.Id)
                .ToArray();

            StringBuilder builder = new();

            foreach (ImportProductDto productDto in products)
            {
                if (!IsValid(productDto))
                {
                    builder.AppendLine(ErrorMessage);
                    continue;
                }

                Product product = new()
                {
                    Name = productDto.Name,
                    Price = productDto.Price,
                    CategoryType = productDto.CategoryType
                };

                foreach (var clientId in productDto.Clients.Distinct())
                {
                    if (clientsIds.Contains(clientId))
                    {
                        product.ProductsClients.Add(new()
                        {
                            ClientId = clientId,
                        });
                    }
                    else
                    {
                        builder.AppendLine(ErrorMessage);
                    }
                }

                productsToImport.Add(product);
                builder.AppendLine(string.Format(SuccessfullyImportedProducts, product.Name, product.ProductsClients.Count));
            }

            context.Products.AddRange(productsToImport);
            context.SaveChanges();

            return builder.ToString().Trim()!;
        }

        public static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    } 
}
