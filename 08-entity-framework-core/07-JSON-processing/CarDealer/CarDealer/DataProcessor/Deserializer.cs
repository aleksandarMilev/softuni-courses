namespace CarDealer.DataProcessor
{
    using CarDealer.Data;
    using CarDealer.Models;
    using Newtonsoft.Json;

    public class Deserializer
    {
        public static string ImportSuppliers(CarDealerContext context, string inputJson)
        {
            Supplier[] suppliers = JsonConvert
                .DeserializeObject<Supplier[]>(inputJson)!;

            context.Suppliers.AddRange(suppliers);
            context.SaveChanges();

            return $"Successfully imported {suppliers.Length}.";
        }

        public static string ImportParts(CarDealerContext context, string inputJson)
        {
            int[] suppliersIds = context.Suppliers.Select(s => s.Id).ToArray();

            Part[] parts = JsonConvert
             .DeserializeObject<Part[]>(inputJson)!
             .Where(p => suppliersIds.Contains(p.SupplierId))
             .ToArray();

            context.Parts.AddRange(parts);
            context.SaveChanges();

            return $"Successfully imported {parts.Length}.";
        }

        public static string ImportCars(CarDealerContext context, string inputJson)
        {
            Car[] cars = JsonConvert
                .DeserializeObject<Car[]>(inputJson)!;

            context.Cars.AddRange(cars);
            context.SaveChanges();

            return $"Successfully imported {cars.Length}.";
        }

        public static string ImportCustomers(CarDealerContext context, string inputJson)
        {
            Customer[] customers = JsonConvert
             .DeserializeObject<Customer[]>(inputJson)!;

            context.Customers.AddRange(customers);
            context.SaveChanges();

            return $"Successfully imported {customers.Length}.";
        }

        public static string ImportSales(CarDealerContext context, string inputJson)
        {
            int[] carsIds = context.Cars
                .Select(c => c.Id)
                .ToArray();

            Sale[] sales = JsonConvert
                .DeserializeObject<Sale[]>(inputJson)!
                .Where(s => carsIds.Contains(s.CarId))
                .ToArray();

            context.Sales.AddRange(sales);
            context.SaveChanges();

            return $"Successfully imported {sales.Length}.";
        }
    }
}