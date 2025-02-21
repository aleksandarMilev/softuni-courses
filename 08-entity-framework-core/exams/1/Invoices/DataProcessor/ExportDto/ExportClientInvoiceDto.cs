namespace Invoices.DataProcessor.ExportDto
{
    using System.Xml.Serialization;

    [XmlType("Client")]
    public class ExportClientInvoiceDto
    {
        public string ClientName { get; set; }
        public string VatNumber { get; set; }

        [XmlAttribute("InvoicesCount")]
        public int InvoicesCount { get; set; }

        [XmlArray("Invoices")]
        public ExportInvoiceDto[] Invoices { get; set; }
    }
}
