namespace CarDealer
{
    using CarDealer.Data;
    using System.Text;

    public class StartUp
    {
        private static readonly string ImportSuppliersJsonStr = File.ReadAllText("../../../Datasets/suppliers.json");
        private static readonly string ImportPartsJsonStr = File.ReadAllText("../../../Datasets/parts.json");
        private static readonly string ImportCarsJsonStr = File.ReadAllText("../../../Datasets/cars.json");
        private static readonly string ImportCustomersJsonStr = File.ReadAllText("../../../Datasets/customers.json");
        private static readonly string ImportSalesJsonStr = File.ReadAllText("../../../Datasets/sales.json");

        public static void Main()
        {
            using CarDealerContext context = new();

            Console.WriteLine(ImportData(context));
            Console.WriteLine(ExportData(context));
        }

        private static string ImportData(CarDealerContext context)
        {
            StringBuilder builder = new();

            //builder.AppendLine(Deserializer.ImportSuppliers(context, ImportSuppliersJsonStr));
            //builder.AppendLine(Deserializer.ImportParts(context, ImportPartsJsonStr));
            //builder.AppendLine(Deserializer.ImportCars(context, ImportCarsJsonStr));
            //builder.AppendLine(Deserializer.ImportCustomers(context, ImportCustomersJsonStr));
            //builder.AppendLine(Deserializer.ImportSales(context, ImportSalesJsonStr));

            return builder
                .ToString()
                .TrimEnd();
        }
        private static string ExportData(CarDealerContext context)
        {
            StringBuilder builder = new();

            //builder.AppendLine(Serializer.GetOrderedCustomers(context));
            //builder.AppendLine(Serializer.GetCarsFromMakeToyota(context));
            //builder.AppendLine(Serializer.GetLocalSuppliers(context));
            //builder.AppendLine(Serializer.GetCarsWithTheirListOfParts(context));

            return builder
                .ToString()
                .TrimEnd();
        }
    }
}